using Godot;
using System;
using System.Collections.Generic;

public partial class GameScreen : Control
{
	[Export] private PackedScene memoryTileScene;
	[Export] private GridContainer tileGrid;
	[Export] private TextureButton exitButton;
	[Export] private Scorer scorer;
	[Export] private Label movesMadeLabel;

	public override void _Ready()
	{
		OnLevelSelect(4);
		exitButton.Pressed += _on_ExitButton_pressed;
		SignalManager.Instance.OnLevelSelected += OnLevelSelect;
		// StartTimer();
	}
    public override void _PhysicsProcess(double delta)
    {
        ShowMovesMade();
    }


    private async void StartTimer()
	{
		await ToSignal(GetTree().CreateTimer(6.0f), "timeout");
		SignalManager.EmitOnSelectionDisabled(null);
	}

	private void OnLevelSelect(int levelNum)
	{
		LevelDataResource levelData = GameManager.GetLevelData(levelNum);
		tileGrid.Columns = levelData.Columns;
		List<ItemImage> selectRandomImages = ImageManager.GetRandomImagePairsShuffled(levelData.TargetPairs);

		Texture2D frameImage = ImageManager.getRandomFrame();

		int i = 0;
		foreach (var item in selectRandomImages)
		{
			MemoryTile tile = (MemoryTile)memoryTileScene.Instantiate();
			tile.Setup(item, frameImage, i);
			tileGrid.AddChild(tile);
			i++;
		}
		scorer.ClearNewGame(levelData.TargetPairs);
	}

	private void _on_StartButton_pressed()
	{

	}
	private void _on_ExitButton_pressed()
	{
		SignalManager.EmitOnGameExitPressed();
	}
	private void ShowMovesMade()
	{
		movesMadeLabel.Text = scorer.GetMovesMadeString();
	}
}
