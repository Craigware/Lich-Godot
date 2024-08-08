using Godot;

namespace Entities
{
    enum WeaponType {
        Dagger,
        Sword, 
        Bow,
        Staff
    }
    [GlobalClass]
    public partial class Weapon : Item 
    {
        public float Damage;
        public float ManaDrain;
        public float StaminaDrain;
        public float AttackRate;
        public float AttackRadius;
        public AttackEffect WeaponEffectID;

        public Weapon() : this(0,0,0,0,0,"Weapon", null) {}
        public Weapon(
            float damage,
            float manaDrain,
            float staminaDrain,
            float attackRate,
            float attackRadius,
            string name,
            Texture2D icon,
            AttackEffect weaponEffectId=0
        ) : base(name, icon) {
            Damage = damage;
            ManaDrain = manaDrain;
            StaminaDrain = staminaDrain;
            AttackRate = attackRate;
            WeaponEffectID = weaponEffectId;
            AttackRadius = attackRadius;
        }
    }
}