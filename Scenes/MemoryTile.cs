using Godot;
using System;

public partial class MemoryTile : TextureButton
{
	public const string GroupName = "tile";

	[Export] private TextureRect frameImage;
	[Export] private TextureRect itemImage;

	private string itemName = string.Empty;
	private int index = -1;
	private bool canSelect = true;

	public string ItemName { get => itemName; }
	public int Index { get => index; }
	public override void _Ready()
	{
		Pressed += OnPressed;
		SignalManager.Instance.OnSelectionDisabled += OnSelectionDisabled;
		SignalManager.Instance.OnSelectionEnabled += OnSelectionEnabled;
	}
	public override void _ExitTree()
	{
		SignalManager.Instance.OnSelectionDisabled -= OnSelectionDisabled;
		SignalManager.Instance.OnSelectionEnabled -= OnSelectionEnabled;
	}

	public void KillOnSuccess()
	{
		ZIndex = 100;
		// var tween = GetTree().CreateTween();
		// tween.SetParallel(true);
		// tween.TweenProperty(this, "disabled", true, 0f);
		// tween.TweenProperty(this, "scale", new Vector2(2.0f, 2.0f), 0.5f);
		// tween.TweenProperty(this, "rotation_degrees", 720.0f,  0.5f);
		// tween.SetTrans(Tween.TransitionType.Sine);
		// tween.SetParallel(false);
		// tween.TweenInterval(0.5f);
		// tween.TweenProperty(this, "scale", Vector2.Zero, 0.5f);

	}
    private void OnSelectionEnabled(MemoryTile tile)
    {
        canSelect = true;
    }


    private void OnSelectionDisabled(MemoryTile tile)
    {
        canSelect = false;
    }

    private void OnPressed()
	{
		if (canSelect)
		{
			Reveal(true);
			SignalManager.EmitOnTileSelected(this);
		}
	}

	public void Setup(ItemImage data, Texture2D frameImage, int index)
	{
		itemImage.Texture = data.itemTexture;
		this.frameImage.Texture = frameImage;
		this.index = index;
		itemName = data.itemName;
		Reveal(false);
	}

	public void Reveal(bool reveal)
	{
		itemImage.Visible = reveal;
		frameImage.Visible = reveal;
	}
}
