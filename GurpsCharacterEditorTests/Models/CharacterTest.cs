using GurpsCharacterEditor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GurpsEditorTests.Models
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void CharacterMaxHP()
        {
            Character target = new Character();
            target.StrengthPoints = 12;
            target.MaxHPPoints = 3;

            Assert.AreEqual(15, target.MaxHP);
        }

        [TestMethod]
        public void CharacterMaxFP()
        {
            Character target = new Character();
            target.HealthPoints = 12;
            target.MaxFPPoints = 3;

            Assert.AreEqual(15, target.MaxFP);
        }

        [TestMethod]
        public void CharacterWillpower()
        {
            Character target = new Character();
            target.IntelligencePoints = 12;
            target.WillpowerPoints = 3;

            Assert.AreEqual(15, target.Willpower);
        }

        [TestMethod]
        public void CharacterPerception()
        {
            Character target = new Character();
            target.IntelligencePoints = 12;
            target.PerceptionPoints = 3;

            Assert.AreEqual(15, target.Perception);
        }

        [TestMethod]
        public void CharacterBasicLiftBelow10()
        {
            Character target = new Character();
            target.StrengthPoints = 5;

            Assert.AreEqual(5F, target.BasicLift);
        }

        [TestMethod]
        public void CharacterBasicLiftAbove10()
        {
            Character target = new Character();
            target.StrengthPoints = 12;

            Assert.AreEqual(29F, target.BasicLift);
        }

        [TestMethod]
        public void CharacterBasicSpeed()
        {
            Character target = new Character();
            target.HealthPoints = 11;
            target.DexterityPoints = 11;

            Assert.AreEqual(5.5F, target.BasicSpeed);

            target.BasicSpeedPoints = 0.75F;

            Assert.AreEqual(6.25F, target.BasicSpeed);
        }

        [TestMethod]
        public void CharacterBasicMove()
        {
            Character target = new Character();
            target.HealthPoints = 11;
            target.DexterityPoints = 11;
            target.BasicSpeedPoints = 0.75F;

            Assert.AreEqual(6.25F, target.BasicSpeed);
            Assert.AreEqual(6, target.BasicMove);
        }

        [TestMethod]
        public void CharacterTotalWeight()
        {
            Character target = new Character();
            target.Inventory.Add(new Item("Item 1", 1, 3));
            target.Inventory.Add(new Item("Item 2", 1, 7));
            target.Inventory.Add(new Item("Item 3", 1, 4));

            Assert.AreEqual(14, target.TotalWeight);
        }
    }
}
