using Godot;

[GlobalClass]
public partial class Weapon : Resource
{
    [Export] private int damage;
    [Export] private int delay;
    [Export] private string weaponName;
    [Export] private Texture2D texture;
    public Texture2D Texture => texture;

    public override string ToString()
    {
        return $"Weapon: {weaponName}, Damage: {damage}, Delay: {delay}";
    }
}