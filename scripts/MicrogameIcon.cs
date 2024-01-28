using Godot;
using System;

public partial class MicrogameIcon : Area2D
{
	private string state = "Active";
	private Node inactiveImage;
	private Node activeImage;
	private Node completedImage;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void Activate()
	{
		((CanvasItem)FindChild("Inactive")).Hide();
		((CanvasItem)FindChild("Active")).Show();
		state = "Active";
	}
	
	public void Completed()
	{
		((CanvasItem)FindChild("Active")).Hide();
		((CanvasItem)FindChild("Completed")).Show();
		state = "Completed";
	}

	public string GetState()
	{
		return state;
	}
}
