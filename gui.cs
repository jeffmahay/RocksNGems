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

            var gems = new List<Gems>();
            var rand = new Random();

            Control control = new Control();
            Character character = new Character();

            while (!Raylib.WindowShouldClose())
            {
                int xPos = rand.Next(1920);
                int yPos = 0;
                var position = new Vector2(xPos, yPos);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                character.Draw();
                
                string xDirection = control.getXMove();
                string yDirection = control.getYMove();

                var gem = new Gems(Color.PURPLE);
                gem.position = position;
                gem.velocity = new Vector2(0,-2);
                gems.Add(gem);

                foreach (var item in gems)
                {
                    item.Draw();
                }

                Raylib.DrawText($"{xDirection}{yDirection}",0,100,40,Color.WHITE);

                Raylib.EndDrawing();

                foreach (var item in gems)
                {
                    item.Move();
                }
            }
        }
    }
}