using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class TomatoGenerator : Node2D
{	
	private Random rnd = new Random();
	private double timeCounter = 0;
	private double interval = 1;
	private double[] intervals = { 1.75, 2, 2.25 };
	private List<Area2D> hitBoxes = new List<Area2D>();
	private float[] xPositions = { -350f, 2f, 350f };

	private bool isStarted = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		loadHitBoxes();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!isStarted)
			return;
		timeCounter += delta;
		if (timeCounter >= interval)
		{
			loadTomato();
			timeCounter = 0f; // Reset the counter
			interval = intervals[rnd.Next(0, intervals.Length)];
		}
	}

	private void loadHitBoxes() 
	{
		Node childNode = GetNode("HitBoxes");
		for(int i = 0; i <= 10; i++)
		{
			Node node = childNode.FindChild("HitBox" + i);
			Area2D hitBox = (Area2D) node;
			hitBoxes.Add(hitBox);
		}
	}

	private void loadTomato() 
	{
		// Load object
		Node nodeInstance = ResourceLoader.Load<PackedScene>("res://sprites/microgame/tomato-dodging/tomato.tscn").Instantiate();
		Tomato tomatoInstance = (Tomato) nodeInstance;
		// Get x position for instantiation
		float xInstantiation = xPositions[rnd.Next(0, xPositions.Length)];
		// Set position for instatiation
		tomatoInstance.Position = new Vector2(xInstantiation, 365f);
		// Get destination
		TomatoHitBox hitBox = (TomatoHitBox) hitBoxes.ElementAt(rnd.Next(0, hitBoxes.Count));
		tomatoInstance.SetHitBox(hitBox);
		AddChild(tomatoInstance);
	}

	public void Start() {
		isStarted = true;
	}

	public void Stop() {
		isStarted = false;
	}

}
