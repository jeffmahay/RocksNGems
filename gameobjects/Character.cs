using Raylib_cs;
using System.Numerics;
class Character: ColoredObject
{
    public string Text {get; set; }

    public int Size { get; set; }

    public Character(Color color, string text, int size): base(color)
    {
        Text = text;
        Size = size;
    }
    override public void Draw()
    {
        Raylib.DrawText(Text, (int)position.X, (int)position.Y, Size, Color);
    }
}