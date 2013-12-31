namespace GurpsCharacterEditor.Models
{
    // This enum is used to denote the difficulty of a skill.
    public enum SkillDifficulty { Easy, Average, Hard, VeryHard };

    // This enum is used to specify which stat a skill is based on.
    public enum SkillStat { Strength, Dexterity, Intelligence, Health }

    public class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // The stat this skill is based on.
        public SkillStat Stat { get; set; }

        // The difficulty of the skill
        public SkillDifficulty Difficulty { get; set; }

        // The skill level relative to the base skill level.
        public int? RelativeLevel { get; set; }

        // The number of character points the training of this level is worth.
        public int Points
        {
            get
            {
                // If not learned, then 0 points are spent.
                if (RelativeLevel == null)
                    return 0;

                // Compensate for skill difficulty.
                int level = (int)RelativeLevel;
                switch (Difficulty)
                {
                    case SkillDifficulty.Average:
                        level += 1;
                        break;
                    case SkillDifficulty.Hard:
                        level += 2;
                        break;
                    case SkillDifficulty.VeryHard:
                        level += 3;
                        break;
                }

                // Calculate number of points spent if difficulty is easy.
                int points = 0;
                if (level == 0)
                    points = 1;
                if (level == 1)
                    points = 2;
                if (level > 1)
                    points = 4 * (level - 1);

                return points;
            }
        }

        // The effective skill level.
        public int? Level(Character character)
        {
            // If skill is not learned, skill level is not applicable.
            if (RelativeLevel == null)
                return null;
            else
            {
                // Add base skill level to relative level.
                switch (Stat)
                {
                    case SkillStat.Strength:
                        return character.Strength + (int)RelativeLevel;
                    case SkillStat.Dexterity:
                        return character.Dexterity + (int)RelativeLevel;
                    case SkillStat.Intelligence:
                        return character.Intelligence + (int)RelativeLevel;
                    case SkillStat.Health:
                        return character.Health + (int)RelativeLevel;
                    default:
                        return null;
                }
            }
        }

        public Skill() {
            Name = "";
            RelativeLevel = null;
        }

        public Skill(string name, string description, SkillStat stat, SkillDifficulty difficulty)
        {
            Name = name;
            Description = description;
            Stat = stat;
            Difficulty = difficulty;
            RelativeLevel = null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
