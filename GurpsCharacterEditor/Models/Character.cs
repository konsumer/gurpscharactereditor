using System;
using System.Collections.ObjectModel;

namespace GurpsCharacterEditor.Models
{
    // This class represents a GURPS character
    public class Character
    {
        public string Name { get; set; }

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

        public int Strength
        {
            get
            {
                return StrengthPoints;
            }
        }
        public int Dexterity
        {
            get
            {
                return DexterityPoints;
            }
        }
        public int Intelligence
        {
            get
            {
                return IntelligencePoints;
            }
        }
        public int Health
        {
            get
            {
                return HealthPoints;
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

        public Character()
        {
            StrengthPoints = 10;
            DexterityPoints = 10;
            IntelligencePoints = 10;
            HealthPoints = 10;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
