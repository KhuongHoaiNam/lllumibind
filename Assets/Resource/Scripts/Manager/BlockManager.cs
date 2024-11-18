using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : SingletonMono<BlockManager>
{
   

    public List<BlockController> m_BlockController;
    public List<BlockController> m_BlockMoving;



    public void AddBlock(BlockController Block)
    {
        m_BlockController.Add(Block);
    }

    public void RemoveBlockController(BlockController block)
    {
        m_BlockController.Remove(block);
    }

    public void AddMovingBlock(BlockController block)
    {
        m_BlockMoving.Add(block);
    }

    public void RemoveBlockMoving(BlockController blockMoving)
    {
        m_BlockMoving.Remove(blockMoving);
    }
    public void Moving()
    {

    }
}
