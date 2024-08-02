using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Stats : Resource 
    {
        [Export] public int Health;
        [Export] public int Stamina;
        [Export] public int Mana;
        [Export] public int MoveSpeed;

        public Stats() : this(0,0,0,0) {}
        public Stats(
            int health,
            int stamina,
            int mana,
            int movespeed
        ){
            Health = health;
            MoveSpeed = movespeed;
            Mana = mana;
            Stamina = stamina;
        }
    }
}