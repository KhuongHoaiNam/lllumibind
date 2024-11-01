using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{

    public readonly BlockBase m_Block;
    public IdleState(BlockBase block)
    {
        m_Block = block;
    }
    public void EnterState()
    {
      //  m_Block.OnEnterMovingIdle();
    }

    public void ExitState()
    {
        //m_Block.OnExitMovingIdle();
    }

    public void Upgrade()
    {
    //    m_Block.OnUpdateMovingIdle();
    }
}
