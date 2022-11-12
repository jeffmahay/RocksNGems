using Raylib_cs;
using System.Numerics;
class Collisions : Score
{
    public bool checkColl(Hitbox obj, Hitbox character)
    {
        Rectangle objBox = new Rectangle((int)obj.position.X, (int)obj.position.Y, obj.Size, obj.Size);
        Rectangle charBox = new Rectangle((int)character.position.X, (int)character.position.Y, character.Size, character.Size);
        return Raylib.CheckCollisionRecs(objBox, charBox);
    }
}
