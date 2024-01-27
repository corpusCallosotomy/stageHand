using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class TomatoGenerator : Node2D
{	
	private List<Node2D> tomatoes = new List<Node2D>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		loadTomatoes();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void loadTomatoes() {
		int childCount = GetChildCount();

		for (int i = 0; i < childCount; i++)
		{
			Node2D tomato = GetChild(i) as Node2D;
			tomatoes.Add(tomato);
		}
	}
}
