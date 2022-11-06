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
            Raylib.SetTargetFPS(20);

            var Objects = new List<Physics>();
            
            var rand = new Random();

            // Character specifications
            int charX = (screenWidth / 2);
            int charY = (screenHeight - 100);
            var charPos = new Vector2(charX, charY);
            var charMovementSpeed = 5;
            int charSize = 20;

            Control control = new Control();
            Collisions coll = new Collisions();
            Score score = new Score();

            while (!Raylib.WindowShouldClose())
            {
                // Gem specifications
                int xPos = rand.Next(screenWidth);
                int yPos = 0;
                var position = new Vector2(xPos, yPos);

                int xPos2 = rand.Next(screenWidth);
                int yPos2 = 0;
                var position2 = new Vector2(xPos2, yPos2);
                // string xDirection = control.getXMove();
                // string yDirection = control.getYMove();

                var gem = new Gems(Color.PURPLE, "*", 20);
                gem.position = position;
                gem.velocity = new Vector2(5, 5);
                Objects.Add(gem);

                var rock = new Rocks(Color.RED, 20);
                rock.position = position2;
                rock.velocity = new Vector2(5, 5);
                Objects.Add(rock);

            
                var character = new Character(Color.WHITE, "#", charSize);
                
                if (control.getXMove() == "right") {
                    charPos.X += charMovementSpeed;
                }

                if (control.getXMove() == "left") {
                    charPos.X -= charMovementSpeed;
                }

                if (control.getYMove() == "up") {
                    charPos.Y -= charMovementSpeed;
                }

                if (control.getYMove() == "down") {
                    charPos.Y  += charMovementSpeed;
                }
                
                character.position = charPos;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                
                character.Draw();

                foreach (var obj in Objects)
                {
                    obj.Draw();
                }

                // Raylib.DrawText($"{xDirection}{yDirection}",0,200,40,Color.WHITE);

                Raylib.DrawText($"{Objects.Count}",0,100,40,Color.WHITE);

                Raylib.EndDrawing();

                foreach (var obj in Objects)
                {
                    bool touchGem = coll.touchCheckGem(obj, character);
                    bool touchRock = coll.touchCheckRocks(obj, character);
                    if (touchGem == true)
                    {
                        Objects.Remove(obj);
                        score.score += 100;

                    }
                    if (touchRock == true)
                    {
                        Objects.Remove(obj);
                        score.score -= 50;
                    }
                }

                // Move all of the objects to their next location
                foreach (var obj in Objects)
                {
                    obj.Move();
                }

                // if (isOver(score) == true)
                // {
                //     Raylib.DrawText("Game Over!",screenWidth / 2,100,40,Color.WHITE);
                // }
            }
        }
    }
}