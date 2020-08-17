using System;

namespace CleanCode.DuplicatedCode
{
    public class Time
    {
        public int Hours { get; }
        public int Minutes { get; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        // As Parsing is more of a general concept, hence extracting the method here in Time class
        // instead of making a private method in DuplicateCode class
        public static Time Parse(string admissionDateTime)
        {
            int time;
            int hours = 0;
            int minutes = 0;
            if (!string.IsNullOrWhiteSpace(admissionDateTime))
            {
                if (int.TryParse(admissionDateTime.Replace(":", ""), out time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("admissionDateTime");
                }
            }
            else
                throw new ArgumentNullException("admissionDateTime");

            return new Time(hours, minutes);
        }
    }
}