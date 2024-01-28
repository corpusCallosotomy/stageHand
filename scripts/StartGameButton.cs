using Godot;
using System;

public partial class StartGameButton : TextureButton
{
    AudioStreamPlayer audioPlayer = null;

    private TreeSceneManager treeSceneManager;

    bool playerAtMainMenu = true;
    public override void _Ready()
    {
        GetTreeSceneManager();

        Godot.Collections.Array<Node> children = this.GetChildren();

        foreach (var child in children)
        {
            if (child.Name == "AudioPlayer")
            {
                audioPlayer = (AudioStreamPlayer)child;
                
            }
        }


        audioPlayer.Stream = GD.Load<AudioStream>("res://sounds/Main Menu Loop.wav");
        audioPlayer.Play();

        this.ButtonDown += startClicked;
    }

    public override void _Process(double delta)
    {
        if (playerAtMainMenu && !audioPlayer.Playing)
        {
            audioPlayer.Play();
        }

    }

    public void startClicked()
    {
        //audioPlayer.
        audioPlayer.Stop();
        playerAtMainMenu = false;
        audioPlayer.Stream = GD.Load<AudioStream>("res://sounds/Non Micro Game Sounds/UI Sounds/UISelect.wav");
        audioPlayer.Play();

        //PackedScene setScene = GD.Load<PackedScene>("res://scenes/set.tscn");
        //Node2D setSceneNode2D = (Node2D) setScene.Instantiate();
        //Node2D parentNode = (Node2D) this.GetParent();
        //parentNode.GlobalPosition = new Vector2(0, 0);
        //parentNode.Visible = false;
        //parentNode.AddChild(setSceneNode2D);
        endScene();
    }

    private void endScene()
    {
        if (treeSceneManager != null)
        {
            treeSceneManager.setInMainMenu(false);
            treeSceneManager.BackToMainScene();
        }
            
        QueueFree();
    }

    private void GetTreeSceneManager()
    {
        Node temp = GetParent();
        if (temp != null)
            temp = temp.GetParent();
        if (temp != null)
            temp = temp.GetParent();
        if (temp != null)
            temp = temp.GetParent();
        if (temp != null)
            treeSceneManager = (TreeSceneManager)temp;
    }
}

