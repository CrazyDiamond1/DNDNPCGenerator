using DnDNPCGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDNPCGenerator.Structs
{
    public struct DNDClassAssigner
    {
        //Strength Classes
        public static List<DNDClass> strength = new List<DNDClass>() { DNDClass.BARBARIAN, DNDClass.FIGHTER, DNDClass.PALADIN, DNDClass.RANGER };
        //Dexterity Classes
        public static List<DNDClass> dexterity = new List<DNDClass>() { DNDClass.BARBARIAN, DNDClass.FIGHTER, DNDClass.MONK, DNDClass.RANGER, DNDClass.ROGUE };
        //Constitution Classes
        public static List<DNDClass> constitution = new List<DNDClass>() { DNDClass.BARBARIAN, DNDClass.FIGHTER };
        //Intelligence Classes
        public static List<DNDClass> intelligence = new List<DNDClass>() { DNDClass.WIZARD };
        //Wisdom Classes
        public static List<DNDClass> wisdom = new List<DNDClass>() { DNDClass.CLERIC, DNDClass.DRUID, DNDClass.MONK, DNDClass.RANGER };
        //Charisma Classes
        public static List<DNDClass> charisma = new List<DNDClass>() { DNDClass.BARD, DNDClass.PALADIN, DNDClass.SORCERER, DNDClass.WARLOCK };
    }
}
