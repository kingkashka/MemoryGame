using Godot;
using System;
using System.Collections.Generic;

public partial class Scorer : Node
{
	[Export] private Timer revealTimer;
	[Export] private AudioStreamPlayer2D sound;

	private int movesMade;
	private int pairsMatched;
	private int TargetPairs;

	public int MovesMade { get => movesMade; }
	public int PairsMatched { get => pairsMatched; }

	List<MemoryTile> selectedTiles = new List<MemoryTile>();
	public string GetMovesMadeString() => movesMade.ToString();
	public string GetPairsMatchedString() => $"{pairsMatched}/{TargetPairs}";

	public override void _Ready()
	{
		SignalManager.Instance.OnTileSelected += OnTileSelected;
		SignalManager.Instance.OnGameExitPressed += OnGameExitPressed;

		revealTimer.Timeout += OnRevealTimeout;
	}
	public override void _ExitTree()
	{
		SignalManager.Instance.OnTileSelected -= OnTileSelected;
		SignalManager.Instance.OnGameExitPressed -= OnGameExitPressed;

	}
	public void ClearNewGame(int targetPairs)
	{
		selectedTiles.Clear();
		pairsMatched = 0;
		movesMade = 0;
		TargetPairs = targetPairs;
	}
	private void OnRevealTimeout()
	{
		foreach(MemoryTile tile in selectedTiles)
		{
			tile.Reveal(false);
		}
		selectedTiles.Clear();

		SignalManager.EmitOnSelectionEnabled(null);
		CheckGameOver();
	}

	private bool SelectionArePairs()
	{
		return selectedTiles[0].ItemName == selectedTiles[1].ItemName &&
			selectedTiles[0].Index != selectedTiles[1].Index;
	}
	private void ProcessPair()
	{
		SignalManager.EmitOnSelectionDisabled(null);
		movesMade++;

		if(SelectionArePairs())
		{
			pairsMatched++;
			selectedTiles[0].KillOnSuccess();
			selectedTiles[1].KillOnSuccess();
		}
		
		revealTimer.Start();
	}
	private void OnTileSelected(MemoryTile tile)
	{
		if (selectedTiles.Contains(tile)) return;

		tile.Reveal(true);
		selectedTiles.Add(tile);

		if (selectedTiles.Count == 2)
		{
			ProcessPair();
		}
	}



	private void OnGameExitPressed()
	{
		revealTimer.Stop();
	}

	private void CheckGameOver()
	{
		if(pairsMatched == TargetPairs)
		{
			sound.Play();
			SignalManager.EmitOnGameOver(movesMade);
		}
	}

}
