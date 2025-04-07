using Godot;
using System;

public partial class FrontSprite : TextureRect
{
	private static readonly Vector2 SPINTIMERANGE = new Vector2(1.0f, 2.0f);
	private const float scaleTime = 1.0f;
	public override void _Ready()
	{
		RunMe();
	}



	private void SetRandomImage()
	{
		Texture = ImageManager.GetRandomItemImage().itemTexture;
	}
	private float GetRandomSpinTime()
	{
		GD.Print("GetRandomSpinTime");
		return (float)GD.RandRange(SPINTIMERANGE.X, SPINTIMERANGE.Y);
	}
	private float GetRandomRotation()
	{
		GD.Print("GetRandomRotation");
		return (float)GD.RandRange(0.0f, 360.0f);
	}
	private void RunMe()
	{
		Tween tween = GetTree().CreateTween();
		
		tween.TweenProperty(this, "scale", Vector2.Zero, scaleTime);
		tween.TweenCallback(Callable.From(SetRandomImage));
		tween.TweenProperty(this, "scale", new Vector2(1, 1), scaleTime);
		tween.TweenProperty(this, "rotation", GetRandomRotation(), GetRandomSpinTime());
		tween.TweenCallback(Callable.From(RunMe));
	}
}
