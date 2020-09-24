using DnDNPCGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDNPCGenerator.Structs;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DnDNPCGenerator.Utility
{
    public static class Utility
    {
        public static Random NumberGenerator { get; } = new Random();
        public static StringBuilder SBuilder { get; } = new StringBuilder();
        public static int MaxRollExculsive { get; } = 7;
        public static int MinRoll { get; } = 0;

        public static int GenerateNumber(int minRoll, int maxRoll)
        {
            return NumberGenerator.Next(minRoll, maxRoll);
        }
        public static int GenerateStatistic(int stat = 0)
        {
            if(stat == 0)
            {
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
            }
            else if(stat > 20)
            {
                stat = 20;
            }
            return stat;
        }
        public static Race GenerateRace()
        {
            return (Race)NumberGenerator.Next(MinRoll, Enum.GetNames(typeof(Race)).Length);
        }
        public static Gender GenerateGender()
        {
            return (Gender)NumberGenerator.Next(0, Enum.GetNames(typeof(Gender)).Length);
        }

        //public static byte[] GetCharacterImage(Gender gender, Race race, string DNDClassAssigner, string alignment)
        //{
        //    string charDescription = gender.ToString() + " " + race.ToString() + " " + DNDClassAssigner + " " + alignment;
        //    string url = GetUrl(GetHtmlCode(charDescription));

        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    var response = (HttpWebResponse)request.GetResponse();

        //    using (Stream dataStream = response.GetResponseStream())
        //    {
        //        if (dataStream == null)
        //            return null;
        //        using (var sr = new BinaryReader(dataStream))
        //        {
        //            byte[] bytes = sr.ReadBytes(100000);

        //            return bytes;
        //        }
        //    }
        //}

        //private static string GetHtmlCode(string characterDescription)
        //{
        //    string url = "https://www.google.com/search?q=" + characterDescription + "&tbm=isch";
        //    string data = "";

        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Accept = "text/html, application/xhtml+xml, */*";
        //    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

        //    var response = (HttpWebResponse)request.GetResponse();

        //    using (Stream dataStream = response.GetResponseStream())
        //    {
        //        if (dataStream == null)
        //            return "";
        //        using (var sr = new StreamReader(dataStream))
        //        {
        //            data = sr.ReadToEnd();
        //        }
        //    }
        //    return data;
        //}

        //private static string GetUrl(string html)
        //{
        //    var urls = "";

        //    string search = @",""ou"":""(.*?)"",";
        //    MatchCollection matches = Regex.Matches(html, search);

        //    urls = matches[0].Groups[1].Value;
        //    return urls;
        //}


        public static DNDClass GenerateClass(int str, int dex, int con, int intell, int wis, int chr)
        {
            int[] stats = { str, dex, con, intell, wis, chr };
            int maxValue = stats.Max();
            int maxValueIndex = stats.ToList().IndexOf(maxValue);

            DNDClass selected = DNDClassAssigner.strength[0];

            //Strength classes
            if (maxValueIndex == 0)
            {
                selected = DNDClassAssigner.strength[GenerateNumber(0, DNDClassAssigner.strength.Count())];
            }
            else if (maxValueIndex == 1)
            {
                selected = DNDClassAssigner.dexterity[GenerateNumber(0, DNDClassAssigner.dexterity.Count())];
            }
            else if (maxValueIndex == 2)
            {
                selected = DNDClassAssigner.constitution[GenerateNumber(0, DNDClassAssigner.constitution.Count())];
            }
            else if (maxValueIndex == 3)
            {
                selected = DNDClassAssigner.intelligence[GenerateNumber(0, DNDClassAssigner.intelligence.Count())];
            }
            else if (maxValueIndex == 4)
            {
                selected = DNDClassAssigner.wisdom[GenerateNumber(0, DNDClassAssigner.wisdom.Count())];
            }
            else
            {
                selected = DNDClassAssigner.charisma[GenerateNumber(0, DNDClassAssigner.charisma.Count())];
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
        public static string EnumToString<T>(T value)
        {
            string valueString = value.ToString();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            valueString = valueString.Replace('_', ' ');
            valueString = valueString.ToLower();
            valueString = myTI.ToTitleCase(valueString);
            return valueString;
        }
    }
}
