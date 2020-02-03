using DnDNPCGenerator.Enums;

namespace DnDNPCGenerator.Models
{
    public class Character
    {
        public string Name { get; private set; }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }
        public Race Race { get; private set; }
        public Gender Gender { get; private set;  }
        public string DnDClass { get; private set; }
        public Alignment Alignment { get; private set; }
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

        }
    }
}
