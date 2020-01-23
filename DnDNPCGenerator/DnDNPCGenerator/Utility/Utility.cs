using DnDNPCGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDNPCGenerator.Structs;

namespace DnDNPCGenerator.Utility
{
    public static class Utility
    {
        public static Random NumberGenerator { get; } = new Random();
        public static int MaxRollExculsive { get; } = 7;
        public static int MinRoll { get; } = 1;

        public static int GenerateNumber(int minRoll, int maxRoll)
        {
            return NumberGenerator.Next(minRoll, maxRoll);
        }
        public static int GenerateStatistic()
        {
            int stat = 0;
            int lowest = 6;
            for (int i = 0; i < 4; i++)
            {
                int currentRoll = NumberGenerator.Next(MinRoll, MaxRollExculsive);
                stat += currentRoll;
                if (currentRoll < lowest)
                {
                    lowest = currentRoll;
                }
            }
            stat = stat - lowest;
            return stat;
        }
        public static Race GenerateRace()
        {
            return (Race)NumberGenerator.Next(MinRoll,Enum.GetNames(typeof(Race)).Length);
        }
        //Edit later to utilize stats when determining class
        public static string GenerateClass()
        {
            string selected = "";


            return selected;
        }
        public static string GenerateClass(int str, int dex, int con, int intell, int wis, int chr)
        {
            int[] stats = { str, dex, con, intell, wis, chr };
            int maxValue = stats.Max();
            int maxValueIndex = stats.ToList().IndexOf(maxValue);

            string selected = DNDClass.strength[0];
            
            //Strength classes
            if(maxValueIndex == 0)
            {
                selected = DNDClass.strength[GenerateNumber(0,DNDClass.strength.Count())];
            }
            else if (maxValueIndex == 1)
            {
                selected = DNDClass.dexterity[GenerateNumber(0, DNDClass.dexterity.Count())];
            }
            else if (maxValueIndex == 2)
            {
                selected = DNDClass.constitution[GenerateNumber(0, DNDClass.constitution.Count())];
            }
            else if (maxValueIndex == 3)
            {
                selected = DNDClass.intelligence[GenerateNumber(0, DNDClass.intelligence.Count())];
            }
            else if (maxValueIndex == 4)
            {
                selected = DNDClass.wisdom[GenerateNumber(0, DNDClass.wisdom.Count())];
            }
            else
            {
                selected = DNDClass.charisma[GenerateNumber(0, DNDClass.charisma.Count())];
            }


            return selected;
        }
        public static Alignment GenerateAlignment()
        {
            return (Alignment)NumberGenerator.Next(MinRoll, Enum.GetNames(typeof(Alignment)).Length);
        }
    }
}
