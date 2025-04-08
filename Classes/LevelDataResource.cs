using Godot;

[GlobalClass]
public partial class LevelDataResource : Resource
{
    [Export] public int LevelNumber { get; set; }
    [Export] public int Rows { get; set; }
    [Export] public int Columns { get; set; }
    public int TotalImages { get { return Rows * Columns; } }
    public int TargetPairs { get { return TotalImages / 2; } }
}