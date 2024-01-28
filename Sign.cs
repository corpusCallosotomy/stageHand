using Godot;
using System;

public partial class Sign : Node2D
{
	[Export] public float SignTimer;
	public bool SignisOn = false;
	public bool SignisOff;
	
	public override void _Ready()
	{
	
		TimerLoop();
	}
	
	public async void TimerLoop()
	{
		while(!SignisOn)
		{
			
			var rng = new RandomNumberGenerator();
			rng.Randomize();
			SignTimer = rng.RandfRange(20f, 25f);
			await ToSignal(GetTree().CreateTimer(SignTimer), "timeout");
			GD.Print("kioui");
			SignisOn = true;
			
			
		}
		while(SignisOn)
		{
			await ToSignal(GetTree().CreateTimer(2), "timeout");
			GD.Print("k");
			SignisOn = false;
			TimerLoop();
			
		}
	}
}
