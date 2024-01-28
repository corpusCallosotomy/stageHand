using Godot;
using System;

public partial class MicrophoneRecorder : Node2D
{
	private AudioEffectRecord _microphoneRecord;
	
	private AudioStreamPlayer _audioStreamPlayer;
	
	public float MicrophoneInputPeakVolume;
	
	public override void _Ready()
	{
		_microphoneRecord = AudioServer.GetBusEffect(AudioServer.GetBusIndex("Record"),0) as AudioEffectRecord;

	}
	private void GetMicrophonePeakVolume()
	{
		MicrophoneInputPeakVolume = AudioServer.GetBusPeakVolumeLeftDb(AudioServer.GetBusIndex("Record"),0);
		
	}
	public override void _Process(double delta)
	{
		GetMicrophonePeakVolume();
		
		if(MicrophoneInputPeakVolume > -15)
		{
			GD.Print(MicrophoneInputPeakVolume);
		}
		
	}
		
}
