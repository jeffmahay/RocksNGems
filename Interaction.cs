using Raylib_cs;
using System.Numerics;
class Collisions : Score
{
    public bool checkColl(Hitbox obj, Hitbox character)
    {
        Rectangle objBox = new Rectangle((int)obj.position.X, (int)obj.position.Y, obj.width, obj.height);
        Rectangle charBox = new Rectangle((int)character.position.X, (int)character.position.Y, character.width, character.height);
        return Raylib.CheckCollisionRecs(objBox, charBox);
    }
}
