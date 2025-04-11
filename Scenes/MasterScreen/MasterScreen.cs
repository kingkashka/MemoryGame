using Godot;
using System;

public partial class MasterScreen : CanvasLayer
{
	[Export] private MainScreen _mainScreen;
	[Export] private GameScreen _gameScreen;

	public override void _Ready()
	{
		SignalManager.Instance.OnLevelSelected += ShowGame;
		SignalManager.Instance.OnGameExitPressed += ShowMain;
		ShowMain();
	}


	private void ShowGame(int levelNum)
	{
		_mainScreen.Hide();
		_gameScreen.Show();
	}

	private void ShowMain()
	{
		_gameScreen.Hide();
		_mainScreen.Show();
		ClearTiles();
	}



	private void ClearTiles()
	{
		foreach (Node node in GetTree().GetNodesInGroup(MemoryTile.GroupName))
		{
			node.QueueFree();
		}
	}
}
