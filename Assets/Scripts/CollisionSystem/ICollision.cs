
using UnityEngine;

public interface ICollision<in T> where T : class
{
    void HanderCollision(T block, Collider2D collider, Vector3 dir);
}
