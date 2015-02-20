using System;
using System.Collections.ObjectModel;

namespace GurpsCharacterEditor.Models
{
    // This class represents a GURPS character.
    public class Character
    {
        public string Name { get; set; }

        // The Points properties contains the number of points to be
        // added/subtracted from the base value of the stat, thus acting
        // as a modifier.
        //
        // For example the base value of Strength is 10. If StrengthPoints
        // is 3, then the effective Strength is 13.
        public int StrengthPoints { get; set; }
        public int DexterityPoints { get; set; }
        public int IntelligencePoints { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHPPoints { get; set; }
        public int MaxFPPoints { get; set; }
        public int PerceptionPoints { get; set; }
        public int WillpowerPoints { get; set; }
        public float BasicSpeedPoints { get; set; }
        public int BasicMovePoints { get; set; }

        // These read-only properties returns the effective value of the stats.
        public int Strength
        {
            get
            {
                return 10 + StrengthPoints;
            }
        }
        public int Dexterity
        {
            get
            {
                return 10 + DexterityPoints;
            }
        }
        public int Intelligence
        {
            get
            {
                return 10 + IntelligencePoints;
            }
        }
        public int Health
        {
            get
            {
                return 10 + HealthPoints;
            }
        }
        public int MaxHP
        {
            get
            {
                return MaxHPPoints + Strength;
            }
        }
        public int MaxFP
        {
            get
            {
                return MaxFPPoints + Health;
            }
        }
        public int Willpower
        {
            get
            {
                return WillpowerPoints + Intelligence;
            }
        }
        public int Perception
        {
            get
            {
                return PerceptionPoints + Intelligence;
            }
        }
        public float BasicLift
        {
            get
            {
                float bl = Strength * Strength / 5F;
                if (bl >= 10)
                    bl = (float)Math.Round(bl);
                return bl;
            }
        }
        public float BasicSpeed
        {
            get
            {
                float bs = (Health + Dexterity) / 4F;
                return bs + BasicSpeedPoints;
            }
        }
        public int BasicMove
        {
            get
            {
                int bm = (int)Math.Floor(BasicSpeed);
                return bm + BasicMovePoints;
            }
        }
        public int Move
        {
            get
            {
                if (Encumbrance.HasValue)
                    return Math.Max(BasicMove - (int)Encumbrance, 1);
                else
                    return 0;
            }
        }

        // Inventory of the character.
        private ObservableCollection<Item> inventory = new ObservableCollection<Item>();
        public ObservableCollection<Item> Inventory
        {
            get
            {
                return inventory;
            }
        }
        public int TotalWeight
        {
            get
            {
                int w = 0;
                foreach (Item item in Inventory)
                    w += item.Weight;
                return w;
            }
        }
        public int? Encumbrance
        {
            get
            {
                float bl = BasicLift;
                float weight = TotalWeight;

                if (weight <= bl) return 0;
                if (weight <= 2 * bl) return 1;
                if (weight <= 3 * bl) return 2;
                if (weight <= 6 * bl) return 3;
                if (weight <= 10 * bl) return 4;
                return null;
            }
        }

        // Character advantages and disadvantages
        private ObservableCollection<Advantage> advantages = new ObservableCollection<Advantage>();
        public ObservableCollection<Advantage> Advantages
        {
            get
            {
                return advantages;
            }
        }

        // Character skills
        private ObservableCollection<Skill> skills = new ObservableCollection<Skill>();
        public ObservableCollection<Skill> Skills
        {
            get
            {
                return skills;
            }
        }

        // Calculation of character points spent on this character
        public int CharacterPointsPrimarySkill
        {
            get
            {
                return 10 * StrengthPoints + 20 * IntelligencePoints + 20 * DexterityPoints + 10 * HealthPoints;
            }
        }
        public int CharacterPointsSecondarySkill
        {
            get
            {
                return 2 * MaxHPPoints + 5 * WillpowerPoints + 5 * PerceptionPoints + 3 * MaxFPPoints;
            }
        }
        public int CharacterPointsAdvantages
        {
            get
            {
                int points = 0;
                foreach (Advantage advantage in Advantages)
                {
                    points += advantage.Points;
                }
                return points;
            }
        }
        public int CharacterPointsSkills
        {
            get
            {
                int points = 0;
                foreach (Skill skill in Skills)
                {
                    points += skill.Points;
                }
                return points;
            }
        }
        public int CharacterPoints
        {
            get
            {
                return CharacterPointsPrimarySkill + CharacterPointsSecondarySkill + CharacterPointsAdvantages + CharacterPointsSkills;
            }
        }

        public Character()
        {
        }

        public Character Copy()
        {
            return (Character)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
