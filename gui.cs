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

            var gems = new List<Gems>();
            var rocks = new List<Rocks>();
            var gemHits = new List<Hitbox>();
            var rockHits = new List<Hitbox>();
            
            var rand = new Random();

            // Character specifications
            int charX = (screenWidth / 2);
            int charY = (screenHeight - 100);
            var charPos = new Vector2(charX, charY);
            var charMovementSpeed = 5;
            int charSize = 25;

            Control control = new Control();
            Collisions coll = new Collisions();
            Score score = new Score();
            int points = score.score;

            var frameCount = 0;
            var maxFrameCount = 8;
            var maxGemFrame = 3;
            var maxRockFrame = 1;
            var maxRockFrame2 = 2;


            while (!Raylib.WindowShouldClose())
            {
                frameCount++;

                // Gem specifications
                int xPos = rand.Next(screenWidth);
                int yPos = 0;
                var position = new Vector2(xPos, yPos);

                int xPos2 = rand.Next(screenWidth);
                int yPos2 = 0;
                var position2 = new Vector2(xPos2, yPos2);
                
                if (frameCount == maxGemFrame)
                {
                    var gem = new Gems(Color.PURPLE, "*", 25);
                    gem.position = position;
                    gem.velocity = new Vector2(0,2);
                    gems.Add(gem);

                    var gemHit = new Hitbox();
                    gemHit.position = position;
                    gemHit.velocity = new Vector2(0,2);
                    gemHits.Add(gemHit);
                }
                else if(frameCount == maxRockFrame || frameCount == maxRockFrame2) // The way it is coded now makes it so you must choose one or the other
                {
                    var rock = new Rocks(Color.DARKGRAY, 20);
                    rock.position = position2;
                    rock.velocity = new Vector2(0,2);
                    rocks.Add(rock);

                    var rockHit = new Hitbox();
                    rockHit.position = position2;
                    rockHit.velocity = new Vector2(0,2);
                    rockHits.Add(rockHit);
                }
                else if(frameCount > maxFrameCount)
                {
                    frameCount = 0;
                }

            
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

                // Make character hitbox and have its position be the same as character
                var charBox = new Hitbox();
                charBox.position = charPos;
                

                

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                
                charBox.DrawHitbox();
                character.Draw();

                foreach (var obj in gemHits)
                {
                    obj.DrawHitbox();
                }
                foreach (var obj in gems)
                {
                    obj.Draw();
                }

                foreach (var obj in rockHits)
                {
                    obj.DrawHitbox();
                }
                foreach (var obj in rocks)
                {
                    obj.Draw();
                }
  
                // Raylib.DrawText($"{xDirection}{yDirection}",0,200,40,Color.WHITE);

                Raylib.DrawText($"{gems.Count}",0,100,40,Color.WHITE);
                Raylib.DrawText($"{gemHits[1]}",0,200,40,Color.WHITE);
                Raylib.DrawText($"{rockHits.Count}",0,300,40,Color.WHITE);



                Raylib.EndDrawing();

                // Move all of the objects to their next location
                foreach (var obj in gemHits)
                {
                    obj.Move();
                }
                foreach (var obj in gems)
                {
                    obj.Move();
                }

                foreach (var obj in rockHits)
                {
                    obj.Move();
                }
                foreach (var obj in rocks)
                {
                    obj.Move();
                }


                // if (gems.Count != 0 && rocks.Count != 0)
                // {
                //     for (int i = 0; i <= gems.Count; i++)
                //     {
                //         bool checkGem = coll.checkColl(gemHits[i], charBox);

                //         if (checkGem == true)
                //         {
                //             score.gotGem(points);
                //             gems.RemoveAt(i);
                //             gemHits.RemoveAt(i);
                //         }
                //     }
                //     for (int i = 0; i <= rocks.Count; i++)  
                //     {
                //         bool checkRock = coll.checkColl(rockHits[i], charBox);
                                
                //         if (checkRock == true)
                //         {
                //             score.gotRock(points);
                //             rocks.RemoveAt(i);
                //             rockHits.RemoveAt(i);
                //         }
                //     }
                // }

                Raylib.DrawText($"Points: {points}", 10, 10, 45, Color.WHITE);

                Console.WriteLine($"{gemHits}");
            }
        }
    }
}