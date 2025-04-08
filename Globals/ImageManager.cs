using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Godot;


public partial class ImageManager : Node
{
	public static ImageManager Instance { get; private set; }
	private Godot.Collections.Array<ItemImage> itemImages = new();

	private static readonly List<Texture2D> FrameImages = new List<Texture2D>
	{
		GD.Load<Texture2D>("res://Resources/frames/blue_frame.png"),
		GD.Load<Texture2D>("res://Resources/frames/green_frame.png"),
		GD.Load<Texture2D>("res://Resources/frames/red_frame.png"),
		GD.Load<Texture2D>("res://Resources/frames/yellow_frame.png")
	};

	public static Texture2D getRandomFrame()
	{
		return FrameImages[GD.RandRange(0, FrameImages.Count)];
	}
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
	public static List<ItemImage> GetRandomImagePairs(int numOfPairs)
	{
		List<ItemImage> imagePairs = new List<ItemImage>();

		ShuffleImages();

		for (int i = 0; i < numOfPairs; i++)
		{
			imagePairs.Add(GetImage(i));
			imagePairs.Add(GetImage(i));
		}
		return imagePairs;
	}

	public static List<ItemImage> GetRandomImagePairsShuffled(int numOfPairs)
	{
		return GetRandomImagePairs(numOfPairs).OrderBy(x => Guid.NewGuid()).ToList();
	}

	// public void  
}
