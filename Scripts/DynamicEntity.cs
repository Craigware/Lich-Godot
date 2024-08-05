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
        public bool showDebug;

        public override void _Ready() {
            CurrentStats = (Stats)Entity.BaseStats.Duplicate();
            CurrentStats.MoveSpeed = 0;
            showDebug = false;
        }

        public override void _Input(InputEvent @event) {
            if (Input.IsActionJustPressed("ShowDebug")) {
                showDebug = !showDebug;
            }
        }

        public override void _Process(double delta) {
            if (showDebug) {
                var debug = "";
                debug += Entity.Name + "\n";
                debug += Position.Round().ToString();
                HUDDebug(debug);
            } else {
                HUDDebug("");
            }
        }

        public void HUDDebug(string message) {
            var debugScreenText = GetNode<RichTextLabel>("EntityDebug");
            debugScreenText.Text = message;
        }

        public void Debug(string message) {
            GD.Print("Dynamic Entity (" + Entity.Name + "): " + message);
        }

        public void Debug(Variant variant) {
            Debug(variant.ToString());
        }
    }
}