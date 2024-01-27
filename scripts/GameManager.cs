using Godot;
using System;

public partial class GameManager : Node2D
{
	public static GameManager instance;
	[Export] public Node2D[] Microgames;
	
	
	public override void _Ready()
	{
		instance = this;
	}

	public void PlayMicrogame(int GameNumber)
	{
		GD.Print(GameNumber);
		
	}
	
}
