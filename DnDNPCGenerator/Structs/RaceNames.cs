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
        public static List<string> DragonbornFirstNameMaleSyllables = new List<string>() { "bel", "u", "lu", "dur", "zor", "ne", "a", "yo", "sul", "yor", "", "ra", "do", "mir",
            "far", "sa", "sha", "li", "ry", "ro", "wun", "kas", "gar", "ash", "n", "shi", "zar", "gar", "ax", "th", "ax" };
        public static List<string> DragonbornFirstNameFemaleSyllables = new List<string>() { "ophi", "al", "gri", "esh", "xy", "lil", "ka", "u", "rai", "wr", "",
            "qor", "yas", "vy", "dri", "cy", "omy", "zit", "rib", "zy", "ag", "el", "sa", "s", "sh", "la", "se", "a", "is", "si", "il" };

        //Dwarf Name Syllables
        public static List<string> DwarfFirstNameMaleSyllables = new List<string>() { "um", "eb", "th", "reg", "bar", "bhal", "gry", "bel", "hor", "Br", "", "dr", "d", "ulg",
            "da", "mi", "thar", "igg", "gr", "gru", "ann", "ak", "ur", "rum", "hr", "n", "m", "s", "on", "um", "ir" };
        public static List<string> DwarfFirstNameFemaleSyllables = new List<string>() { "ne", "gwa", "le", "je", "bo", "bry", "ny", "bri", "bre", "an", "", "sn", "nl", "sd",
            "nr", "ndr", "lled", "sth", "ller", "tv", "r", "is", "in", "ish", "es", "yn", "eth", "iel", "es", "ia", "as" };

        //Elf Name Syllables
        public static List<string> ElfFirstNameMaleSyllables = new List<string>() { "gen", "tra", "lu", "wae", "sar", "fen", "dae", "wran", "cras", "mir", "", "yar", "hor",
            "ri", "stor", "my", "dith", "wra", "xal", "andor", "azum", "us", "n", "s", "is", "ar", "as", "ek", "im", "al", "in" };
        public static List<string> ElfFirstNameFemaleSyllables = new List<string>() { "iar", "kri", "fae", "zin", "ara", "yes", "uri", "dae", "chae", "ina", "", "na", "sha",
            "la", "tri", "qir", "yno", "wyn", "ha", "za", "sy", "la", "na", "na", "s", "elle", "re", "n", "sa", "sha", "lei" };

        //Gnome Name Syllables
        public static List<string> GnomeFirstNameMaleSyllables = new List<string>() { "ron", "ga", "qua", "do", "pana", "cal", "lo", "to", "ipa", "xa", "", "fa", "do", "se",
            "rle", "vy", "wo", "xi", "ku", "mi", "lsto", "n", "s", "r", "t", "k", "l", "m", "t" };
        public static List<string> GnomeFirstNameFemaleSyllables = new List<string>() { "phi", "zan", "hel", "que", "Nyp", "hes", "in", "car", "cel", "spi", "", "iqar", "rha",
            "pi", "qar", "al", "ro", "ri", "my", "gy", "ki", "za", "yn", "na", "bys", "ne", "fyx", "li", "e", "fi", "bi" };

        //Half-Elf Name Syllables
        public static List<string> HalfElfFirstNameMaleSyllables = new List<string>() { "pan", "yor", "fal", "cra", "dav", "ian", "van", "zan", "syl", "ul", "", "sta", "cra",
            "re", "lum", "qar", "fae", "av", "de", "hom", "min", "er", "es", "ak", "in", "im", "lor", "or", "yr", "ar", "il" };
        public static List<string> HalfElfFirstNameFemaleSyllables = new List<string>() { "saf", "lor", "gif", "coc", "syl", "byn", "del", "oph", "xil", "win", "", "no", "aze",
            "fae", "er", "dia", "dov", "ikil", "zir", "nal", "bell", "a", "nya", "n", "ys", "ne", "e", "ia", "ore", "is" };

        //Halfling Name Syllables
        public static List<string> HalflingFirstNameMaleSyllables = new List<string>() { "la", "san", "dan", "tey", "ori", "fal", "zen", "lar", "ira", "kas", "", "wri", "tra",
            "ri", "nor", "ry", "fer", "sire", "as", "dak", "der", "ck", "et", "umo", "gin" };
        public static List<string> HalflingFirstNameFemaleSyllables = new List<string>() { "mar", "bre", "cal", "dar", "sha", "fen", "una", "yo", "ri", "the", "", "tr", "za",
            "ew", "vi", "ri", "er", "sys", "kis", "ix", "na", "yn", "ra", "s", "a", "ni" };

        //Half-Orc Name Syllables
        public static List<string> HalfOrcFirstNameMaleSyllables = new List<string>() { "tra", "tru", "sar", "mo", "ga", "zev", "gr", "kal", "gar", "kar", "", "a", "o", "u",
            "e", "i", "ruk", "zar", "bar", "kad", "mur", "lar", "rth", "zall", "ash", "gar" };
        public static List<string> HalfOrcFirstNameFemaleSyllables = new List<string>() { "sen", "el", "br", "ke", "sun", "kir", "sin", "sha", "gor", "mo", "", "a", "e", "i",
            "o", "u", "nir", "dur", "mur", "tid", "ume", "shi", "ook", "nur", "zi", "ur"};

        //Human Name Syllables
        public static List<string> HumanFirstNameMaleSyllables = new List<string>() { "zu", "ha", "bre", "kor", "mor", "je", "shi", "rom", "fe", "ton", "", "kh", "me",
            "rdi", "go", "th", "eda", "ch", "an", "r", "rk", "m", "en", "ko", "om", "ulv", "i" };
        public static List<string> HumanFirstNameFemaleSyllables = new List<string>() { "mi", "op", "mal", "nat", "sha", "ja", "fia", "si", "saf", "vi", "ka", "far", "",
            "um", "la", "fi", "tha", "ne", "gr", "oh", "in", "la", "nah", "lo", "vo", "ri", "eth", "ve", "as", "ao", "ra" };

        //Tiefling Name Syllables
        public static List<string> TieflingFirstNameMaleSyllables = new List<string>() { "ark", "ara", "kar", "bar", "fre", "san", "kat", "sha", "dam", "zor", "con", "",
            "ra", "ak", "ly", "ya", "xu", "no", "oon", "is", "ire", "us", "ry", "age", "less", "us", "os", "ity", "or" };
        public static List<string> TieflingFirstNameFemaleSyllables = new List<string>() { "zel", "in", "ea", "ara", "dim", "dax", "agn", "mis", "bel", "ori", "", "l",
            "k", "s", "r", "n", "u", "ia", "ine", "ari", "phis", "eis", "ori", "issa", "ar", "ry", "al" };
    }
}
