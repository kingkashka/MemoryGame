using Godot;
using System;

public partial class SignalManager : Node
{
	public static SignalManager Instance { get; private set; }
	
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
