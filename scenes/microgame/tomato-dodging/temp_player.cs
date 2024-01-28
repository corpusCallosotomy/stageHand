using Godot;
using System;

public partial class temp_player : CharacterBody2D
{
	
	public const float Speed = 300.0f;
	private bool canMove = true;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		if(!canMove)
			return;
		Vector2 velocity = Velocity;
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void StopMovement() 
	{
		canMove = false;
	}
}
