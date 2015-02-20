using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
        public int Dodge
        {
            get
            {
                if (Encumbrance.HasValue)
                    return Math.Max((int)Math.Floor(BasicSpeed + 3) - (int)Encumbrance, 1);
                else
                    return 0;
            }
        }
        public Dice ThrustDamage
        {
            get
            {
                int str = Strength;
                if (str <= 40)
                {
                    switch (str / 2)
                    {
                        case 1: return new Dice(1, -6);
                        case 2: return new Dice(1, -5);
                        case 3: return new Dice(1, -4);
                        case 4: return new Dice(1, -3);
                        case 5: return new Dice(1, -2);
                        case 6: return new Dice(1, -1);
                        case 7: return new Dice(1, 0);
                        case 8: return new Dice(1, 1);
                        case 9: return new Dice(1, 2);
                        case 10: return new Dice(2, -1);
                        case 11: return new Dice(2, 0);
                        case 12: return new Dice(2, 1);
                        case 13: return new Dice(2, 2);
                        case 14: return new Dice(3, -1);
                        case 15: return new Dice(3, 0);
                        case 16: return new Dice(3, 1);
                        case 17: return new Dice(3, 2);
                        case 18: return new Dice(4, -1);
                        case 19: return new Dice(4, 0);
                        case 20: return new Dice(4, 1);
                    }
                }
                if (str <= 100)
                {
                    switch((str - 40) / 5)
                    {
                        case 0: return new Dice(4, 1);
                        case 1: return new Dice(5, 0);
                        case 2: return new Dice(5, 2);
                        case 3: return new Dice(6, 0);
                        case 4: return new Dice(7, -1);
                        case 5: return new Dice(7, 1);
                        case 6: return new Dice(8, 0);
                        case 7: return new Dice(8, 2);
                        case 8: return new Dice(9, 0);
                        case 9: return new Dice(9, 2);
                        case 10: return new Dice(10, 0);
                        case 11: return new Dice(10, 2);
                        case 12: return new Dice(11, 0);
                    }
                }
                Debug.Assert(str > 100);
                return new Dice(11 + (str - 100) / 10);
            }
        }
        public Dice SwingDamage
        {
            get
            {
                int str = Strength;
                if (str <= 40)
                {
                    switch (str)
                    {
                        case 1:
                        case 2:
                            return new Dice(1, -5);
                        case 3: 
                        case 4:
                            return new Dice(1, -4);
                        case 5:
                        case 6:
                            return new Dice(1, -3);
                        case 7:
                        case 8:
                            return new Dice(1, -2);
                        case 9:
                            return new Dice(1, -1);
                        case 10:
                            return new Dice(1, 0);
                        case 11:
                            return new Dice(1, 1);
                        case 12: 
                            return new Dice(1, 2);
                        case 13: 
                            return new Dice(2, -1);
                        case 14: 
                            return new Dice(2, 0);
                        case 15: 
                            return new Dice(2, 1);
                        case 16: 
                            return new Dice(2, 2);
                        case 17: 
                            return new Dice(3, -1);
                        case 18: 
                            return new Dice(3, 0);
                        case 19:
                            return new Dice(3, 1);
                        case 20: 
                            return new Dice(3, 2);
                        case 21: 
                            return new Dice(4, -1);
                        case 22:
                            return new Dice(4, 0);
                        case 23:
                            return new Dice(4, 1);
                        case 24: 
                            return new Dice(4, 2);
                        case 25: 
                            return new Dice(5, -1);
                        case 26: 
                            return new Dice(5, 0);
                        case 27:
                        case 28:
                            return new Dice(5, 1);
                        case 29:
                        case 30:
                            return new Dice(5, 2);
                        case 31:
                        case 32:
                            return new Dice(6, -1);
                        case 33:
                        case 34:
                            return new Dice(6, 0);
                        case 35:
                        case 36:
                            return new Dice(6, 1);
                        case 37:
                        case 38:
                            return new Dice(6, 2);
                        case 39:
                        case 40:
                            return new Dice(7, -1);
                    }
                }
                if (str <= 100)
                {
                    switch ((str - 40) / 5)
                    {
                        case 0: return new Dice(7, -1);
                        case 1: return new Dice(7, 1);
                        case 2: return new Dice(8, -1);
                        case 3: return new Dice(8, 1);
                        case 4: return new Dice(9, 0);
                        case 5: return new Dice(9, 2);
                        case 6: return new Dice(10, 0);
                        case 7: return new Dice(10, 2);
                        case 8: return new Dice(11, 0);
                        case 9: return new Dice(11, 2);
                        case 10: return new Dice(12, 0);
                        case 11: return new Dice(12, 2);
                        case 12: return new Dice(13, 0);
                    }
                }
                Debug.Assert(str > 100);
                return new Dice(13 + (str - 100) / 10);
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
