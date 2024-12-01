
using UnityEngine;

public interface ICommand
{
    public void Execute(Transform pos, Vector3 dir);

    public void Undo(Transform pos);
}
