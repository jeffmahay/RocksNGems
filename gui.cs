using Raylib_cs;
using System.Numerics;

namespace RocksNGems
{
    static class GUI
    {
        public static void Main()
        {
            var screenHeight = 480;
            var screenWidth = 800;

            Raylib.InitWindow(screenWidth, screenHeight, "RocksNGems");
            Raylib.SetTargetFPS(60);

            var Objects = new List<Physics>();
            var rand = new Random();

            var maxObj = 99999;

            Control control = new Control();

            while (!Raylib.WindowShouldClose())
            {
                // Gem specifications
                int xPos = rand.Next(screenWidth);
                int yPos = 0;
                var position = new Vector2(xPos, yPos);

                int xPos2 = rand.Next(screenWidth);
                int yPos2 = 0;
                var position2 = new Vector2(xPos2, yPos2);
                
                string xDirection = control.getXMove();
                string yDirection = control.getYMove();

                var gem = new Gems(Color.PURPLE, "*", 20);
                gem.position = position;
                gem.velocity = new Vector2(0,1);
                Objects.Add(gem);

                var rock = new Rocks(Color.RED, 20);
                rock.position = position2;
                rock.velocity = new Vector2(0,1);
                Objects.Add(rock);

                // Character specifications
                int charX = (screenWidth / 2);
                int charY = (screenHeight - 100);
                var charPos = new Vector2(charX, charY);

                var character = new Character(Color.WHITE, "#", 20);
                character.position = charPos;
                //character.Velocity = 




                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                
                character.Draw();

                foreach (var obj in Objects)
                {
                    obj.Draw();
                }

                Raylib.DrawText($"{Objects.Count}",0,100,40,Color.WHITE);

                Raylib.EndDrawing();

                // Move all of the objects to their next location
                foreach (var obj in Objects)
                {
                    obj.Move();
                }
            }
        }
    }
}