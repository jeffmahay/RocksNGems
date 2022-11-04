using Raylib_cs;
using System.Numerics;

class Gems: Physics
{
    public Color Color { get; set; }

    public Gems(Color preColor)
    {
        Color = preColor;
    }

    public override void Draw()
    {
        Raylib.DrawText("[]", position.X, position.Y, 40, Color);
    }
}