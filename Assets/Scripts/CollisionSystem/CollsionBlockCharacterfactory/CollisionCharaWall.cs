using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCharaWall : ICollision<BlockCharacter>
{
    public void HanderCollision(BlockCharacter block, Collider2D collider, Vector3 dir)
    {

        if (dir == Vector3.up)
        {
            Debug.Log("Va chạm từ hướng trên");
            block.isMovingUp = false;
        }
        else if (dir == Vector3.down)
        {
            Debug.Log("Va chạm từ hướng dưới");
            block.isMovingDown = false;
        }
        else if (dir == Vector3.left)
        {
            Debug.Log("Va chạm từ hướng trái");
            block.isMovingLeft = false;
        }
        else if (dir == Vector3.right)
        {
            Debug.Log("Va chạm từ hướng phải");
            block.isMovingRight = false;
        }
    }
}
