using Godot;

namespace Entities
{
    public partial class Stats : Resource 
    {
        public int Health;
        public int Stamina;
        public int Mana;
        public int MoveSpeed;

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