using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class TransportLocation : EtherialEntity
    {
        [Export] TransportLocation To;
        bool JustUsed = false;

        public override void _Ready()
        {
            base._Ready();
            BodyExited += ResetTransportLoc;
        }

        public void ResetTransportLoc(Node2D node) {
            JustUsed = false;
        }

        public override void SteppedOn(Node2D node) {
            if (JustUsed) return;
            To.JustUsed = true;
            node.Position = To.GlobalPosition;
        }
    }
}