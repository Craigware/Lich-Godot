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
		NavigationAgent2D nav;

		public override void _Ready() {
			base._Ready();
			nav = GetNode<NavigationAgent2D>("NavigationAgent2D");
			Target = GetParent().GetNode<Node2D>("PlayerEntity");
		}

		public override void _PhysicsProcess(double delta) {
		}
	}
}