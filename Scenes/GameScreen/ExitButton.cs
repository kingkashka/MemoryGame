using Godot;
using System;

public partial class ExitButton : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += _on_ExitButton_pressed;
	}

	private void _on_ExitButton_pressed()
	{
		SignalManager.EmitOnGameExitPressed();
	}
}
