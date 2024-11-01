using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CollisionBlockCharFactory 
{
    public static ICollision<BlockCharacter> GetCollision(string name)
    {
        switch (name)
        {
            case "Retaining Wall":
                return new CollisionCharaWall();
            case "Block Main":
                return new CollisionBlockMain();
            default:
                return null;
        }
    }
}
