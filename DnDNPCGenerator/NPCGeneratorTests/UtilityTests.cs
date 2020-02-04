using DnDNPCGenerator.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPCGeneratorTests
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void GenerateNumber_GivenMinAndMaxValues_GeneratesNumberBetweenGivenValues()
        {
            int minValue = 0;
            int maxValue = 10;
            bool expected = true;
            
            int result = Utility.GenerateNumber(minValue, maxValue);

            bool actual = result >= minValue && result < maxValue;
            Console.WriteLine("Min: " +minValue + "\nMax: "+maxValue + "\nResult: " + result);
            Assert.AreEqual(expected, actual, "Random number was outside of the given range of integers");
        }

        [TestMethod]
        public void GenerateClass_GivenHighestStatisticIsIntelligence_GeneratesWizard()
        {
            int str = 5;
            int dex = 5;
            int con = 5;
            int intell = 15;
            int wis = 5;
            int chr = 5;
            string expected = "Wizard";

            string actual = Utility.GenerateClass(str, dex, con, intell, wis, chr);

            Assert.AreEqual(expected, actual, "A wizard was not generated.");
        }

    }
}
