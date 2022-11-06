using Raylib_cs;
using System.Numerics;

class Physics
{
    public Vector2 position { get; set; } = new Vector2(0,0);
    public Vector2 velocity { get; set; } = new Vector2(0,0);

    virtual public void Draw()
    {
        // Empty for now
    }

    public void Move()
    {
        Vector2 newPosition = position;
        newPosition.Y += velocity.Y;
        position = newPosition;
    }
}

class ColoredObject: Physics 
{
    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }
}