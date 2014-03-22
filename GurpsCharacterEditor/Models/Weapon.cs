namespace GurpsCharacterEditor.Models
{
    public class Weapon : Item
    {
        public int MinimumStrength { get; set; }

        public Weapon()
            : base()
        {
            MinimumStrength = 0;
        }

        public Weapon(string name, int value, int weight)
            : base(name, value, weight)
        {
            MinimumStrength = 0;
        }
    }
}
