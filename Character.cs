using Raylib_cs;
using System.Numerics;
class Character:Physics
{
    override public void Draw()
    {
        Raylib.DrawText("text", position.X, position.Y, 40, Color.GOLD);
    }
}