
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandlerFactory 
{
    public static ICollisionHandler GetHandler(string tag)
    {
        switch (tag)
        {
            case "Enemy":
                return new PowerUpCollisionHandler();
            default:
                return null; // Hoặc một handler mặc định
        }
    }
}
