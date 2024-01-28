using Godot;
using System;
using System.Security.AccessControl;



public partial class GameManager : Node2D
{
	public static GameManager instance;
	[Export] public Node2D[] Microgames;
	[Export] public float StartTimer;
	[Export] public float TaskTimer;

	AudioStreamPlayer audioPlayer = null;

	public bool inMainMenu = true;
	
	
	public override void _Ready()
	{
		TimerLoop();
        /*var rng = new RandomNumberGenerator();
		instance = this;
		rng.Randomize();
		TaskTimer = rng.RandfRange(5f, 7f);
		GD.Print(TaskTimer);*/

        //TaskTimer = Random.Range(5,7)

        Godot.Collections.Array<Node> children = this.GetChildren();

        foreach (var child in children)
        {
            if (child.Name == "AudioStreamPlayer")
            {
                audioPlayer = (AudioStreamPlayer) child;
				// audioPlayer.Play();
            }
        }
    
	}
	public override void _Process(double delta)
	{
		
		/*if(TaskTimer>=0)
		{
			GD.Print(TaskTimer);
			await ToSignal(GetTree().CreateTimer(0.2), "timeout");
		}*/
	}
	public async void TimerLoop()
	{
		while(true)
		{
			var rng = new RandomNumberGenerator();
			instance = this;
			rng.Randomize();
			TaskTimer = rng.RandfRange(5f, 7f);
			await ToSignal(GetTree().CreateTimer(TaskTimer), "timeout");
			GD.Print("kioui");
		}
	}

	public void setInMainMenu(bool inMainMenu)
	{
		this.inMainMenu = inMainMenu;
		if (!inMainMenu)
		{
            audioPlayer.Play();
			audioPlayer.Autoplay = true;
        }
	}
		
	/*public void PlayMicrogame(int GameNumber)
	{
		
		
	}*/
	

}
