using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCommand : ICommand
{
    private float _distance;
    private Vector3 _previousPosition;

    public MovingCommand(float distance)
    {
        _distance = distance;
    }

    public void Execute(Transform transform, Vector3 dir)
    {
        _previousPosition = transform.position;
        transform.position += dir * _distance;
    }

    public void Undo(Transform transform)
    {
        transform.position = _previousPosition;
    }
}
