using Godot;
using System;

public partial class Newspaper : Godot.TextureButton
{

    bool newspaperHeld = false;
    int newsPaperIndex = -1;
    public override void _Ready()
    {
        base._Ready();

        //var button = new TextureButton();
        //Texture2D texture = new Texture2D();
        //texture.Set("res://sprites/microgame/newspaper_game/newspaper.png");
        //button.TextureNormal = load

        GD.Print("Hello World!");

        this.ButtonDown += newspaperClicked;
        this.ButtonUp += newspaperReleased;

    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (newspaperHeld)
        {
            
            this.GlobalPosition = this.GlobalPosition.Lerp(GetGlobalMousePosition(), (float) (25 * delta));
        }
    }

    public void newspaperClicked()
    {
        GD.Print("Starting to move nnewspaper: " + this.GetMeta("newspaper_index"));
        newspaperHeld = true;
    }

    public void newspaperReleased() {
        newspaperHeld = false;
    }

    public void setIndex(int index)
    {
        this.newsPaperIndex = index;
    }

    public int getIndex()
    {
        return this.newsPaperIndex;
    }

    public bool getNewspaperHeld()
    {
        return newspaperHeld;
    }

}
