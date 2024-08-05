using Godot;
using System;

public partial class GlobalDebug : Control
{   
	public override void _Process(double delta)
	{
        var fpsLabel = GetNode<RichTextLabel>("VBoxContainer/HBoxContainer/FPS");
        fpsLabel.Text = "FPS: " + Engine.GetFramesPerSecond().ToString();
    }
}
