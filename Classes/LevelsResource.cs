using Godot;

[GlobalClass]
public partial class LevelsResource : Resource
{
    [Export] public Godot.Collections.Array<LevelDataResource> Levels { get; set; } = new();
}