using Godot;
using System;

public partial class Sign : Node2D
{
	[Export] public float SignTimer;
	public bool SignisOn = false;
	
	
	private AudioEffectRecord _microphoneRecord;
	
	private AudioStreamPlayer _audioStreamPlayer;
	
	public float MicrophoneInputPeakVolume;
	
	
	public override void _Ready()
	{
		_microphoneRecord = AudioServer.GetBusEffect(AudioServer.GetBusIndex("Record"),0) as AudioEffectRecord;
		TimerLoop();
	}
	
	public async void TimerLoop()
	{
		while(!SignisOn)
		{
			((CanvasItem)GetChild(1)).Hide();
			((CanvasItem)GetChild(0)).Show();
			((CanvasItem)GetChild(2)).Hide();
			var rng = new RandomNumberGenerator();
			rng.Randomize();
			SignTimer = rng.RandfRange(5f, 10f);
			await ToSignal(GetTree().CreateTimer(SignTimer), "timeout");
			GD.Print("kioui");
			SignisOn = true;
			
			
		}
		while(SignisOn)
		{
			((CanvasItem)GetChild(0)).Hide();
			((CanvasItem)GetChild(1)).Show();
			((CanvasItem)GetChild(2)).Hide();
			await ToSignal(GetTree().CreateTimer(5), "timeout");
			GD.Print("k");
			SignisOn = false;
			TimerLoop();
			
		}
	}
	private void GetMicrophonePeakVolume()
	{
		MicrophoneInputPeakVolume = AudioServer.GetBusPeakVolumeLeftDb(AudioServer.GetBusIndex("Record"),0);
		
	}
	public override void _Process(double delta)
	{
		GetMicrophonePeakVolume();
		
		if(MicrophoneInputPeakVolume > -15 && SignisOn == true)
		{
			
			((CanvasItem)GetChild(0)).Hide();
			((CanvasItem)GetChild(1)).Hide();
			((CanvasItem)GetChild(2)).Show();
		}
		
	}
}
