using Godot;
using System;

public partial class Levelbutton : TextureButton
{
	[Export] Label levelLabel;
	[Export] AudioStreamPlayer2D levelButtonSound;
	private LevelDataResource levelDataResource;
	public override void _Ready()
	{
		
		Pressed += OnLevelButtonPressed;
		// levelLabel.Text = $"{LevelDataResource.Rows.ToString()}X{LevelDataResource.Columns.ToString()}";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnLevelButtonPressed()
	{
		levelButtonSound.Play();
		// Emit signal to start the level
		// SignalManager.Instance.EmitSignal("StartLevel", LevelDataResource.LevelNumber);
		// GD.Print($"Level {LevelDataResource.LevelNumber} button pressed.");
	}

	public void SetLevelDataResource(LevelDataResource levelDataResource)
	{
		this.levelDataResource = levelDataResource;
		levelLabel.Text = $"{levelDataResource.Rows}X{levelDataResource.Columns}";
		// GD.Print($"Level {levelDataResource.LevelNumber} button set.");
	}

}
