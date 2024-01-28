using Godot;
using System;

public partial class TomatoGameManager : Node2D
{
	private TreeSceneManager treeSceneManager;
	private TomatoGenerator tomatoGenerator;
	private RichTextLabel objective;
	private RichTextLabel score;
	private temp_player player;
	private bool isOver = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetTreeSceneManager();
		tomatoGenerator = (TomatoGenerator) FindChild("TomatoGenerator");
		objective = (RichTextLabel) FindChild("Objective");
		score = (RichTextLabel) FindChild("Score");
		player = (temp_player) FindChild("Player");
		wait(2f);
	}

	public void increaseScore()
	{
		if(isOver)
			return;
		int s = Int32.Parse(score.Text) + 1;
		score.Text = "" + s;
		if(s == 5)
		{
			isOver = true;
			objective.Text = "Congrats! You've complated the Objective!";
			player.StopMovement();
			tomatoGenerator.Stop();
			endScene(1.5f);
		}
	}

	public void resetScore()
	{
		if(isOver)
			return;
		score.Text = "0";
	}

	private async void wait(float seconds)
	{
		GD.Print("waiting...");
		// This will wait for the specified number of seconds
		await ToSignal(GetTree().CreateTimer(seconds), "timeout");
		GD.Print("Starting...");
		objective.Text = "";
		tomatoGenerator.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private async void endScene(float seconds) 
	{
		if(treeSceneManager != null)
			treeSceneManager.BackToMainScene();
		QueueFree();
	}

	private void GetTreeSceneManager()
	{
		Node temp = GetParent();
		if(temp != null)
			temp = temp.GetParent();
		if(temp != null)
			temp = temp.GetParent();
		if(temp != null)
			treeSceneManager = (TreeSceneManager) temp;
	}
}
