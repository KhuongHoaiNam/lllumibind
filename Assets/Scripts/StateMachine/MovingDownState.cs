using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDownState : IState
{
    public readonly BlockBase m_Block;
    public MovingDownState(BlockBase block)
    {
        m_Block = block;
    }
    public void EnterState()
    {
        m_Block.OnEnterMovingDown();
    }

    public void ExitState()
    {
        m_Block.OnExitMovingDown();
    }

    public void Upgrade()
    {
        m_Block.OnUpdateMovingDown();
    }


}
