using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDNPCGenerator.Structs
{
    public struct DNDClass
    {
        //Strength Classes
        public static List<string> strength = new List<string>() { "Barbarian", "Fighter", "Paladin", "Ranger" };
        //Dexterity Classes
        public static List<string> dexterity = new List<string>() { "Barbarian", "Fighter", "Monk", "Ranger", "Rogue" };
        
        //Constitution Classes
        public static List<string> constitution = new List<string>() { "Barbarian", "Fighter" };
        
            //Intelligence Classes
        public static List<string> intelligence = new List<string>() { "Wizard" };
        //Wisdom Classes
        public static List<string> wisdom = new List<string>() { "Cleric", "Druid", "Monk", "Ranger" };
        //Charisma Classes
        public static List<string> charisma = new List<string>() { "Bard", "Paladin", "Sorcerer", "Warlock" };

    }
}
