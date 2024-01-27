using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Export] public float speed = 300;


	public override void _PhysicsProcess(double delta)
	{
		Vector2 moveInput = Input.GetVector("left", "right", "up", "down");

		Velocity = moveInput * speed;

		MoveAndSlide();
	}
}
