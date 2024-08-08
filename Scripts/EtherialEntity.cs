using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class EtherialEntity : Area2D 
    {
        public override void _Ready() {
            BodyEntered += SteppedOn;
        }

        public virtual void SteppedOn(Node2D node) {}
    }
}