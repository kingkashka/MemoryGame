using Godot;
using System;


public partial class ImageFileMaker : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Load all image files from the specified directory and save them to a resource file
		string path = "res://assets/glitch";
		DirAccess dir = DirAccess.Open(path);
		ImageFilesList imageList = new ImageFilesList();
		string[] fileNames = dir.GetFiles();

		if (fileNames == null)
		{
			GD.PrintErr("Failed to open directory: " + path);
			return;
		}
		else
		{
			foreach (string file in fileNames)
			{
				if (!file.Contains(".import"))
				{
					// Adding the image file to list}");
					imageList.FileNames.Add($"{path}/{file}");
					GD.Print("Loading image file: " + file);
				}

			}

			ResourceSaver.Save(imageList, "res://Resources/ImageFilesList.tres");
		}

	}
}
