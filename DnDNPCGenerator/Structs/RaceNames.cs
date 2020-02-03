using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDNPCGenerator.Structs
{
    public struct RaceNames
    {
        //Dragonborn Name Syllables
        public static List<string> DragonbornFirstNameFirstMaleSyllable = new List<string>() { "bel", "u", "lu", "dur", "zor", "ne", "a", "yo", "sul", "yor" };
        public static List<string> DragonbornFirstNameSecondMaleSyllable = new List<string>() { "", "ra", "do", "mir", "far", "sa", "sha", "li", "ry", "ro", "wun" };
        public static List<string> DragonbornFirstNameThirdMaleSyllable = new List<string>() { "kas", "gar", "ash", "n", "shi", "zar", "gar", "ax", "th", "ax" };
        public static List<string> DragonbornFirstNameFirstFemaleSyllable = new List<string>() { "ophi", "al", "gri", "esh", "xy", "lil", "ka", "u", "rai", "Wr" };
        public static List<string> DragonbornFirstNameSecondFemaleSyllable = new List<string>() { "", "qor", "yas", "vy", "dri", "cy", "omy", "zit", "rib", "zy", "ag" };
        public static List<string> DragonbornFirstNameThirdFemaleSyllable = new List<string>() { "el", "sa", "s", "sh", "la", "se", "a", "is", "si", "il" };

        //Dwarf Name Syllables
        public static List<string> DwarfFirstNameFirstMaleSyllable = new List<string>() { "um", "eb", "th", "reg", "bar", "bhal", "gry", "bel", "hor", "Br" };
        public static List<string> DwarfFirstNameSecondMaleSyllable = new List<string>() { "", "dr", "d", "ulg", "da", "mi", "thar", "igg", "gr", "gru", "ann" };
        public static List<string> DwarfFirstNameThirdMaleSyllable = new List<string>() { "ak", "ur", "rum", "hr", "n", "m", "s", "on", "um", "ir" };
        public static List<string> DwarfFirstNameFirstFemaleSyllable = new List<string>() { "ne", "gwa", "le", "je", "bo", "bry", "ny", "bri", "bre", "an" };
        public static List<string> DwarfFirstNameSecondFemaleSyllable = new List<string>() { "", "sn", "nl", "sd", "nr", "ndr", "lled", "sth", "ller", "tv", "r" };
        public static List<string> DwarfFirstNameThirdFemaleSyllable = new List<string>() { "is", "in", "ish", "es", "yn", "eth", "iel", "es", "ia", "as" };

        //Elf Name Syllables
        public static List<string> ElfFirstNameFirstMaleSyllable = new List<string>() { "gen", "tra", "lu", "wae", "sar", "fen", "dae", "wran", "cras", "mir" };
        public static List<string> ElfFirstNameSecondMaleSyllable = new List<string>() { "", "yar", "hor", "ri", "stor", "my", "dith", "wra", "xal", "andor", "azum" };
        public static List<string> ElfFirstNameThirdMaleSyllable = new List<string>() { "us", "n", "s", "is", "ar", "as", "ek", "im", "al", "in" };
        public static List<string> ElfFirstNameFirstFemaleSyllable = new List<string>() { "iar", "kri", "fae", "zin", "ara", "yes", "uri", "dae", "chae", "ina" };
        public static List<string> ElfFirstNameSecondFemaleSyllable = new List<string>() { "", "na", "sha", "la", "tri", "qir", "yno", "wyn", "ha", "za", "sy" };
        public static List<string> ElfFirstNameThirdFemaleSyllable = new List<string>() { "la", "na", "na", "s", "elle", "re", "n", "sa", "sha", "lei" };

        //Gnome Name Syllables
        public static List<string> GnomeFirstNameFirstMaleSyllable = new List<string>() { "ron", "ga", "qua", "do", "pana", "cal", "lo", "to", "ipa", "xa"};
        public static List<string> GnomeFirstNameSecondMaleSyllable = new List<string>() { "", "fa", "do", "se", "rle", "vy", "wo", "xi", "ku", "mi", "lsto" };
        public static List<string> GnomeFirstNameThirdMaleSyllable = new List<string>() { "n", "s", "r", "t", "k", "l", "m", "t" };
        public static List<string> GnomeFirstNameFirstFemaleSyllable = new List<string>() { "phi", "zan", "hel", "que", "Nyp", "hes", "in", "car", "cel", "spi" };
        public static List<string> GnomeFirstNameSecondFemaleSyllable = new List<string>() { "", "iqar", "rha", "pi", "qar", "al", "ro", "ri", "my", "gy", "ki" };
        public static List<string> GnomeFirstNameThirdFemaleSyllable = new List<string>() { "za", "yn", "na", "bys", "ne", "fyx", "li", "e", "fi", "bi" };

        //Half-Elf Name Syllables
        public static List<string> HalfElfFirstNameFirstMaleSyllable = new List<string>() { "" };
        public static List<string> HalfElfFirstNameSecondMaleSyllable = new List<string>() { "" };
        public static List<string> HalfElfFirstNameThirdMaleSyllable = new List<string>() { "" };
        public static List<string> HalfElfFirstNameFirstFemaleSyllable = new List<string>() { "" };
        public static List<string> HalfElfFirstNameSecondFemaleSyllable = new List<string>() { "" };
        public static List<string> HalfElfFirstNameThirdFemaleSyllable = new List<string>() { "" };

        //Halfling Name Syllables
        public static List<string> HalflingFirstNameFirstMaleSyllable = new List<string>() { "" };
        public static List<string> HalflingFirstNameSecondMaleSyllable = new List<string>() { "" };
        public static List<string> HalflingFirstNameThirdMaleSyllable = new List<string>() { "" };
        public static List<string> HalflingFirstNameFirstFemaleSyllable = new List<string>() { "" };
        public static List<string> HalflingFirstNameSecondFemaleSyllable = new List<string>() { "" };
        public static List<string> HalflingFirstNameThirdFemaleSyllable = new List<string>() { "" };

        //Half-Orc Name Syllables
        public static List<string> HalfOrcFirstNameFirstMaleSyllable = new List<string>() { "" };
        public static List<string> HalfOrcFirstNameSecondMaleSyllable = new List<string>() { "" };
        public static List<string> HalfOrcFirstNameThirdMaleSyllable = new List<string>() { "" };
        public static List<string> HalfOrcFirstNameFirstFemaleSyllable = new List<string>() { "" };
        public static List<string> HalfOrcFirstNameSecondFemaleSyllable = new List<string>() { "" };
        public static List<string> HalfOrcFirstNameThirdFemaleSyllable = new List<string>() { "" };

        //Human Name Syllables
        public static List<string> HumanFirstNameFirstMaleSyllable = new List<string>() { "" };
        public static List<string> HumanFirstNameSecondMaleSyllable = new List<string>() { "" };
        public static List<string> HumanFirstNameThirdMaleSyllable = new List<string>() { "" };
        public static List<string> HumanFirstNameFirstFemaleSyllable = new List<string>() { "" };
        public static List<string> HumanFirstNameSecondFemaleSyllable = new List<string>() { "" };
        public static List<string> HumanFirstNameThirdFemaleSyllable = new List<string>() { "" };

        //Tiefling Name Syllables
        public static List<string> TieflingFirstNameFirstMaleSyllable = new List<string>() { "" };
        public static List<string> TieflingFirstNameSecondMaleSyllable = new List<string>() { "" };
        public static List<string> TieflingFirstNameThirdMaleSyllable = new List<string>() { "" };
        public static List<string> TieflingFirstNameFirstFemaleSyllable = new List<string>() { "" };
        public static List<string> TieflingFirstNameSecondFemaleSyllable = new List<string>() { "" };
        public static List<string> TieflingFirstNameThirdFemaleSyllable = new List<string>() { "" };
    }
}
