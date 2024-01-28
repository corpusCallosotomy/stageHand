using Godot;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public partial class player : CharacterBody2D
{
	public float speed = 300;
	private microGameName;
	private Dictionary<string, string> pathToMicrogame = new Dictionary<string, string>();

	public override void _Ready()
	{
		SetMicroGamePaths();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 moveInput = Input.GetVector("left", "right", "up", "down");
		Velocity = moveInput * speed;
		MoveAndSlide();
	}


	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact") && pathToMicrogame != null)
		{
			Interact();
		}


	}

	void Interact()
	{

	}



	private void _on_area_2d_area_entered(Area2D area)
	{
		string name = area.Name;
	}



	private void _on_area_2d_area_exited(Area2D area)
	{
		pathToMicrogame = null;
	}

	private void SetMicroGamePaths()
	{
		pathToMicrogame.Add("Microphone", "");
		pathToMicrogame.Add("Tomato", "");
		pathToMicrogame.Add("Newspaper", "");
	}
}
