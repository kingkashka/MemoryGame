using Godot;
using System;

public partial class GameOverScreen : Control
{
	[Export] private Label movesLabel;
	public override void _Ready()
	{
		SignalManager.Instance.OnGameOver += OnGameOver;
		Hide();
	}

    private void OnGameOver(int moves)
    {
		movesLabel.Text = $"{moves:000}";
        Show();

		
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

}
