using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    public LayerMask collisionLayers; // Các layer muốn kiểm tra va chạm

    private void Update()
    {
        MoveSquare();
        CheckCollision();
    }

    private void MoveSquare()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void CheckCollision()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; // Sử dụng Vector2 cho không gian 2D
        float distance = 0.5f; // Khoảng cách kiểm tra

        foreach (Vector2 direction in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, collisionLayers);

            if (hit.collider != null) // Kiểm tra nếu có va chạm
            {
                HandleCollision(hit.collider);
            }
        }
    }

    private void HandleCollision(Collider2D collider)
    {
        ICollisionHandler handler = CollisionHandlerFactory.GetHandler(collider.tag);
        if (handler != null)
        {
            handler.HandleCollision(collider);
        }
    }
}
