using Raylib_cs;
using System.Numerics;

class Hitbox : Physics
{
    public int Size = 20;
    public void DrawHitbox()
    {
        Raylib.DrawRectangle((int)position.X, (int)position.Y, Size, Size, Color.BLANK);
    }
}