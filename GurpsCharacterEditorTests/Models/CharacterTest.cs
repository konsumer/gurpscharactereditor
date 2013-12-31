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
            target.StrengthPoints = 2;
            target.MaxHPPoints = 3;

            Assert.AreEqual(15, target.MaxHP);
        }

        [TestMethod]
        public void CharacterMaxFP()
        {
            Character target = new Character();
            target.HealthPoints = 2;
            target.MaxFPPoints = 3;

            Assert.AreEqual(15, target.MaxFP);
        }

        [TestMethod]
        public void CharacterWillpower()
        {
            Character target = new Character();
            target.IntelligencePoints = 2;
            target.WillpowerPoints = 3;

            Assert.AreEqual(15, target.Willpower);
        }

        [TestMethod]
        public void CharacterPerception()
        {
            Character target = new Character();
            target.IntelligencePoints = 2;
            target.PerceptionPoints = 3;

            Assert.AreEqual(15, target.Perception);
        }

        [TestMethod]
        public void CharacterBasicLiftBelow10()
        {
            Character target = new Character();
            target.StrengthPoints = -5;

            Assert.AreEqual(5F, target.BasicLift);
        }

        [TestMethod]
        public void CharacterBasicLiftAbove10()
        {
            Character target = new Character();
            target.StrengthPoints = 2;

            Assert.AreEqual(29F, target.BasicLift);
        }

        [TestMethod]
        public void CharacterBasicSpeed()
        {
            Character target = new Character();
            target.HealthPoints = 1;
            target.DexterityPoints = 1;

            Assert.AreEqual(5.5F, target.BasicSpeed);

            target.BasicSpeedPoints = 0.75F;

            Assert.AreEqual(6.25F, target.BasicSpeed);
        }

        [TestMethod]
        public void CharacterBasicMove()
        {
            Character target = new Character();
            target.HealthPoints = 1;
            target.DexterityPoints = 1;
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

        [TestMethod]
        public void CharacterPointsPrimarySkill()
        {
            Character target = new Character();

            target.StrengthPoints = 1;
            target.IntelligencePoints = 0;
            target.DexterityPoints = 2;
            target.HealthPoints = 0;
            Assert.AreEqual(50, target.CharacterPointsPrimarySkill);

            target.StrengthPoints = 0;
            target.IntelligencePoints = 2;
            target.DexterityPoints = 0;
            target.HealthPoints = 3;
            Assert.AreEqual(70, target.CharacterPointsPrimarySkill);
        }

        [TestMethod]
        public void CharacterPointsSecondarySkill()
        {
            Character target = new Character();
            target.MaxHPPoints = 3;
            Assert.AreEqual(6, target.CharacterPointsSecondarySkill);

            target = new Character();
            target.WillpowerPoints = 2;
            Assert.AreEqual(10, target.CharacterPointsSecondarySkill);

            target = new Character();
            target.PerceptionPoints = 3;
            Assert.AreEqual(15, target.CharacterPointsSecondarySkill);

            target = new Character();
            target.MaxFPPoints = 2;
            Assert.AreEqual(6, target.CharacterPointsSecondarySkill);
        }

        [TestMethod]
        public void CharacterPointsAdvantages()
        {
            Character target = new Character();
            target.Advantages.Add(new Advantage("Advantage", 23));
            target.Advantages.Add(new Advantage("Disadvantage", -11));
            Assert.AreEqual(12, target.CharacterPointsAdvantages);
        }

        [TestMethod]
        public void CharacterPointsSkills()
        {
            Character character = new Character();
            character.StrengthPoints = 1;
            character.DexterityPoints = 2;
            character.IntelligencePoints = 3;
            character.HealthPoints = 4;

            Skill skill;

            Character target = new Character();
            skill = new Skill("abc", SkillStat.Intelligence, SkillDifficulty.Easy);
            skill.RelativeLevel = 2;
            target.Skills.Add(skill);
            skill = new Skill("def", SkillStat.Dexterity, SkillDifficulty.Average);
            skill.RelativeLevel = 0;
            target.Skills.Add(skill);
            skill = new Skill("ghi", SkillStat.Health, SkillDifficulty.VeryHard);
            skill.RelativeLevel = -1;
            target.Skills.Add(skill);
            skill = new Skill("jkl", SkillStat.Strength, SkillDifficulty.Hard);
            skill.RelativeLevel = 3;
            target.Skills.Add(skill);
            Assert.AreEqual(4 + 2 + 4 + 16, target.CharacterPointsSkills);
        }
    }
}
