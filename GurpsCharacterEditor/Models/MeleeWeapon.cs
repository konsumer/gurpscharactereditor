namespace GurpsCharacterEditor.Models
{
    public class MeleeWeapon : Weapon
    {
        public int Reach { get; set; }
        public bool CloseCombat { get; set; }
        public int Parry { get; set; }

        public MeleeWeapon()
            : base()
        {
            Reach = 0;
            CloseCombat = true;
            Parry = 0;
        }

        public MeleeWeapon(string name, int value, int weight)
            : base(name, value, weight)
        {
            Reach = 0;
            CloseCombat = true;
            Parry = 0;
        }
    }
}
