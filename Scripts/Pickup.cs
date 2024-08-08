using Godot;

namespace Entities 
{
	[GlobalClass]
	public partial class Pickup : EtherialEntity
	{
		[Export] Item pickupItem;

        public Pickup() : this(null, Vector2.Zero) {}
        public Pickup(Item pickup, Vector2 position) {
            if (pickup == null) return;
            pickupItem = pickup;
            pickupItem.Sprite ??= new PlaceholderTexture2D() {
                    Size = new(8,8)
                };

            Sprite2D sprite = new() {
                Texture = pickup.Sprite
            };

            CollisionShape2D col = new() {
                Shape = new CircleShape2D() {
                    Radius = 8
                }
            };

            AddChild(sprite);
            AddChild(col);
            Position = position;
        }


        public override void SteppedOn(Node2D node) {
            if (node is PlayerEntity p) {
                p.Inventory.Add(pickupItem);
                QueueFree();
            }
        }
	}
}
