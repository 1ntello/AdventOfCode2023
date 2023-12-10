using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Challenges
{
    public class Challenge5
    {
        public class almanac_line 
        {
            public long destRangeStart;
            public long sourceRangeStart;
            public long range; 
        }

        public long CrazyChallenge(string[] data)
        {
            var seedsAsStrings = data[0].Split(':')[1].Split(' ');
            List<long> seeds = new List<long>();
            List<long> results = new List<long>();
            foreach (var s in seedsAsStrings.Where(x => x != ""))
                seeds.Add(long.Parse(s));

            data[0] = "ignore";
            data[1] = "ignore";
            var parsedData = ParseDatalongoAlmanak(data);
            foreach (var s in seeds)
            {
                long sourceValue = s;
                long destinationValue = 0;
                // now the fun begins. We start at map[0] and we have 7
                for (long i = 0; i < 7; i++)
                {
                    var currentMap = parsedData[i];
                    var matchingLine = currentMap.Where(x => sourceValue >= x.sourceRangeStart && sourceValue <= (x.sourceRangeStart + x.range)).FirstOrDefault();
                    if (matchingLine == default(almanac_line))
                    {
                        continue;
                    }
                    else
                    {
                        var differenceFromSource = sourceValue - matchingLine.sourceRangeStart;
                        destinationValue = matchingLine.destRangeStart + differenceFromSource;
                        sourceValue = destinationValue; // because this the start for the next one 
                    }
                }
                results.Add(destinationValue);
            }
            return results.Min();
        }

        public long CrazyChallenge_MoarSeeds(string[] data)
        {
            var seedsAsStrings = data[0].Split(':')[1].Split(' ');
            long lowestLocation = long.MaxValue;
            Dictionary<long, long> seedsWithRanges = ParseSeedsIntoRanges(seedsAsStrings);
            data[0] = "ignore";
            data[1] = "ignore";
            var parsedData = ParseDatalongoAlmanak(data);
            foreach (var seeds_range in seedsWithRanges)
            {
                Console.WriteLine($"starting with seeds range {seeds_range} ");
                var lowest = GetLowestLocationForRange(seeds_range, parsedData);
                Console.WriteLine($" lowest { lowest}  ");
                if (lowest < lowestLocation)
                    lowestLocation = lowest;
            }
            return lowestLocation;
        }

        private long GetLowestLocationForRange(KeyValuePair<long, long> seeds_range, List<almanac_line>[] data)
        {
            List<long> seeds = new List<long>();
            Dictionary<long, long> results = new Dictionary<long, long>();
            long lowestLocation = long.MaxValue;
            long lowestSeed = long.MaxValue;
            for (long x = seeds_range.Key; x < (seeds_range.Key + seeds_range.Value); x++)
                seeds.Add(x);
            // we gotta do a range here. We split the seeds in batches and then just meeerge. 
            
            int pageCounter = 0;
            var page = new List<long>();
            page = seeds.Skip(pageCounter).Take(100000).ToList();
            while (page.Any())
            {
                foreach (var s in page)
                {
                    long sourceValue = s;
                    long destinationValue = 0;
                    // now the fun begins. We start at map[0] and we have 7
                    for (long i = 0; i < 7; i++)
                    {
                        var currentMap = data[i];
                        
                        var matchingLine = currentMap.Where(x => sourceValue >= x.sourceRangeStart && sourceValue <= (x.sourceRangeStart + x.range)).FirstOrDefault();
                        if (matchingLine == default(almanac_line))
                        {
                            continue;
                        }
                        else
                        {
                            var differenceFromSource = sourceValue - matchingLine.sourceRangeStart;
                            destinationValue = matchingLine.destRangeStart + differenceFromSource;
                            sourceValue = destinationValue; // because this the start for the next one 
                        }
                    }
                    if (destinationValue < lowestLocation) 
                    {
                        lowestLocation = destinationValue;
                        lowestSeed = s;
                    }
                }
                pageCounter += 100000;
                page = seeds.Skip(pageCounter).Take(100000).ToList();
            }
            return lowestLocation;
        }

        private KeyValuePair<long, long> OldMethod(KeyValuePair<long, long> seeds_range, List<almanac_line>[] data)
        {
            List<long> seeds = new List<long>();
            Dictionary<long, long> results = new Dictionary<long, long>();
            for (long x = seeds_range.Key; x <= (seeds_range.Key + seeds_range.Value); x++)
                seeds.Add(x);
            // we gotta do a range here. We split the seeds in batches and then just meeerge. 
            int pageCounter = 0;
            foreach (var s in seeds)
            {
                long sourceValue = s;
                long destinationValue = 0;
                // now the fun begins. We start at map[0] and we have 7
                for (long i = 0; i < 7; i++)
                {
                    var currentMap = data[i];
                    var matchingLine = currentMap.Where(x => sourceValue >= x.sourceRangeStart && sourceValue <= (x.sourceRangeStart + x.range)).FirstOrDefault();
                    if (matchingLine == default(almanac_line))
                    {
                        continue;
                    }
                    else
                    {
                        var differenceFromSource = sourceValue - matchingLine.sourceRangeStart;
                        destinationValue = matchingLine.destRangeStart + differenceFromSource;
                        sourceValue = destinationValue; // because this the start for the next one 
                    }
                }
                results.Add(s, destinationValue);
            }

            var lowest = results.OrderBy(x => x.Value).First();
            return lowest;
        }

        public Dictionary<long, long> ParseSeedsIntoRanges(string[] seedsAsStrings)
        {
            List<long> seeds = new List<long>();
            List<long> results = new List<long>();
            foreach (var s in seedsAsStrings.Where(x => x != ""))
                seeds.Add(long.Parse(s));

            Dictionary<long, long> seedsIntoRanges = new Dictionary<long, long>();
            bool seedTime = true;
            long key = 0;
            long value = 0;
            foreach (var s in seeds)
            {
                if (seedTime)
                {
                    key = s;
                    seedTime = false;
                }
                else
                {
                    value = s;
                    seedsIntoRanges.Add(key, value);
                    seedTime = true;
                }
            }
            return seedsIntoRanges;
        }
        public List<almanac_line>[] ParseDatalongoAlmanak(string[] data) 
        {
            // we get like 8 lists, each list has lines of long arrrays of 3 max. 
            // So we start of by stating that line 1 is the seeds we are looking for, but we parse that in the earlier crazy challenge, so we dont care
            List<almanac_line>[] finalData = new List<almanac_line>[8];
            List<almanac_line> mapData = new List<almanac_line>();
            long mapCounter = 0;
            foreach (var mapline in data)
            {
                if(mapline == "ignore")
                    continue;
                else if (mapline == "")
                {
                    finalData[mapCounter] = mapData;
                    mapCounter++;
                    mapData = new List<almanac_line>();
                    continue;
                }
                else if (char.IsLetter(mapline[0]))
                {
                    continue; // we dont give a fuck about names its all about order; 
                }
                else
                {
                    var values = mapline.Split(' ');
                    almanac_line almanac_Line = new almanac_line()
                    {
                        destRangeStart = long.Parse(values[0]),
                        sourceRangeStart = long.Parse(values[1]),
                        range = long.Parse(values[2])
                    };
                    mapData.Add(almanac_Line);
                }
            }

            finalData[mapCounter] = mapData; // map last one 
            return finalData;
        }
    }
}
