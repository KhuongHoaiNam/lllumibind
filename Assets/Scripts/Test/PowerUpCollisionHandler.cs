using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollisionHandler : ICollisionHandler
{
    public void HandleCollision(Collider2D collider)
    {
        Debug.Log("Nhặt vật phẩm! Tăng sức mạnh.");
        // Logic cho vật phẩm: Có thể tăng sức mạnh, điểm số, hoặc xóa vật phẩm khỏi scene.
        
    }
}
