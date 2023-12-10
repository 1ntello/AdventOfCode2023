using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Challenges
{
    public class RaceResult
    {
        public long Speed { get; set; }
        public long Distance {get; set; }
    }
    public class Challenge6
    {
        public int CalculateAmountOfOptions(string[] data)
        {
            List<RaceResult> result = ParseData(data);
            int total = 1;
            foreach (var r in result)
            {
                total *= AmountOfOptionsToWinRace(r);
            }
            return total;
        }

        public int CalculateBigRace(string[] data)
        {
            RaceResult result = ParseDataForChallenge2(data);
            var total = AmountOfOptionsToWinRace(result);
            return total;
        }

        public int AmountOfOptionsToWinRace(RaceResult r)
        {
            // We either press the button for x seconds, and then our speed goes up
            // Or we just go and have no speed. 
            int speed = 0;
            int timeButtonPressed = 0;
            int options = 0;
            // we can never have more options than time i'd argue. 
            for (int i = 0; i < r.Speed; i++)
            {
                bool distanceMade = false;
                // now we calculate if we make the distance 
                if (speed == 0)
                {
                    speed++;
                    timeButtonPressed++;
                    continue;
                }
                
                distanceMade = timeButtonPressed + (r.Distance / speed) < r.Speed;
                if (distanceMade)
                    options++;
                

                //Debug.WriteLine($"We pressed the button for {timeButtonPressed} which gave us a speed of {speed} and that gives us a speed m/s of {r.Distance / speed}");
                //Debug.WriteLine($"Which means we take an amount of {timeButtonPressed + (r.Distance / speed)} and that is compared to {r.Speed} and that is {distanceMade} ");

                timeButtonPressed++;
                speed++;
            }

            return options;
        }
        public List<RaceResult> ParseData(string[] data)
        {
            List<RaceResult> rr = new List<RaceResult>();
            var timesString = data[0].Split(':')[1];
            var distanceString = data[1].Split(':')[1];

            var timesSplit = timesString.Split(' ');
            var distanceSplit = distanceString.Split(' ');

            List<int> times = new List<int>();
            List<int> distances = new List<int>();

            foreach (var time in timesSplit.Where(x => x != ""))
                times.Add(int.Parse(time));
            foreach (var distance in distanceSplit.Where(x => x != ""))
                distances.Add(int.Parse(distance));

            for (int i = 0; i < times.Count; i++)
            {
                RaceResult r = new Challenges.RaceResult
                {
                    Distance = distances[i],
                    Speed = times[i]
                };
                rr.Add(r);
            }
            return rr;
        }
        public RaceResult ParseDataForChallenge2(string[] data)
        {
            var timesString = data[0].Split(':')[1];
            var distanceString = data[1].Split(':')[1];

            var timesSplit = timesString.Split(' ');
            var distanceSplit = distanceString.Split(' ');

            List<int> times = new List<int>();
            List<int> distances = new List<int>();
            StringBuilder sb = new StringBuilder();
            StringBuilder db = new StringBuilder();

            foreach (var time in timesSplit.Where(x => x != ""))
                sb.Append(time);
            foreach (var distance in distanceSplit.Where(x => x != ""))
                db.Append(distance);

            RaceResult race = new RaceResult()
            {
                Distance = long.Parse(db.ToString()),
                Speed = long.Parse(sb.ToString())
            };
            return race;
        }

    }
}
