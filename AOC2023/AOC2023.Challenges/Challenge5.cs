using System;
using System.Collections.Generic;
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
            public int destRangeStart;
            public int sourceRangeStart;
            public int range; 
        }

        public int CrazyChallenge(string[] data)
        {
            var seedsAsStrings = data[0].Split(':')[1].Split(' ');
            List<int> seeds = new List<int>();
            List<int> results = new List<int>();
            foreach (var s in seedsAsStrings.Where(x => x != ""))
                seeds.Add(int.Parse(s));

            data[0] = "ignore";
            data[1] = "ignore";
            var parsedData = ParseDataIntoAlmanak(data);
            foreach (var s in seeds)
            {
                int sourceValue = s;
                int destinationValue = 0;
                // now the fun begins. We start at map[0] and we have 7
                for (int i = 0; i < 7; i++)
                {
                    var currentMap = parsedData[i];
                    var matchingLine = currentMap.Where(x => sourceValue > x.sourceRangeStart && sourceValue < (x.sourceRangeStart + x.range)).FirstOrDefault();
                    if (matchingLine == default(almanac_line))
                    {
                        destinationValue = s;
                    }
                    else
                    {
                        var differenceFromSource = s - matchingLine.sourceRangeStart;
                        destinationValue = matchingLine.destRangeStart + differenceFromSource;
                        sourceValue = destinationValue; // because this the start for the next one 
                    }
                }
                results.Add(destinationValue);
            }
            return results.Min();
        }

        public List<almanac_line>[] ParseDataIntoAlmanak(string[] data) 
        {
            // we get like 8 lists, each list has lines of int arrrays of 3 max. 
            // So we start of by stating that line 1 is the seeds we are looking for, but we parse that in the earlier crazy challenge, so we dont care
            List<almanac_line>[] finalData = new List<almanac_line>[8];
            List<almanac_line> mapData = new List<almanac_line>();
            int mapCounter = 0;
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
                        destRangeStart = int.Parse(values[0]),
                        sourceRangeStart = int.Parse(values[1]),
                        range = int.Parse(values[2])
                    };
                    mapData.Add(almanac_Line);
                }
            }

            finalData[mapCounter] = mapData; // map last one 
            return finalData;
        }
    }
}
