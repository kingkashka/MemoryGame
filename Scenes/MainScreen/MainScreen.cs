using Godot;
using System;

public partial class MainScreen : Control
{
	[Export] private PackedScene levelButtonScene;
	[Export] private HBoxContainer hbLevels;
	public override void _Ready()
	{
		SetupGrid();
	}

	private void SetupGrid()
	{
		foreach(var levelDataResource in GameManager.GetLevels())
		{
			var levelButton = levelButtonScene.Instantiate<Levelbutton>();
			levelButton.SetLevelDataResource(levelDataResource);
			
			hbLevels.AddChild(levelButton);
			
		}
	}
}
