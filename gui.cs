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

                var gem = new Gems(Color.PURPLE, "*", 20);
                gem.position = position;
                gem.velocity = new Vector2(5, 5);
                gems.Add(gem);

                var gemHit = new Hitbox();
                var thisGem = gems.Last();
                var gemHitX = thisGem.position.X;
                var gemHitY = thisGem.position.Y;
                var gemHitV = thisGem.velocity;
                gemHits.Add(gemHit);

                var rock = new Rocks(Color.RED, 20);
                rock.position = position2;
                rock.velocity = new Vector2(5, 5);
                rocks.Add(rock);

                var rockHit = new Hitbox();
                var thisRock = rocks.Last();
                var rockHitX = thisRock.position.X;
                var rockHitY = thisRock.position.Y;
                var rockHitV = thisRock.velocity;
                rockHits.Add(rockHit);

            
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

                // if (isOver(score) == true)
                // {
                //     Raylib.DrawText("Game Over!",screenWidth / 2,100,40,Color.WHITE);
                // }
            }
        }
    }
}