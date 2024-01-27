using Godot;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public partial class player : CharacterBody2D
{
	[Export] public Area2D interactionArea;
	[Export] public Area2D interactable;
	[Export] public float speed = 300;


	public override void _PhysicsProcess(double delta)
	{
		Vector2 moveInput = Input.GetVector("left", "right", "up", "down");

		Velocity = moveInput * speed;
		//GD.Print("working");
		MoveAndSlide();

	}
	

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("interact"))
		{
			Interact();
		}

	   
	}

	void Interact()
	{
		interactable.Call("Use");
	}



private void _on_area_2d_area_entered(Area2D area)
{
	if(area.IsInGroup("Interactable"))
		{
			interactable = area;
			GD.Print(interactable);
		}
	
	// Replace with function body.
}
}
