using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpState : IState
{
    public readonly BlockBase m_Block;
    public MovingUpState(BlockBase block)
    {
        m_Block = block;
    }

    public void EnterState()
    {
        m_Block.OnEnterMovingUP();
    }

    public void ExitState()
    {
        m_Block.OnEnterMovingDown();
    }

    public void Upgrade()
    {
        m_Block.OnUpdateMovingUp();
    }
}
