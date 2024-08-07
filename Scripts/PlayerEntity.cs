using System;
using Godot;

namespace Entities
{
    public enum PlayerState {
        IDLE,
        MOVING,
        ROLLING,
        ATTACKING,
        CHANNELING,
        STUNNED
    }

    [GlobalClass]
    public partial class PlayerEntity : DynamicEntity 
    {
        PlayerState playerState;
		[Export] public Inventory Inventory;

        public override void _Ready() {
            base._Ready();
            if (Inventory == null) {
                Inventory = new();
            }

            Weapon weapon = new(10,0,0,0,1,"Weapon", null, AttackEffect.NORMAL);
            Inventory.AddItemToInventory(weapon);
        }

        public override void _Input(InputEvent @event){
            base._Input(@event);
            if (Input.IsActionJustReleased("Roll")) {
                if (playerState != PlayerState.ROLLING) {
                    Velocity = Facing * Entity.BaseStats.MoveSpeed * 2f;
                    playerState = PlayerState.ROLLING;
                }
            }

            if (Input.IsActionJustPressed("Click")){
                if (Inventory.GetSelectedItem() is Weapon w) {
                    Vector2 vec = new();
                    vec.X = new Random().Next(-50,50);
                    vec.Y = new Random().Next(-50,50);
                    Pickup pickup = new(new Item("this", null), vec);
                    GetParent().AddChild(pickup);
                }
            }
        }

        public override void _Process(double delta) {
            if (showDebug) {
                var debug = "";
                debug += Entity.Name + "\n";
                debug += Position.Round().ToString() + "\n";
                debug += CurrentStats.Health + "/" + Entity.BaseStats.Health + "\n";
                debug += playerState.ToString();
                HUDDebug(debug);
            } else {
                HUDDebug("");
            }
        }

        public override void _PhysicsProcess(double delta) {
            var inputVector = Input.GetVector("Left", "Right", "Up", "Down");

            if (inputVector != Vector2.Zero && playerState != PlayerState.ROLLING) {
                playerState = PlayerState.MOVING;
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
        }

        public override void Die() {

        }
    }
}