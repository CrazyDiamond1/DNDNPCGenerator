using DnDNPCGenerator.Enums;
using DnDNPCGenerator.Utility;

namespace DnDNPCGenerator.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public Race Race { get; set; }
        public Gender Gender { get; set;  }
        public DNDClass DnDClass { get; set; }
        public Alignment Alignment { get; set; }
        public byte[] ImageBytes { get; set; }
        public Character()
        {
            Strength = Utility.Utility.GenerateStatistic();
            Dexterity = Utility.Utility.GenerateStatistic();
            Constitution = Utility.Utility.GenerateStatistic();
            Intelligence = Utility.Utility.GenerateStatistic();
            Wisdom = Utility.Utility.GenerateStatistic();
            Charisma = Utility.Utility.GenerateStatistic();
            Race = Utility.Utility.GenerateRace();
            Gender = Utility.Utility.GenerateGender();
            Name = Utility.Utility.GenerateName(Race, Gender);
            DnDClass = Utility.Utility.GenerateClass(Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
            Alignment = Utility.Utility.GenerateAlignment();
            //string alignmenthalf = Alignment.ToString().Split('_')[1];
            //ImageBytes = Utility.Utility.GetCharacterImage(Gender, Race, DnDClass, alignmenthalf);
        }
    }
}
