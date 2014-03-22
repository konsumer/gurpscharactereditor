namespace GurpsCharacterEditor.Models
{
    public class RangedWeapon : Weapon
    {
        public int Accuracy { get; set; }
        // TODO: Range
        // TODO: Rate of fire
        // TODO: Shots
        public int Bulk { get; set; }

        public RangedWeapon()
            : base()
        {
            Accuracy = 0;
            Bulk = 0;
        }

        public RangedWeapon(string name, int value, int weight)
            : base(name, value, weight)
        {
            Accuracy = 0;
            Bulk = 0;
        }
    }
}
