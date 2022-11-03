using Raylib_cs;
using System.Numerics;

class Control
{
    public string getXMove()
    {
        bool keyLeft = Raylib.IsKeyDown(KeyboardKey.KEY_A);
        bool keyRight = Raylib.IsKeyDown(KeyboardKey.KEY_D);

        if (keyLeft == true && keyRight == false)
        {
            return "left";
        }
        if (keyLeft == false && keyRight == true)
        {
            return "right";
        }
        else
        {
            return "void";
        }
    }

    public string getYMove()
    {
        bool keyUp = Raylib.IsKeyDown(KeyboardKey.KEY_W);
        bool keyDown = Raylib.IsKeyDown(KeyboardKey.KEY_S);

        if (keyUp == true && keyDown == false)
        {
            return "up";
        }
        if (keyUp == false && keyDown == true)
        {
            return "down";
        }
        else
        {
            return "void";
        }
    }
}