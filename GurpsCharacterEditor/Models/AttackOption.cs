using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsCharacterEditor.Models
{
    // This enum represent what kind of attack can be done with a particular
    // weapon.
    public enum AttackType { Swinging, Thrusting };

    // This enum represents what kinds of injury/effect an attack with a
    // particular weapon can cause.
    public enum DamageType { Affliction, Burning, Corrosion, Crushing, Cutting, Fatigue, Impaling, SmallPiercing, Piercing, LargePiercing, HugePiercing, Toxic, Special };

    // This class represents a particular way an item can be used to attack.
    // For example a sword can be swung or thrusted. Each case would be
    // represented with an AttackOption object.
    public class AttackOption
    {
        public bool IsStrengthBased { get; set; }

        // Damage for strength-based weapons (e.g. thr+1)
        public AttackType StrengthBasedAttackType { get; set; }
        public int StrengthBasedAttackTypeModifier { get; set; }

        public DamageType DamageType { get; set; }

        public List<int> Reach { get; set; }
        public bool ReachCloseCombat { get; set; }

        public int Parry { get; set; }
        public bool ParryFencing { get; set; }
        public bool ParryUnbalanced { get; set; }
    }
}
