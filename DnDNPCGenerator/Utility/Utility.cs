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
        public static StringBuilder SBuilder { get; } = new StringBuilder();
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
            return (Race)NumberGenerator.Next(MinRoll, Enum.GetNames(typeof(Race)).Length);
        }
        public static Gender GenerateGender()
        {
            return (Gender)NumberGenerator.Next(MinRoll, Enum.GetNames(typeof(Gender)).Length);
        }
        public static string GenerateClass(int str, int dex, int con, int intell, int wis, int chr)
        {
            int[] stats = { str, dex, con, intell, wis, chr };
            int maxValue = stats.Max();
            int maxValueIndex = stats.ToList().IndexOf(maxValue);

            string selected = DNDClass.strength[0];

            //Strength classes
            if (maxValueIndex == 0)
            {
                selected = DNDClass.strength[GenerateNumber(0, DNDClass.strength.Count())];
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
        public static string GenerateName(Race givenRace, Gender givenGender)
        {
            string name = "";
            if (givenGender == Gender.MALE)
            {
                if (givenRace == Race.DRAGONBORN)
                {
                    SBuilder.Append(RaceNames.DragonbornFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.DragonbornFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DragonbornFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.DragonbornFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DragonbornFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.DragonbornFirstNameThirdMaleSyllable.Count())]);
                }
                else if (givenRace == Race.DWARF)
                {
                    SBuilder.Append(RaceNames.DwarfFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.DwarfFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DwarfFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.DwarfFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DwarfFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.DwarfFirstNameThirdMaleSyllable.Count())]);
                }
                else if (givenRace == Race.ELF)
                {
                    SBuilder.Append(RaceNames.ElfFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.ElfFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.ElfFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.ElfFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.ElfFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.ElfFirstNameThirdMaleSyllable.Count())]);
                }
                else if (givenRace == Race.GNOME)
                {
                    SBuilder.Append(RaceNames.GnomeFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.GnomeFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.GnomeFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.GnomeFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.GnomeFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.GnomeFirstNameThirdMaleSyllable.Count())]);
                }
                else if (givenRace == Race.HALF_ELF)
                {
                    SBuilder.Append(RaceNames.HalflingFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameThirdMaleSyllable.Count())]);
                }
                else if (givenRace == Race.HALFLING)
                {
                    SBuilder.Append(RaceNames.HalflingFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameThirdMaleSyllable.Count())]);
                }
                else if (givenRace == Race.HALF_ORC)
                {
                    SBuilder.Append(RaceNames.HalfOrcFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.HalfOrcFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalfOrcFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.HalfOrcFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalfOrcFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.HalfOrcFirstNameThirdMaleSyllable.Count())]);
                }
                else if (givenRace == Race.HUMAN)
                {
                    SBuilder.Append(RaceNames.HumanFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.HumanFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HumanFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.HumanFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HumanFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.HumanFirstNameThirdMaleSyllable.Count())]);
                }
                else
                {
                    SBuilder.Append(RaceNames.TieflingFirstNameFirstMaleSyllable[GenerateNumber(0, RaceNames.TieflingFirstNameFirstMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.TieflingFirstNameSecondMaleSyllable[GenerateNumber(0, RaceNames.TieflingFirstNameSecondMaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.TieflingFirstNameThirdMaleSyllable[GenerateNumber(0, RaceNames.TieflingFirstNameThirdMaleSyllable.Count())]);
                }
            }
            else
            {
                if (givenRace == Race.DRAGONBORN)
                {
                    SBuilder.Append(RaceNames.DragonbornFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.DragonbornFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DragonbornFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.DragonbornFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DragonbornFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.DragonbornFirstNameThirdFemaleSyllable.Count())]);
                }
                else if (givenRace == Race.DWARF)
                {
                    SBuilder.Append(RaceNames.DwarfFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.DwarfFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DwarfFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.DwarfFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.DwarfFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.DwarfFirstNameThirdFemaleSyllable.Count())]);
                }
                else if (givenRace == Race.ELF)
                {
                    SBuilder.Append(RaceNames.ElfFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.ElfFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.ElfFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.ElfFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.ElfFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.ElfFirstNameThirdFemaleSyllable.Count())]);
                }
                else if (givenRace == Race.GNOME)
                {
                    SBuilder.Append(RaceNames.GnomeFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.GnomeFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.GnomeFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.GnomeFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.GnomeFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.GnomeFirstNameThirdFemaleSyllable.Count())]);
                }
                else if (givenRace == Race.HALF_ELF)
                {
                    SBuilder.Append(RaceNames.HalflingFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameThirdFemaleSyllable.Count())]);
                }
                else if (givenRace == Race.HALFLING)
                {
                    SBuilder.Append(RaceNames.HalflingFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalflingFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.HalflingFirstNameThirdFemaleSyllable.Count())]);
                }
                else if (givenRace == Race.HALF_ORC)
                {
                    SBuilder.Append(RaceNames.HalfOrcFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.HalfOrcFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalfOrcFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.HalfOrcFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HalfOrcFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.HalfOrcFirstNameThirdFemaleSyllable.Count())]);
                }
                else if (givenRace == Race.HUMAN)
                {
                    SBuilder.Append(RaceNames.HumanFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.HumanFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HumanFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.HumanFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.HumanFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.HumanFirstNameThirdFemaleSyllable.Count())]);
                }
                else
                {
                    SBuilder.Append(RaceNames.TieflingFirstNameFirstFemaleSyllable[GenerateNumber(0, RaceNames.TieflingFirstNameFirstFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.TieflingFirstNameSecondFemaleSyllable[GenerateNumber(0, RaceNames.TieflingFirstNameSecondFemaleSyllable.Count())]);
                    SBuilder.Append(RaceNames.TieflingFirstNameThirdFemaleSyllable[GenerateNumber(0, RaceNames.TieflingFirstNameThirdFemaleSyllable.Count())]);
                }
            }

            name = SBuilder.ToString();
            name = name != "" ? name.First().ToString().ToUpper() + name.Substring(1) : "";
            SBuilder.Clear();
            return name == "" ? "Spoink" : name;
        }
    }
}
