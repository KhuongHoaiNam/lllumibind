using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRightState : IState
{
    public readonly BlockBase m_Block;
    public MovingRightState(BlockBase block)
    {
        m_Block = block;
    }

    public void EnterState()
    {
        m_Block.OnEnterMovingRight();
    }

    public void ExitState()
    {
        m_Block?.OnExitMovingRight();
    }

    public void Upgrade()
    {
        m_Block.OnUpdateMovingRight();
    }
}
