using Godot;
using System;

public partial class SoundManager : Node
{
	public static SoundManager Instance { get; private set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		// Connect signals here
		// Example: GetTree().Connect("some_signal", this, nameof(OnSomeSignal));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
