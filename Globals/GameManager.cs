using Godot;
using System;

public partial class GameManager : Node
{
	private readonly LevelsResource levels = GD.Load<LevelsResource>("res://Resources/LevelsResource.tres");
	public static GameManager Instance { get; private set; }
	public static Godot.Collections.Array<LevelDataResource> GetLevels() 
	{
		return Instance.levels.Levels;
	}
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
