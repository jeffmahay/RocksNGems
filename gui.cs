using Raylib_cs;
using System.Numerics;

namespace RocksNGems
{
    static class GUI
    {
        public static void Main()
        {
            var screenHeight = 1080;
            var screenWidth = 1920;

            Raylib.InitWindow(screenWidth, screenHeight, "RocksNGems");
            Raylib.SetTargetFPS(60);

            Control control = new Control();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawRectangle(0,0,50,50,Color.GOLD);
                string xDirection = control.getXMove();
                string yDirection = control.getYMove();

                Raylib.DrawText($"{xDirection}{yDirection}",0,100,40,Color.WHITE);

                Raylib.EndDrawing();
            }
        }
    }
}