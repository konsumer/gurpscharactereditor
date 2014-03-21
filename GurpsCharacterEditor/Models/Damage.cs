namespace GurpsCharacterEditor.Models
{
    public enum DamageBase { Swinging, Thrusting }
    public enum DamageType { Affliction, Burning, Corrosion, Crushing, Cutting, Fatigue, Impaling, SmallPiercing, Piercing, LargePiercing, HugePiercing, Toxic, Special };

    public class Damage
    {
        public DamageBase DamageBase { get; set; }
        public DamageType DamageType { get; set; }

        public Damage(DamageBase damageBase, DamageType damageType)
        {
            DamageBase = damageBase;
            DamageType = damageType;
        }
    }
}
