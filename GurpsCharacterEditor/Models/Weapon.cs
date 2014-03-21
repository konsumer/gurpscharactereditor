namespace GurpsCharacterEditor.Models
{
    public class Weapon : Item
    {
        public int MinimumStrength { get; set; }

        public Weapon()
            : base()
        {
        }

        public Weapon(string name, int value, int weight)
            : base(name, value, weight)
        {
            MinimumStrength = 0;
        }
    }
}
