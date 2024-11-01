using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftState : IState
{
    public readonly BlockBase m_Block;
    public MovingLeftState(BlockBase block)
    {
        m_Block = block;
    }

    public void EnterState()
    {
        m_Block.OnEnterMovingLeft();
    }

    public void ExitState()
    {
        m_Block.OnExitMovingLeft();
    }

    public void Upgrade()
    {
        m_Block.OnUpdateMovingLeft();
    }
}
