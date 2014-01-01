using Microsoft.VisualStudio.TestTools.UnitTesting;
using GurpsCharacterEditor.Models;

namespace GurpsEditorTests.Models
{
    [TestClass]
    public class SkillTest
    {
        [TestMethod]
        public void SkillPoints()
        {
            Character character = new Character();
            character.StrengthPoints = 1;
            character.DexterityPoints = 2;
            character.IntelligencePoints = 3;
            character.HealthPoints = 4;

            Skill target;

            target = new Skill("abc", "def", SkillStat.Strength, SkillDifficulty.Average);
            Assert.AreEqual(0, target.Points);

            target = new Skill("abc", "def", SkillStat.Intelligence, SkillDifficulty.Easy);
            target.RelativeLevel = 2;
            Assert.AreEqual(4, target.Points);

            target = new Skill("abc", "def", SkillStat.Dexterity, SkillDifficulty.Average);
            target.RelativeLevel = 0;
            Assert.AreEqual(2, target.Points);

            target = new Skill("abc", "def", SkillStat.Health, SkillDifficulty.VeryHard);
            target.RelativeLevel = -1;
            Assert.AreEqual(4, target.Points);

            target = new Skill("abc", "def", SkillStat.Strength, SkillDifficulty.Hard);
            target.RelativeLevel = 3;
            Assert.AreEqual(16, target.Points);
        }

        [TestMethod]
        public void NonDefaultSkillLevel()
        {
            Character character = new Character();
            character.StrengthPoints = 1;
            character.DexterityPoints = 2;
            character.IntelligencePoints = 3;
            character.HealthPoints = 4;

            Skill target;

            target = new Skill("abc", "def", SkillStat.Intelligence, SkillDifficulty.Easy);
            Assert.IsNull(target.Level(character));
            target.RelativeLevel = 2;
            Assert.AreEqual(15, target.Level(character));

            target = new Skill("abc", "def", SkillStat.Dexterity, SkillDifficulty.Average);
            Assert.IsNull(target.Level(character));
            target.RelativeLevel = 0;
            Assert.AreEqual(12, target.Level(character));

            target = new Skill("abc", "def", SkillStat.Health, SkillDifficulty.VeryHard);
            Assert.IsNull(target.Level(character));
            target.RelativeLevel = -1;
            Assert.AreEqual(13, target.Level(character));

            target = new Skill("abc", "def", SkillStat.Strength, SkillDifficulty.Hard);
            Assert.IsNull(target.Level(character));
            target.RelativeLevel = 3;
            Assert.AreEqual(14, target.Level(character));
        }

        [TestMethod]
        public void DefaultSkillLevel()
        {
            Character character = new Character();
            character.StrengthPoints = 1;
            character.DexterityPoints = 2;
            character.IntelligencePoints = 3;
            character.HealthPoints = 4;

            Skill target;

            target = new Skill("abc", "def", SkillStat.Intelligence, SkillDifficulty.Easy);
            target.DefaultRelativeLevel = -4;
            Assert.AreEqual(9, target.Level(character));
        }
    }
}
