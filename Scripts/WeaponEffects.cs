using Godot;

namespace Entities
{
    public enum AttackEffect {
        NORMAL
    }

    public static class Attacks {
        public static void UseEffect(Weapon weapon, Node target) {
            if (target is not DynamicEntity or StaticEntity) throw new System.Exception("Attempted to use effect on non entity type.");
            
            switch (weapon.WeaponEffectID) {
                case AttackEffect.NORMAL:
                    if (target is DynamicEntity d) {
                        d.Hurt(weapon.Damage);
                    }
                    
                    if (target is StaticEntity s) {
                    }
                    return;
            }
        }

        public static void UseEffect(Weapon weapon, Vector2 position) {
            switch(weapon.WeaponEffectID) {
                case AttackEffect.NORMAL:
                    break;
            }
        }
    }
}