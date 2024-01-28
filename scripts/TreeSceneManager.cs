using Godot;
using System;
using System.Collections.Generic;


public partial class TreeSceneManager : Node
{
	private Dictionary<string, string> microGamePaths = new Dictionary<string, string>();
	private GameManager mainSet;
	private SubViewportContainer viewPortContainer;
	private Node viewPort;

	public bool inMainMenu = true;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetMicroGamePaths();
		mainSet = (GameManager) FindChild("MainSet");
		mainSet.setInMainMenu(inMainMenu);
		viewPortContainer = (SubViewportContainer) FindChild("SubViewportContainer");
		viewPort = viewPortContainer.FindChild("SubViewport");
		StartMicrogame("MainMenuScreen");
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
		microGamePaths.Add("MainMenuScreen", "res://scenes/MainMenuScreen.tscn");
	}

	public void setInMainMenu(bool inMainMenu)
	{
		this.inMainMenu = inMainMenu;
		mainSet.setInMainMenu(inMainMenu);
	}
}
