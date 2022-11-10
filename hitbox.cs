using Raylib_cs;
using System.Numerics;

class Hitbox : Physics
{
    public int width = 20;
    public int height = 20;

    public void DrawHitbox()
    {
        Raylib.DrawRectangle((int)position.X, (int)position.Y, width, height, Color.BLACK);
    }
}