using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;
public abstract class BlockBase : MonoBehaviour
{
    protected IState currentState;
    public CollisonTyper blockInfor;
    public CollisionDirection collisionDirection;

    public float moveInterval = 0.2f;
    public bool isMoving = false;
    public Vector3 dirMover;
    public LayerMask m_LayerMask;
    public float m_Distance = 1f;

    public bool isMovingLeft;
    public bool isMovingRight;
    public bool isMovingUp;
    public bool isMovingDown;

    public bool isTest = false;
    public virtual void Start()
    {
        ChangeState(new IdleState(this));
        ResetMoving();
    }

    public virtual void Update()
    {
        currentState.Upgrade();
     
    }

    public void MoveBlock(Vector3 dir)
    {
        this.transform.Translate(dir * 1f);
    }


    public virtual void RaycastTarget()
    {
        CheckCollision(Vector3.up);
        CheckCollision(Vector3.down);
        CheckCollision(Vector3.left);
        CheckCollision(Vector3.right);
    }

    public virtual void CheckCollision(Vector3 dir)

    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, m_Distance, m_LayerMask);
        if (hit.collider != null)
        {
            HandleCollision(hit.collider, dir);
        }

    }
    /*public void ActiveMove()
    {
        if (!isMoving)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                isMoving = true;
                InvokeRepeating(nameof(MoveIfKeyHeld), 0f, moveInterval);
            }
        }
        else if (isMoving && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            isMoving = false;
           // collisionDirection = CollisionDirection.None;
            CancelInvoke(nameof(MoveIfKeyHeld));
        }
    }

    void MoveIfKeyHeld()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {

            direction = Vector3.up;
            collisionDirection = CollisionDirection.Up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector3.down;
            collisionDirection = CollisionDirection.Down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            collisionDirection = CollisionDirection.Right;
        }
        if (Input.GetKey(KeyCode.A)) { 
            direction = Vector3.left;
            collisionDirection = CollisionDirection.Left;
        }
        if (direction != Vector3.zero)
        {
            MoveBlock(direction);
        }
    }*/

    /* if (dir == Vector3.up)
     {
         Debug.Log(hit.collider.name);
         isMovingUp = false;
     }
     else if (dir == Vector3.down)
     {
         isMovingDown = false;
         Debug.Log(hit.collider.name);
     }
     else if (dir == Vector3.left)
     {
         isMovingLeft = false;
         Debug.Log(hit.collider.name);
     }
     else if (dir == Vector3.right)
     {
         isMovingRight = false;
         Debug.Log(hit.collider.name);
     }*/


    public virtual void HandleCollision(Collider2D collider, Vector3 dir)
    {
        ICollision<BlockBase> handler = CollBlockBaseFactory.GetCollison(collider.tag);

        if (handler != null)
        {
            handler.HanderCollision(this, collider, dir); // Sử dụng dynamic để gọi phương thức xử lý
        }
    }


    public virtual void ChangeState(IState istate)
    {
        if (currentState != istate)
        {
            currentState = istate;
        }
        currentState.EnterState();
    }
    public virtual void InputController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            collisionDirection = CollisionDirection.Up;
            OnMoving();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            collisionDirection = CollisionDirection.Left;
            OnMoving();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            collisionDirection = CollisionDirection.Down;
            OnMoving();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            collisionDirection = CollisionDirection.Right;
            OnMoving();
        }

    }
    public virtual void OnMoving()
    {
        switch (collisionDirection)
        {
            case CollisionDirection.Up:
                if (isMovingUp == true)
                    ChangeState(new MovingUpState(this));
                break;
            case CollisionDirection.Down:
                if (isMovingDown == true)
                    ChangeState(new MovingDownState(this));
                break;
            case CollisionDirection.Left:
                if (isMovingLeft == true)
                    ChangeState(new MovingLeftState(this));
                break;
            case CollisionDirection.Right:
                if (isMovingRight == true)
                    ChangeState(new MovingRightState(this));

                break;
        }
   
    }

    public virtual void ResetMoving()
    {
        isMovingDown = true;
        isMovingLeft = true;
        isMovingUp = true;
        isMovingRight = true;
    }
    #region MovingUp;
    public virtual void OnEnterMovingUP()
    {
        MoveBlock(Vector3.up);
        ResetMoving();
    }
    public virtual void OnUpdateMovingUp()
    {
    }
    public virtual void OnExitMovingUp()
    {
    }
    #endregion

    #region MovingDown;
    public virtual void OnEnterMovingDown()
    {
        MoveBlock(Vector3.down);
        ResetMoving();
    }
    public virtual void OnUpdateMovingDown()
    {

    }
    public virtual void OnExitMovingDown()
    {
    }
    #endregion

    #region MovingLeft
    public virtual void OnEnterMovingLeft()
    {
        MoveBlock(Vector3.left);
        ResetMoving();
    }
    public virtual void OnUpdateMovingLeft()
    {
    }
    public virtual void OnExitMovingLeft()
    {
    }

    #endregion

    #region MovingRight
    public virtual void OnEnterMovingRight()
    {
        MoveBlock(Vector3.right);
        ResetMoving(); 
    }
    public virtual void OnUpdateMovingRight()
    {
    }
    public virtual void OnExitMovingRight()
    {
    }

    #endregion
    public void Check(Vector3 dir)
    {
    
    }

}


public enum CollisionDirection
{
    Up,
    Down,
    Left,
    Right,
    None
}

public enum CollisonTyper
{
    MainBlock,
    Red,
    Green,
    Blue,
    Yellow,
}
