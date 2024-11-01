using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollBlockBaseFactory
{
    public static ICollision<BlockBase> GetCollison(string TagName)
    {
        switch (TagName)
        {

            case "Retaining Wall":
                return new MainCheckWall();
            case "Block Character":
                return new MainCheckCharacter();
            default:
                return null;

        }
    }
}
