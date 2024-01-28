using Godot;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public partial class player : CharacterBody2D
{
	public float speed = 300;
	private Area2D microGameNamePlayerIsInteractingWith;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 moveInput = Input.GetVector("left", "right", "up", "down");
		Velocity = moveInput * speed;
		MoveAndSlide();
	}


	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact"))
			Interact();
	}

	void Interact()
	{
		if(microGameNamePlayerIsInteractingWith == null)
			return;
		TreeSceneManager tree = (TreeSceneManager) (GetParent().GetParent());
		tree.StartMicrogame(microGameNamePlayerIsInteractingWith.Name);
		((MicrogameIcon)microGameNamePlayerIsInteractingWith).Completed();
	}



	private void _on_area_2d_area_entered(Area2D area)
	{
		string state = ((MicrogameIcon) area).GetState();
		if(state.Equals("Active"))
			microGameNamePlayerIsInteractingWith = area;
	}



	private void _on_area_2d_area_exited(Area2D area)
	{
		microGameNamePlayerIsInteractingWith = null;
	}

}
