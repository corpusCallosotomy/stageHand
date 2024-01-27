using Godot;
using System;

public partial class tomato : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	
	private const float radianRotation = 3.5f;
	private const float scaleSpeed = .3f;
	private const float minScale = .35f;
	private const float travelSpeed = 1f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private double timeCounter = 0;
	private double interval = .01; // 1 second interval

	public override void _Process(double delta)
	{
		timeCounter += delta;
		if (timeCounter >= interval)
		{
			MyRotation((float) delta);
			MyScale((float) delta);
			timeCounter = 0f; // Reset the counter
		}
	}

	public void MyRotation(float delta) {
		Rotate(radianRotation * delta);
	}

	public void MyScale(float delta) {
		float deltaScaleSpeed = scaleSpeed * delta;
		float scaleX = Scale.X;
		float scaleY = Scale.Y;
		if((scaleX - deltaScaleSpeed) < minScale)
			this.Scale = new Vector2(minScale, minScale);
		if(scaleX > minScale)
			this.Scale = new Vector2(scaleX - deltaScaleSpeed, scaleY - deltaScaleSpeed);
	}

	public override void _PhysicsProcess(double delta)
	{
		

		// Vector2 velocity = Velocity;

		// // Add the gravity.
		// if (!IsOnFloor())
		// 	velocity.Y += gravity * (float)delta;

		// // Handle Jump.
		// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		// 	velocity.Y = JumpVelocity;

		// // Get the input direction and handle the movement/deceleration.
		// // As good practice, you should replace UI actions with custom gameplay actions.
		// Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		// if (direction != Vector2.Zero)
		// {
		// 	velocity.X = direction.X * Speed;
		// }
		// else
		// {
		// 	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		// }

		// Velocity = velocity;
		// MoveAndSlide();
	}
}
