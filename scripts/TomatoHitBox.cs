using Godot;
using System;

public partial class TomatoHitBox : Area2D
{
	public bool isPlayerInHitBox = false;

	private void _on_area_entered(Area2D area)
	{
		isPlayerInHitBox = true;
	}


	private void _on_area_exited(Area2D area)
	{
		isPlayerInHitBox = false;
	}
}
