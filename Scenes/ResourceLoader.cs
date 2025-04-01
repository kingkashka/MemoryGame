using Godot;
using System;

public partial class ResourceLoader : Node
{
	[Export] private Weapon weapon1;
	[Export] private Sprite2D weaponImage;

	public override void _Ready()
	{
		GD.Print(weapon1);
		weaponImage.Texture = weapon1.Texture;
	}


}
