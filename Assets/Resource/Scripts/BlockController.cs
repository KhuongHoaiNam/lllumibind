using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Stack<ICommand> m_HistoryCommand;
    public Stack<Vector3> m_HistoryPosistion;
    public Vector3 pos;
    public ICommand m_Moving;
    public float m_Movedistance;



    public bool m_CanControl;
    public bool m_CanPush;
    public Collider2D m_Collider;


    public void Start()
    {
        pos = this.gameObject.transform.position;
        m_Moving = new MovingCommand(m_Movedistance);
        m_HistoryCommand = new Stack<ICommand>();
        m_HistoryPosistion = new Stack<Vector3>();  // Khởi tạo Stack lưu vị trí
        m_HistoryPosistion.Push(pos);
        BlockManager.instance.AddBlock(this);
        if (m_CanControl)
        {
            BlockManager.instance.AddMovingBlock(this);
        }
    }

/*    public void Update()
    {

        // Sử dụng các phím WASD để di chuyển
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnMoving(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            OnMoving(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            OnMoving(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnMoving(Vector3.right);
        }
    }*/

    public void OnMoving(Vector3 dir)
    {
        if (dir == Vector3.up)
        {
            ExecuteCommand(m_Moving, dir);
        }
        else if (dir == Vector3.down)
        {
            ExecuteCommand(m_Moving, dir);
        }
        else if(dir == Vector3.left)
        {
            ExecuteCommand(m_Moving, dir);
        }
        else if (dir == Vector3.right)
        {
            ExecuteCommand(m_Moving, dir);
        }

    }


    public void ExecuteCommand(ICommand icommand, Vector3 dir)
    {
        icommand.Execute(transform, dir);
        m_HistoryCommand.Push(icommand);
        m_HistoryPosistion.Push(transform.position);
    }

    public void UndoToPreviousPosition()
    {
        if (m_HistoryPosistion.Count > 0)
        {
            Vector3 previousPosition = m_HistoryPosistion.Pop();  // Lấy vị trí trước đó
            transform.position = previousPosition;  // Quay lại vị trí đó
        }
        else
        {
            // Debug.Log("No previous position to return to.");
            this.transform.position = pos;
        }
    }


    /*  // Danh sách lưu các khối đã kiểm tra để tránh vòng lặp vô hạn
      private HashSet<GameObject> checkedBlocks = new HashSet<GameObject>();

      // Kích hoạt kiểm tra va chạm khi khối được di chuyển
      void Update()
      {
          if (Input.GetKeyDown(KeyCode.Space)) // Kích hoạt kiểm tra khi nhấn Space
          {
              checkedBlocks.Clear(); // Reset danh sách trước mỗi lần kiểm tra
              CheckCollisionRecursive(gameObject);
          }
      }

      /// <summary>
      /// Hàm kiểm tra va chạm đệ quy
      /// </summary>
      /// <param name="currentBlock">Khối hiện tại</param>
      public void CheckCollisionRecursive(GameObject currentBlock)
      {
          // Nếu khối đã kiểm tra, bỏ qua
          if (checkedBlocks.Contains(currentBlock)) return;

          // Thêm khối hiện tại vào danh sách đã kiểm tra
          checkedBlocks.Add(currentBlock);

          // Lấy Collider2D của khối hiện tại
          Collider2D currentCollider = currentBlock.GetComponent<Collider2D>();
          if (currentCollider == null) return; // Không có Collider thì thoát

          // Kiểm tra va chạm với các khối khác
          Collider2D[] collisions = Physics2D.OverlapBoxAll(
              currentCollider.bounds.center, // Tâm của BoxCollider
              currentCollider.bounds.size,   // Kích thước của BoxCollider
              0                              // Góc xoay (nếu có)
          );

          foreach (Collider2D collision in collisions)
          {
              // Bỏ qua chính nó
              if (collision.gameObject == currentBlock) continue;

              // Xác định hướng va chạm
              string collisionDirection = GetCollisionDirection(currentBlock, collision.gameObject);

              // Log thông tin va chạm
              Debug.Log($"Collision detected: {currentBlock.name} -> {collision.gameObject.name} | Direction: {collisionDirection}");

              // Gọi đệ quy kiểm tra khối va chạm
              CheckCollisionRecursive(collision.gameObject);
          }
      }

      /// <summary>
      /// Xác định hướng va chạm theo "trên", "dưới", "trái", "phải"
      /// </summary>
      /// <param name="currentBlock">Khối hiện tại</param>
      /// <param name="otherBlock">Khối va chạm</param>
      /// <returns>Hướng va chạm dưới dạng chuỗi</returns>
      private string GetCollisionDirection(GameObject currentBlock, GameObject otherBlock)
      {
          Vector2 currentPos = currentBlock.transform.position;
          Vector2 otherPos = otherBlock.transform.position;

          // So sánh vị trí để xác định hướng
          float xDiff = otherPos.x - currentPos.x; // Chênh lệch x
          float yDiff = otherPos.y - currentPos.y; // Chênh lệch y

          // Kiểm tra hướng
          if (Mathf.Abs(xDiff) > Mathf.Abs(yDiff))
          {
              if (xDiff > 0) return "Right";  // Sang phải
              else return "Left";            // Sang trái
          }
          else
          {
              if (yDiff > 0) return "Up";    // Lên trên
              else return "Down";           // Xuống dưới
          }
      }

      // Vẽ gizmo để kiểm tra vùng va chạm trong Scene View
      private void OnDrawGizmos()
      {
          Collider2D collider = GetComponent<Collider2D>();
          if (collider != null)
          {
              Gizmos.color = Color.green;
              Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
          }
      }*/
}
