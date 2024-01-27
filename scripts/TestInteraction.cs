using Godot;
using System;
using System.Security.AccessControl;

public partial class TestInteraction : Area2D
{
	public void Use()
	{
		GameManager.instance.PlayMicrogame(1);
		GD.Print("ooooo");
	}
}
