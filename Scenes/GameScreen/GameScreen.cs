using Godot;
using System;
using System.Collections.Generic;

public partial class GameScreen : Control
{
	[Export] private PackedScene memoryTileScene;
	[Export] private GridContainer tileGrid;
	public override void _Ready()
	{
		OnLevelSelect(4);
	}

    private void OnLevelSelect(int levelNum)
    {
        LevelDataResource levelData = GameManager.GetLevelData(levelNum);
		tileGrid.Columns = levelData.Columns;
		List<ItemImage> selectRandomImages = ImageManager.GetRandomImagePairsShuffled(levelData.TargetPairs);
		
		Texture2D frameImage = ImageManager.getRandomFrame();

		int i = 0;
		foreach(var item in selectRandomImages)
		{
			MemoryTile tile = (MemoryTile)memoryTileScene.Instantiate();
			tileGrid.AddChild(tile);
			i++;
		}
    }

    private void _on_StartButton_pressed()
	{
		
	}
	private void _on_ExitButton_pressed()
	{
		GetTree().Quit();
	}
}
