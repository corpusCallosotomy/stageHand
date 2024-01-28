using Godot;
using System;

public partial class NewspaperGameManager : Node2D
{
    public enum GameState
    {
        Initializing,
        Playing,
        Passed
    }

    GameState state = GameState.Initializing;

    int num_newspapers_in_zone = 0;
    bool correct_newspaper_in_zone = false;
    int target_newspaper = 0;
    bool waitingForTime = false;

    Random rnd = new Random();

    //TextureButton btnTemplate = null;
    Godot.Collections.Array<Newspaper> newspapers = new Godot.Collections.Array<Newspaper>{ };

    Label statusLabel = null;
    Label requestLabel = null;

    String[] newspaper_letters = {"L","P","A","Q","N","R","G","S"};


    public override void _Ready()
    {
        GD.Print("Newspaper Game Manager is Ready!");

        Godot.Collections.Array<Node> children = this.GetChildren();
        foreach (var child in children)
        {
            GD.Print("\t" + child.Name);
            if (child.Name.ToString().Contains("Newspaper"))
            {
                newspapers.Add((Newspaper) child);
                GD.Print("Got a new Newspaper Child: " + child.GetMeta("newspaper_index"));
            }
            else if (child.Name == "StatusLabel")
            {
                statusLabel = (Label) child;
            }
            else if (child.Name == "RequestLabel")
            {
                requestLabel = (Label) child;
            }

        }


    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (state == GameState.Initializing)
        {
            statusLabel.Text = "";
            requestLabel.Text = "Please provide newspaper: " + newspaper_letters[target_newspaper];
            foreach(Newspaper newspaper in newspapers)
            {
                
                float random_x = (float) rnd.Next(50, 450);
                float random_y = (float) rnd.Next(50, 750);
                newspaper.GlobalPosition = new Vector2(random_x, random_y);
            }

            target_newspaper = rnd.Next(newspapers.Count);


            state = GameState.Playing;
        }
        else if (state == GameState.Playing){
            num_newspapers_in_zone = 0;
            correct_newspaper_in_zone = false;
            foreach (Newspaper newspaper in newspapers)
            {
                if (newspaper.GlobalPosition.X > 500)
                {
                    num_newspapers_in_zone++;

                    if (newspaper.GetMeta("newspaper_index").AsInt32() == target_newspaper)
                    {
                        correct_newspaper_in_zone = true;
                    }
                }

                if (correct_newspaper_in_zone && num_newspapers_in_zone == 1)
                {
                    state = GameState.Passed;
                    waitingForTime = true;
                    waitForTime();
                }

                
            }
        }
        else if (state == GameState.Passed)
        {
            statusLabel.Text = "Passed!";
            if (waitingForTime == false)
            {
                state = GameState.Initializing;

            }
        }

    }

    async void waitForTime()
    {
        await ToSignal(GetTree().CreateTimer(1.5), "timeout");
        waitingForTime = false;
    }
}
