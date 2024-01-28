using Godot;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public partial class player : CharacterBody2D
{
	[Export] public Area2D interactionArea;
	[Export] public Area2D interactable;
	[Export] public float speed = 300;
	//Node childNode = GetNodeOrNull(childNodeName);

	/*private void MakeChildInvisible(string childNodeName)
		{
			// Get the child node by name
			Node childNode = GetNodeOrNull(childNodeName);

			// Check if the child node exists
			if (childNode != null)
			{
				// Set the visibility of the child node to false
				childNode.Visible = false;
			}
			else
			{
				GD.Print("Child node not found: " + childNodeName);
			}
		}

	private void MakeChildVisible(string childNodeName)
		{
			// Get the child node by name
			Node childNode = GetNodeOrNull(childNodeName);

			// Check if the child node exists
			if (childNode != null)
			{
				// Set the visibility of the child node to false
				childNode.Visible = true;
			}
			else
			{
				GD.Print("Child node not found: " + childNodeName);
			}
		}*/

	public override void _PhysicsProcess(double delta)
	{
		Vector2 moveInput = Input.GetVector("left", "right", "up", "down");
		
		Velocity = moveInput * speed;
		/*if(Velocity == 0)
		{
		 	MakeChildVisible("Idle");
			MakeChildInvisible("Walk");
		}
		else
		{
			MakeChildVisible("Walk");
			MakeChildInvisible("Idle");
		}*/
		//GD.Print("working");
		MoveAndSlide();

	}


	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact") && interactable != null)
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
		if (area.IsInGroup("Interactable"))
		{
			interactable = area;
			GD.Print(interactable);
		}

		// Replace with function body.
	}



	private void _on_area_2d_area_exited(Area2D area)
	{
		// Reif(area.IsInGroup("Interactable"))
		{
			interactable = null;
			GD.Print("disconnected");
		}

	}
}
