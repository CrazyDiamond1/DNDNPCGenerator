using DnDNPCGenerator.Enums;
using DnDNPCGenerator.Utility;
using System;

namespace DnDNPCGenerator.Models
{
    [Serializable()]
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
        //public byte[] ImageBytes { get; set; }
        public Character()
        {
            Strength = Utility.Generator.GenerateStatistic();
            Dexterity = Utility.Generator.GenerateStatistic();
            Constitution = Utility.Generator.GenerateStatistic();
            Intelligence = Utility.Generator.GenerateStatistic();
            Wisdom = Utility.Generator.GenerateStatistic();
            Charisma = Utility.Generator.GenerateStatistic();
            Race = Utility.Generator.GenerateRace();
            Gender = Utility.Generator.GenerateGender();
            Name = Utility.Generator.GenerateName(Race, Gender);
            DnDClass = Utility.Generator.GenerateClass(Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
            Alignment = Utility.Generator.GenerateAlignment();
            //string alignmenthalf = Alignment.ToString().Split('_')[1];
            //ImageBytes = Utility.Utility.GetCharacterImage(Gender, Race, DnDClass, alignmenthalf);
        }
    }
}
