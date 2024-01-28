using Godot;
using System;

public partial class MicrophoneGameManager : Node2D
{

	public enum GameState
	{
		Initializing,
		Prompt,
		Playing,
		Checking,
		Failed,
		Passed,
		Restarting
	}

	GameState state = GameState.Initializing;

	Microphone microphoneNode = null;
	Node2D microphoneOutlineNode = null;
	Label statusLabel = null;

	Sprite2D prompt = null;
	Sprite2D smallPrompt = null;

	bool waitingForTime = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.Collections.Array<Node> children = this.GetChildren();

		GD.Print("Game State: " + state);
		GD.Print("Printing Children:");
		GD.Print("Children Count: " + this.GetChildren().Count);
		foreach (var child in children)
		{
			GD.Print("\t" + child.Name);
			if (child.Name == "Microphone")
			{
				microphoneNode = (Microphone)child;
				GD.Print("Assigned Microphone to: " + microphoneNode.Name);
			}
			else if (child.Name == "MicrophoneOutline")
			{
				microphoneOutlineNode = (Node2D) child;
				GD.Print("Assigned Microphone Outline to: " + microphoneOutlineNode.Name);
			}
			else if (child.Name == "Label")
			{
				statusLabel = (Label) child;
			}
			else if (child.Name == "Prompt")
			{
                prompt = (Sprite2D) child;
			}
            else if (child.Name == "SmallPrompt")
            {
                smallPrompt = (Sprite2D) child;
            }
        }
		GD.Print("Done Collecting Children");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//Godot.Collections.Array<Node> children = this.GetChildren();
		//GD.Print("Printing Children:");
		//GD.Print("Game State: " + state);
		//foreach (var child in children)
		//{
		//	GD.Print(child);
		//}

		if (state == GameState.Initializing)
		{
			//statusLabel.Visible = false;

			//microphoneNode.setRandomRotation();
			Random rnd = new Random();
			float num = (float)rnd.Next(10, 34);
			microphoneOutlineNode.RotationDegrees = num;

			state = GameState.Prompt;
			microphoneNode.setMovable(false);
			GD.Print("Moving to state: " + state);

			prompt.Visible = true;
			smallPrompt.Visible = false;
			waitingForTime = true;
			waitForTime();

			microphoneNode.setMovable(false);
		}
		else if (state == GameState.Prompt)
		{
			if (!waitingForTime)
			{
                prompt.Visible = false;
                smallPrompt.Visible = true;
                state = GameState.Playing;
                microphoneNode.setMovable(true);
            }
		}
		else if (state == GameState.Playing)
		{
			
			//if (Input.IsKeyPressed(Key.W))
			//{
			//	// GD.Print("Moving microphone up");
			//	microphoneNode.rotateUp();
			//}
			//else if (Input.IsKeyPressed(Key.S))
			//{
			//	// GD.Print("Moving microphone down");
			//	microphoneNode.rotateDown();
			//}
			//if (Input.IsKeyPressed(Key.Space))
			//{
			//	state = GameState.Checking;
			//	GD.Print("Moving to state: " + state);
			//}
			if (Input.IsMouseButtonPressed(MouseButton.Left))
			{
				state = GameState.Checking;
				GD.Print("Moving to state: " + state);
				microphoneNode.setMovable(false);
			}
		}
		else if (state == GameState.Checking)
		{
			GD.Print("Microphone Rotation: " + microphoneNode.RotationDegrees);
			GD.Print("Microphone Outline Rotation: " + microphoneNode.RotationDegrees);
			GD.Print("Moving to state: " + state);
			if (microphoneNode.getRotation() > microphoneOutlineNode.RotationDegrees - 3 &&
				microphoneNode.getRotation() < microphoneOutlineNode.RotationDegrees + 3)
			{
				GD.Print("Passed!");
				state = GameState.Passed;
				///statusLabel.Text = "Passed!";
				//statusLabel.SelfModulate = new Color(0, 1, 0);
				//statusLabel.Visible = true;
				waitingForTime = true;
				waitForTime();
			}
			else
			{
				GD.Print("Failed!");
				state = GameState.Failed;
				//statusLabel.Text = "Failed!";
				//statusLabel.SelfModulate = new Color(1, 0, 0);
				//statusLabel.Visible = true;
				waitingForTime = true;
				waitForTime();
			}
		}
		else if (state == GameState.Passed || state == GameState.Failed)
		{

			// wait for some number of seconds
			if (waitingForTime == false)
			{
				state = GameState.Initializing;
				// waitingForTime = true;
				// waitForTime();

			}
		}
		//else if (state == GameState.Restarting)
		//{
		//	if (waitingForTime == false)
		//	{
		//		state = GameState.Initializing;
		//	}
		//}
	}

	async void waitForTime()
	{
		await ToSignal(GetTree().CreateTimer(1.5), "timeout");
		waitingForTime = false;
	}
}
