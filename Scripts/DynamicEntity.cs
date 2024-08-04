using Godot;

namespace Entities
{
	[Tool]
	[GlobalClass]
	public partial class DynamicEntity : CharacterBody2D 
	{
		[Export] public Entity Entity;
		[Export] public bool IsAlive;
		[Export] public Inventory Inventory;
		public bool Selected;
		public Stats CurrentStats;
		Sprite2D Sprite;

		public override void _Ready() {
			Sprite = GetNode<Sprite2D>("Sprite");

			if (Sprite == null) {
				Sprite = new();
				AddChild(Sprite);
			}
		
			Sprite.Texture = Entity.SpriteSheet;
		}

		public override void _Input(InputEvent @event) {
    	}

		public override void _PhysicsProcess(double delta) {
    	}
	}
}