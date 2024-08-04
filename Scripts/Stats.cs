using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Stats : Resource 
    {
        [Export] public float Health;
        [Export] public float Stamina;
        [Export] public float Mana;
        
        [Export] public float Friction;
        [Export] public float MoveSpeedRamp;
        [Export] public float MoveSpeed;

        public Stats() : this(0,0,0,0,0,0) {}
        public Stats(
            float health,
            float stamina,
            float mana,
            float friction,
            float movespeedramp,
            float movespeed
        ){
            Health = health;
            Friction = friction;
            MoveSpeedRamp = movespeedramp;
            MoveSpeed = movespeed;
            Mana = mana;
            Stamina = stamina;
        }

        public string ToString(string label) {
            string message = label;
            message += "\n    Health: " + Health;
            message += "\n    Stamina: " + Stamina;
            message += "\n    Mana: " + Mana;
            message += "\n    Friction: " + Friction;
            message += "\n    MoveSpeedRamp: " + MoveSpeedRamp;
            message += "\n    MoveSpeed: " + MoveSpeed;
            return message;
        }

        public override string ToString()
        {
            return ToString("Statistics");
        }
    }
}