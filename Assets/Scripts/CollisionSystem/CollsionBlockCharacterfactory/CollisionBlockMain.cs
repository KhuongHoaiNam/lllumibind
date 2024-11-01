using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CollisionBlockMain : ICollision<BlockCharacter>
{
    public void HanderCollision(BlockCharacter block, Collider2D collider, Vector3 dir)
    {

        BlockMain blockBase = collider.GetComponent<BlockMain>();
        if (dir == Vector3.up)
        {
            if (blockBase != null)
            {
                if (blockBase.collisionDirection == CollisionDirection.Down && block.isMovingDown == true)
                {
                    block.m_input = true;
                    blockBase.m_IsMovingCharacter?.Invoke();
                }
                else
                {

                    block.m_input = false;
                }
            }

        }
        else if (dir == Vector3.down)
        {
            if (blockBase != null)
            {
                if (blockBase.collisionDirection == CollisionDirection.Up && block.isMovingUp == true)
                {
                    block.m_input = true;
                    blockBase.m_IsMovingCharacter?.Invoke();
                }
                else
                {

                    block.m_input = false;
                }
            }

        }
        else if (dir == Vector3.left)
        {
            if (blockBase != null)
            {
                if (blockBase.collisionDirection == CollisionDirection.Right && block.isMovingLeft == true)
                {
                    block.m_input = true;
                    blockBase.m_IsMovingCharacter?.Invoke();
                }
                else
                {
                    block.m_input = false;
                }
            }
        }
        else if (dir == Vector3.right)
        {
            if (blockBase != null)
            {
                if (blockBase.collisionDirection == CollisionDirection.Left && block.isMovingRight)
                {
                    block.m_input = true;
                    blockBase.m_IsMovingCharacter?.Invoke();
                }
                else
                {

                    block.m_input = false;
                }
            }
        }

     /*   if (dir == Vector3.up)
        {
            Debug.Log("Va chạm từ hướng trên");
            block.isMovingDown = true;
        }
        else if (dir == Vector3.down)
        {
            Debug.Log("Va chạm từ hướng dưới");
            block.isMovingUp = true;
        }
        else if (dir == Vector3.left)
        {
            Debug.Log("Va chạm từ hướng trái");
            block.isMovingRight = true;
        }
        else if (dir == Vector3.right)
        {
            Debug.Log("Va chạm từ hướng phải");
            block.isMovingLeft = true;
        }
*/
    }


}
