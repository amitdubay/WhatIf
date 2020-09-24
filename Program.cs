using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatIf
{
    class Program
    {
        const int STANDARD_TRAVEL_TIME = 60;
        static void Main(string[] args)
        {
            Console.Write("At what time do you plan to start? Enter (XX:XX): ");
            var startTime = TimeSpan.Parse(Console.ReadLine());

            var additionalTimeRule = AdditionalTravelTimeEstimates.FirstOrDefault(t => startTime >= t.From && startTime < t.To);
            int travelTime = additionalTimeRule == null ? STANDARD_TRAVEL_TIME : STANDARD_TRAVEL_TIME + additionalTimeRule.AdditionalTime;

            Console.WriteLine($"Your estimated travel time is: {travelTime} minutes");
        }

        private static List<AdditionalTravelTimeEstimate> AdditionalTravelTimeEstimates = new List<AdditionalTravelTimeEstimate>
        {
            new AdditionalTravelTimeEstimate("8:00", "8:30", 15),
            new AdditionalTravelTimeEstimate("8:30", "9:00", 30),
            new AdditionalTravelTimeEstimate("9:00", "9:30", 45),
            new AdditionalTravelTimeEstimate("9:30", "10:00", 30),
            new AdditionalTravelTimeEstimate("10:00", "10:30", 15),

            new AdditionalTravelTimeEstimate("16:00", "16:30", 15),
            new AdditionalTravelTimeEstimate("16:30", "17:00", 30),
            new AdditionalTravelTimeEstimate("17:00", "17:30", 45),
            new AdditionalTravelTimeEstimate("17:30", "18:00", 30),
            new AdditionalTravelTimeEstimate("18:00", "18:30", 15)
        };

        static void Traditional()
        {
            Console.Write("At what time do you plan to start? Enter (XX:XX): ");
            var startTime = TimeSpan.Parse(Console.ReadLine());

            int additionalTime;

            if(startTime >= TimeSpan.Parse("8:00") && startTime < TimeSpan.Parse("8:30"))
            {
                additionalTime = 15;
            }
            else if (startTime >= TimeSpan.Parse("8:30") && startTime < TimeSpan.Parse("9:00"))
            {
                additionalTime = 39;
            }
            else if (startTime >= TimeSpan.Parse("9:00") && startTime < TimeSpan.Parse("9:30"))
            {
                additionalTime = 45;
            }
            else if (startTime >= TimeSpan.Parse("9:30") && startTime < TimeSpan.Parse("10:00"))
            {
                additionalTime = 30;
            }
            else if (startTime >= TimeSpan.Parse("10:00") && startTime < TimeSpan.Parse("10:30"))
            {
                additionalTime = 15;
            }
            else if (startTime >= TimeSpan.Parse("16:00") && startTime < TimeSpan.Parse("16:30"))
            {
                additionalTime = 15;
            }
            else if (startTime >= TimeSpan.Parse("16:30") && startTime < TimeSpan.Parse("17:00"))
            {
                additionalTime = 30;
            }
            else if (startTime >= TimeSpan.Parse("17:00") && startTime < TimeSpan.Parse("17:30"))
            {
                additionalTime = 45;
            }
            else if (startTime >= TimeSpan.Parse("17:30") && startTime < TimeSpan.Parse("18:00"))
            {
                additionalTime = 30;
            }
            else if (startTime >= TimeSpan.Parse("18:00") && startTime < TimeSpan.Parse("18:30"))
            {
                additionalTime = 15;
            }
            else
            {
                additionalTime = 0;
            }
            Console.WriteLine($"Your estimated travel time is: { STANDARD_TRAVEL_TIME + additionalTime} minutes");
        }
    }

    class AdditionalTravelTimeEstimate
    {
        public AdditionalTravelTimeEstimate(string from, string to, int additionalTime)
        {
            From = TimeSpan.Parse(from);
            To = TimeSpan.Parse(to);
            AdditionalTime = additionalTime;
        }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public int AdditionalTime { get; set; }
    }
}
