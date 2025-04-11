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
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnLevelButtonPressed()
	{
		levelButtonSound.Play();
		SignalManager.EmitOnLevelSelected(levelDataResource.LevelNumber);
	}

	public void SetLevelDataResource(LevelDataResource levelDataResource)
	{
		this.levelDataResource = levelDataResource;
		levelLabel.Text = $"{levelDataResource.Rows}X{levelDataResource.Columns}";
	}

}
