using Godot;
using System;

public partial class MasterScreen : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var image = ImageManager.GetRandomItemImage();
		var image2 = ImageManager.GetRandomItemImage();
		var image3 = ImageManager.GetImage(10);
		ImageManager.ShuffleImages();
		var image4 = ImageManager.GetImage(10);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
