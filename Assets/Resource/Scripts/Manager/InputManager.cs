using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMono<InputManager>
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            BlockManager.instance.Moving(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            BlockManager.instance.Moving(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            BlockManager.instance.Moving(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            BlockManager.instance.Moving(Vector3.down);
        }
    }

}
