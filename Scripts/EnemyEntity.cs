using System;
using System.IO;
using System.Runtime.CompilerServices;
using Godot;

namespace Entities
{
	public enum EnemyState {
		IDLE,
		TARGETING,
		PERSUING,
		ATTACKING,
		STUNNED
	}

	[GlobalClass]
	public partial class EnemyEntity : DynamicEntity 
	{
		EnemyState enemyState;

		Node2D[] TypesToTarget;
		Node2D Target;

		public override void _Ready() {
			base._Ready();
			Target = GetParent().GetNode<Node2D>("PlayerEntity");
		}

        public void PathFindToTarget() {
        }

		public override void _PhysicsProcess(double delta) {
		}
	}
}