using System;
using System.IO;
using Godot;


public partial class ImageManager : Node
{
	public static ImageManager Instance { get; private set; }
	private Godot.Collections.Array<ItemImage> itemImages = new();
	public override void _Ready()
	{
		Instance = this;
		LoadImages();
	}

	private void AddFileToList(string filePath)
	{
		itemImages.Add(new ItemImage
		{
			ItemName = Path.GetFileNameWithoutExtension(filePath),
			itemTexture = GD.Load<Texture2D>(filePath)
		});
	}

	private void LoadImages()
	{
		var imResource = GD.Load<ImageFilesList>("res://Resources/ImageFilesList.tres");
		foreach (string filePath in imResource.FileNames)
		{
			AddFileToList(filePath);
		}
	}

	public static ItemImage GetRandomItemImage()
	{
		return Instance.itemImages.PickRandom();
	}
	public static ItemImage GetImage(int index)
	{
		return Instance.itemImages[index];
	}

	public static void ShuffleImages()
	{
		Instance.itemImages.Shuffle();
	}
}
