using System;
using Godot;

namespace Entities
{
    public enum PlayerState {
        IDLE,
        MOVING,
        ROLLING
    }

    [GlobalClass]
    public partial class PlayerEntity : DynamicEntity 
    {
        PlayerState playerState;
		public Inventory Inventory;

        public override void _Ready() {
            base._Ready();
        }

        public override void _Input(InputEvent @event){
            if (Input.IsActionJustReleased("Roll")) {
                if (playerState != PlayerState.ROLLING) {
                    Velocity = Facing * Entity.BaseStats.MoveSpeed * 2f;
                    playerState = PlayerState.ROLLING;
                }
            }
        }

        public override void _PhysicsProcess(double delta) {
            var inputVector = Input.GetVector("Left", "Right", "Up", "Down");

            if (inputVector != Vector2.Zero && playerState != PlayerState.ROLLING) {
                Facing = inputVector;
                CurrentStats.MoveSpeed = Math.Clamp(CurrentStats.MoveSpeed + Entity.BaseStats.MoveSpeedRamp * (float)delta, 0, Entity.BaseStats.MoveSpeed);
                Velocity = inputVector * CurrentStats.MoveSpeed;
            } else {
                CurrentStats.MoveSpeed = Math.Clamp(CurrentStats.MoveSpeed - Entity.BaseStats.MoveSpeedRamp * (float)delta, 0, Entity.BaseStats.MoveSpeed); 
                Velocity = Velocity.MoveToward(Vector2.Zero, Entity.BaseStats.Friction);
                if (Velocity == Vector2.Zero) {
                    playerState = PlayerState.IDLE;
                }
            }
            MoveAndSlide();
            // MoveAndCollide(Velocity * (float)delta);
        }
    }
}