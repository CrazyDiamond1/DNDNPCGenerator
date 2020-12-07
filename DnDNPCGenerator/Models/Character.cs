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
        public string Notes { get; set; }
        //public byte[] ImageBytes { get; set; }
        public Character(bool isBlank)
        {
            if (!isBlank)
            {
                Strength = Generator.GenerateStatistic();
                Dexterity = Generator.GenerateStatistic();
                Constitution = Generator.GenerateStatistic();
                Intelligence = Generator.GenerateStatistic();
                Wisdom = Generator.GenerateStatistic();
                Charisma = Generator.GenerateStatistic();
                Race = Generator.GenerateRace();
                Gender = Generator.GenerateGender();
                Name = Generator.GenerateName(Race, Gender);
                DnDClass = Generator.GenerateClass(Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                Alignment = Generator.GenerateAlignment();
                Notes = "";
                //string alignmenthalf = Alignment.ToString().Split('_')[1];
                //ImageBytes = Utility.Utility.GetCharacterImage(Gender, Race, DnDClass, alignmenthalf);
            }
            else
            {
                Strength = 0;
                Dexterity = 0;
                Constitution = 0;
                Intelligence = 0;
                Wisdom = 0;
                Charisma = 0;
                Race = 0;
                Gender = 0;
                Name = "";
                DnDClass = 0;
                Alignment = 0;
                Notes = "";
            }
        }
    }
}
