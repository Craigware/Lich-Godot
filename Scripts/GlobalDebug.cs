using Entities;
using Godot;
using System;

public partial class GlobalDebug : Control
{
    public override void _Ready()
    {
        Visible = false;
        base._Ready();
        Timer timer = new() {
            WaitTime = 1,
            Autostart = true
        };
        timer.Timeout += () => {
            var entityLabel = GetNode<RichTextLabel>("VBoxContainer/HBoxContainer/VBoxContainer/Entities");
            int[] ints = CountEntities();
            entityLabel.Text = "EntityCount: " + ints[3] + "\n";
            entityLabel.Text += "    - StaticCount: " + ints[1] + "\n";
            entityLabel.Text += "    - DynamicCount: " + ints[2] + "\n";
            entityLabel.Text += "    - EtherialCount: " + ints[0] + "\n";
        };
        AddChild(timer);
    }

    public override void _Input(InputEvent @event) {
        if (Input.IsActionJustPressed("ShowDebug")) {
            Visible = !Visible;
        }
    }

    public override void _Process(double delta)
	{
        var fpsLabel = GetNode<RichTextLabel>("VBoxContainer/HBoxContainer/VBoxContainer/FPS");
        fpsLabel.Text = "FPS: " + Engine.GetFramesPerSecond().ToString();
    }

    public int[] CountEntities() {
        var node = GetParent().GetParent();
        var count = node.GetChildCount();
        int etherial = 0;
        int statc = 0;
        int dynamic = 0;
        for (int i = 0; i < count; i++) {
            if (node.GetChild(i) is EtherialEntity) etherial++;
            if (node.GetChild(i) is StaticEntity) statc++;
            if (node.GetChild(i) is DynamicEntity) dynamic++;
        }

        return new int[] {
            etherial,
            statc,
            dynamic,
            etherial + statc + dynamic
        };
    }
}
