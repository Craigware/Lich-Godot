using System.Linq;
using Godot;

namespace Entities
{
    [Tool]
    [GlobalClass]
    public partial class DynamicEntity : CharacterBody2D 
    {
        [Export] public Entity Entity;
        [Export] public bool IsAlive;
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

        public override void _Input(InputEvent @event)
        {
            if (Input.IsActionJustPressed("Click")) {
                GD.Print("Dingdong");
            }
        }

        public override void _PhysicsProcess(double delta) {
        }
    }
}