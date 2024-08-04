using Godot;

namespace Entities
{
	[GlobalClass]
	public partial class DynamicEntity : CharacterBody2D 
	{
		[Export] public Entity Entity;
		[Export] public bool IsAlive;
		[Export] public Vector2 Facing;
        public Stats CurrentStats;

        public override void _Ready() {
            CurrentStats = (Stats)Entity.BaseStats.Duplicate();
            CurrentStats.MoveSpeed = 0;
        }

        public void Debug(string message) {
            GD.Print("Dynamic Entity (" + Entity.Name + "): " + message);
        }

        public void Debug(Variant variant) {
            Debug(variant.ToString());
        }
    }
}