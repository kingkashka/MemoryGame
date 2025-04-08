using Godot;
using System.Linq;

public partial class GameManager : Node
{
	private readonly LevelsResource levels = GD.Load<LevelsResource>("res://Resources/LevelsResource.tres");
	public static GameManager Instance { get; private set; }
	
	public override void _Ready()
	{
		Instance = this;
	}

public static Godot.Collections.Array<LevelDataResource> GetLevels() 
	{
		return Instance.levels.Levels;
	}
	public static LevelDataResource GetLevelData(int levelNum)
	{
		return GetLevels().FirstOrDefault(level => level.LevelNumber == levelNum);
	}
}
