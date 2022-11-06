using Raylib_cs;
using System.Numerics;

class Rocks: ColoredObject
{
    public int Size { get; set; }

    public Rocks(Color color, int size): base(color) {
        Size = size;
    }
    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)position.X, (int)position.Y, Size, Size, Color);
    }
}