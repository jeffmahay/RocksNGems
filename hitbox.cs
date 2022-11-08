using Raylib_cs;
using System.Numerics;

class Hitbox : Physics
{
    public void DrawHitbox()
    {
        Raylib.DrawRectangle((int)position.X, (int)position.Y, 15, 15, Color.BLACK);
    }
}