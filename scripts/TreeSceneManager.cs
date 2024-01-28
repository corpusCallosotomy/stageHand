using Godot;
using System;
using System.Collections.Generic;


public partial class TreeSceneManager : Node
{
	private Dictionary<string, string> microGamePaths = new Dictionary<string, string>();
	private Node2D mainSet;
	private SubViewportContainer viewPortContainer;
	private Node viewPort;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetMicroGamePaths();
		mainSet = (Node2D) FindChild("MainSet");
		viewPortContainer = (SubViewportContainer) FindChild("SubViewportContainer");
		viewPort = viewPortContainer.FindChild("SubViewport");
	}
	public void BackToMainScene()
	{
		viewPortContainer.Hide();
		mainSet.Show();
	}

	public void StartMicrogame(string scene)
	{
		string scenePath = microGamePaths[scene];
		GD.Print(scenePath);
		Node newScene = ResourceLoader.Load<PackedScene>(scenePath).Instantiate();
		viewPort.AddChild(newScene);
		mainSet.Hide();
		viewPortContainer.Show();
	}

	private void SetMicroGamePaths()
	{
		microGamePaths.Add("Microphone", "res://scenes/microgame/MicrophoneGame.tscn");
		microGamePaths.Add("Microphone1", "res://scenes/microgame/MicrophoneGame.tscn");
		microGamePaths.Add("Microphone2", "res://scenes/microgame/MicrophoneGame.tscn");
		microGamePaths.Add("Tomato", "res://scenes/microgame/tomato-dodging/tomato-dodging.tscn");
		microGamePaths.Add("Tomato1", "res://scenes/microgame/tomato-dodging/tomato-dodging.tscn");
		microGamePaths.Add("Tomato2", "res://scenes/microgame/tomato-dodging/tomato-dodging.tscn");
		microGamePaths.Add("Newspaper", "res://scenes/microgame/NewspaperGame.tscn");
		microGamePaths.Add("Newspaper1", "res://scenes/microgame/NewspaperGame.tscn");
		microGamePaths.Add("Newspaper2", "res://scenes/microgame/NewspaperGame.tscn");
	}
}
