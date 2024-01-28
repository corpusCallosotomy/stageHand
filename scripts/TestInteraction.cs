using Godot;
using System;
using System.Security.AccessControl;

public partial class TestInteraction : Area2D
{
[Export] public Node MicroGameParent;
	public void Use()
	{
		
		Node nodeInstance = ResourceLoader.Load<PackedScene>("res://scenes/microgame/MicrophoneGame.tscn").Instantiate();
		AddChild(Microgame);
		GD.Print("ooooo");
	}
}
