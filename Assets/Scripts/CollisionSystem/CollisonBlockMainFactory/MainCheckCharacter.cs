using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCheckCharacter : ICollision<BlockBase>
{
    public void HanderCollision(BlockBase block, Collider2D collider, Vector3 dir)
    {
        if (collider != null)
        {
            BlockCharacter blockcharacter = collider.GetComponent<BlockCharacter>();
            block.isMovingDown = blockcharacter.isMovingDown;
            block.isMovingLeft = blockcharacter.isMovingLeft;
            block.isMovingRight = blockcharacter.isMovingRight;
            block.isMovingUp = blockcharacter.isMovingUp;
            EventManager.instance.TriggerEvent(TyperEvent.E_MovingCharacter);

        }
    }
}
