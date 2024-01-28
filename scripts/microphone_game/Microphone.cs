using Godot;
using System;

public partial class Microphone : Node2D
{
	[Signal]
	public delegate void MySignalEventHandler();

	bool movable = false;

	double d = 0;
	double radius = 150;
	double speed = 2;

	float initialRotation = 0;

	bool atInitialPos = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		initializeGame();
	}

	
	public void initializeGame()
	{
		
		this.initialRotation = 0;
		this.RotationDegrees = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		// float AMOUNT = 5;
		if (this.movable)
		{
			//d += delta;


			//this.Position = new Vector2(
			//	(float) (Math.Sin(d*speed)*radius),
			//	(float) (Math.Cos(d*speed*radius)));
			this.Rotate((float)(delta * 1.5));

			if (this.RotationDegrees > 70)
			{
				this.RotationDegrees = this.initialRotation;
				atInitialPos = true;
            }
			else
			{
                atInitialPos = false;
            }

			/*
			if (Input.IsKeyPressed(Key.W))
			{
				this.Rotate((float)(delta * 1));
				//this.RotationDegrees -= 1;
				GD.Print("Moving Microphone Up");
			}
			else if (Input.IsKeyPressed(Key.S))
			{
				this.Rotate((float)(delta * -1));
				//this.RotationDegrees += 1;
				GD.Print("Moving Microphone Down");
			}
			*/
		}
		
	}

	public void setMovable(bool movable)
	{
		this.movable = movable;
	}

	public float getRotation()
	{
		return this.RotationDegrees;
	}

	public void rotateUp()
	{
		GD.Print("Rotating Microphone Up!");
		this.Rotate(0.1f);
		GD.Print("Rotation: " + this.RotationDegrees);
	}

	public void rotateDown()
	{
		GD.Print("Rotating Microphone Down!");
		this.Rotate(-0.1f);
	}

	public void setRandomRotation()
	{
		Random rnd = new Random();
		float num = (float) rnd.Next(-130,48);
		// this.RotationDegrees = (float) num;
		this.RotationDegrees = num;
		//this.Rotate( num * 0.0174533f);

	}

	public bool getAtInitialPos()
	{
		return atInitialPos;
	}
}
