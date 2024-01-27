using Godot;
using System;

public partial class NewspaperGameManager : Node2D
{

    //TextureButton btnTemplate = null;
    
    public override void _Ready()
    {
        Godot.Collections.Array<Node> children = this.GetChildren();
        foreach (var child in children)
        {
            GD.Print("\t" + child.Name);
            //if (child.Name == "TextureButton")
            //{
            //    btnTemplate = (TextureButton) child;
            //    GD.Print("Assigned Microphone to: " + btnTemplate.Name);
            //}

        }

    }

    public override void _Process(double delta)
    {
        base._Process(delta);


    }
}
