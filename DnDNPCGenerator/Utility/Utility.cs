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
            int syllableNumber = GenerateNumber(1,5);
            if (givenGender == Gender.MALE)
            {
                if (givenRace == Race.DRAGONBORN)
                {
                    for(int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.DragonbornFirstNameMaleSyllables[GenerateNumber(0, RaceNames.DragonbornFirstNameMaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.DWARF)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.DwarfFirstNameMaleSyllables[GenerateNumber(0, RaceNames.DwarfFirstNameMaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.ELF)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.ElfFirstNameMaleSyllables[GenerateNumber(0, RaceNames.ElfFirstNameMaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.GNOME)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.GnomeFirstNameMaleSyllables[GenerateNumber(0, RaceNames.GnomeFirstNameMaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HALF_ELF)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HalfElfFirstNameMaleSyllables[GenerateNumber(0, RaceNames.HalfElfFirstNameMaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HALFLING)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HalflingFirstNameMaleSyllables[GenerateNumber(0, RaceNames.HalflingFirstNameMaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HALF_ORC)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HalfOrcFirstNameMaleSyllables[GenerateNumber(0, RaceNames.HalfOrcFirstNameMaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HUMAN)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HumanFirstNameMaleSyllables[GenerateNumber(0, RaceNames.HumanFirstNameMaleSyllables.Count())]);
                    }
                }
                else
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.TieflingFirstNameMaleSyllables[GenerateNumber(0, RaceNames.TieflingFirstNameMaleSyllables.Count())]);
                    }
                }
            }
            else
            {
                if (givenRace == Race.DRAGONBORN)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.DragonbornFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.DragonbornFirstNameFemaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.DWARF)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.DwarfFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.DwarfFirstNameFemaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.ELF)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.ElfFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.ElfFirstNameFemaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.GNOME)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.GnomeFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.GnomeFirstNameFemaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HALF_ELF)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HalfElfFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.HalfElfFirstNameFemaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HALFLING)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HalflingFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.HalflingFirstNameFemaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HALF_ORC)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HalfOrcFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.HalfOrcFirstNameFemaleSyllables.Count())]);
                    }
                }
                else if (givenRace == Race.HUMAN)
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.HumanFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.HumanFirstNameFemaleSyllables.Count())]);
                    }
                }
                else
                {
                    for (int i = 0; i < syllableNumber; i++)
                    {
                        SBuilder.Append(RaceNames.TieflingFirstNameFemaleSyllables[GenerateNumber(0, RaceNames.TieflingFirstNameFemaleSyllables.Count())]);
                    }
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
