using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlockMain : BlockBase
{

    public override void Update()
    {
        base.Update();
        RaycastTarget();
        InputController();
      //  ActiveMove();
    }

   /* public override void CheckCollision(Vector3 dir)
    {
        base.CheckCollision(dir);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, m_Distance, m_LayerMask);
        if (hit.collider != null)
        {
            if (dir == Vector3.up)
            {

            }
            else if (dir == Vector3.down)
            {

            }
            else if (dir == Vector3.left)
            {

            }
            else if (dir == Vector3.right)
            {
            }
        }
    }*/
}
