using Godot;

public partial class ItemImage : GodotObject
{
    internal string itemName;

    public string ItemName { get; set; }
    public Texture2D itemTexture { get; set; }
}