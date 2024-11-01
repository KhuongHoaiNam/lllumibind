using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BlockCharacter : BlockBase
{

    [SerializeField] public bool m_input = false;
    public bool m_collisionWall = false;
    public TyperBlockCharacter m_TyperBlockCharacter;



    public void OnEnable()
    {
        m_IsMovingCharacter += CheckIsMoving;
    }

    public void OnDisable()
    {
        m_IsMovingCharacter -= CheckIsMoving;
    }
    public override void Update()
    {
        base.Update();

        RaycastTarget();
        if (m_input == true)
        {
            InputController();
        }
    }

    public override void RaycastTarget()
    {
        CheckCollision(Vector3.up);
        CheckCollision(Vector3.down);
        CheckCollision(Vector3.left);
        CheckCollision(Vector3.right);
    }

    public override void CheckCollision(Vector3 dir)
    {
        base.CheckCollision(dir);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, m_Distance, m_LayerMask);
        if (hit.collider != null)
        {
            HandleCollision(hit.collider, dir);
            if(m_input == true)
            {
                m_IsMovingCharacter?.Invoke();
            }
          /*  BlockMain blockBase = hit.collider.GetComponent<BlockMain>();
            if (dir == Vector3.up)
            {
                if (blockBase != null)
                {
                    if (blockBase.collisionDirection == CollisionDirection.Down)
                    {
                        this.isMovingDown = true;
                    }
                  
                }
            }
            else if (dir == Vector3.down)
            {
                if (blockBase != null)
                {
                    if (blockBase.collisionDirection == CollisionDirection.Up )
                    {
                        this.isMovingUp = true;
                    }
                    
                }

            }
            else if (dir == Vector3.left)
            {
                if (blockBase != null)
                {
                    if (blockBase.collisionDirection == CollisionDirection.Right )
                    {
                        this.isMovingLeft = true;
                    }
                }
            }
            else if (dir == Vector3.right)
            {
                if (blockBase != null)
                {
                    if (blockBase.collisionDirection == CollisionDirection.Left)
                    {
                        this.isMovingRight = true;
                    }
                }
            }*/

            /* if (dir == Vector3.up)
             {
                 if (blockBase != null)
                 {
                     if (blockBase.collisionDirection == CollisionDirection.Down && this.isMovingDown == true)
                     {
                         m_input = true;
                     }
                     else
                     {

                         m_input = false;
                     }
                 }

             }
             else if (dir == Vector3.down)
             {
                 if (blockBase != null)
                 {
                     if (blockBase.collisionDirection == CollisionDirection.Up && this.isMovingUp == true)
                     {
                         m_input = true;
                     }
                     else
                     {

                         m_input = false;
                     }
                 }

             }
             else if (dir == Vector3.left)
             {
                 if (blockBase != null)
                 {
                     if (blockBase.collisionDirection == CollisionDirection.Right && this.isMovingLeft == true)
                     {
                         m_input = true;
                     }
                     else
                     {
                         m_input = false;
                     }
                 }
             }
             else if (dir == Vector3.right)
             {
                 if (blockBase != null)
                 {
                     if (blockBase.collisionDirection == CollisionDirection.Left && this.isMovingRight)
                     {
                         m_input = true;
                     }
                     else
                     {

                         m_input = false;
                     }
                 }
             }*/
        }

    }

    public override void HandleCollision(Collider2D collider, Vector3 dir)
    {
        base.HandleCollision(collider, dir);

        ICollision<BlockCharacter> handler = CollisionBlockCharFactory.GetCollision(collider.tag);
        if (handler != null)
        {
            handler.HanderCollision(this, collider, dir);
        }
    }

    public void CheckIsMoving()
    {
            m_input = true;
    }

    public void Test()
    {
        this.gameObject.SetActive(false);
    }

    /*    public override void ResetMoving()
        {
            base.ResetMoving();
            isMovingDown = false;
            isMovingLeft = false;
            isMovingRight = false;
            isMovingUp = false;
        }
    */
}

public enum TyperBlockCharacter
{
    none,
    Red,
    Greed,
    Blue,

}