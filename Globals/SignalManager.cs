using Godot;
using System;

public partial class SignalManager : Node
{
	[Signal] public delegate void OnLevelSelectedEventHandler(int levelNum);

	[Signal] public delegate void OnGameExitPressedEventHandler();
	[Signal] public delegate void OnTileSelectedEventHandler(MemoryTile tile);
	[Signal] public delegate void OnSelectionDisabledEventHandler(MemoryTile tile);
	[Signal] public delegate void OnSelectionEnabledEventHandler(MemoryTile tile);
	[Signal] public delegate void OnGameOverEventHandler(int moves);

	public static SignalManager Instance { get; private set; }
	public override void _Ready()
	{
		Instance = this;
	}
	public static void EmitOnLevelSelected(int levelNum)
	{
		Instance.EmitSignal(SignalName.OnLevelSelected, levelNum);
	}
	
	public static void EmitOnGameExitPressed()
	{
		Instance.EmitSignal(SignalName.OnGameExitPressed);
	}

	public static void EmitOnTileSelected(MemoryTile tile)
	{
		Instance.EmitSignal(SignalName.OnTileSelected, tile);
	}
	public static void EmitOnSelectionDisabled(MemoryTile tile)
	{
		Instance.EmitSignal(SignalName.OnSelectionDisabled, tile);
	}
	public static void EmitOnSelectionEnabled(MemoryTile tile)
	{
		Instance.EmitSignal(SignalName.OnSelectionEnabled, tile);
	}	

	public static void EmitOnGameOver(int moves)
	{
		Instance.EmitSignal(SignalName.OnGameOver);
	}

}
