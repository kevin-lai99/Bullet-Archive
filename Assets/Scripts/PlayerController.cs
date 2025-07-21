using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
  bool flip = false;
  private BoardManager m_Board;
  private Vector2Int m_CellPosition;
  private bool isMoving = false;
  public float moveDuration = 0.2f; // Smooth movement duration

  public void Spawn(BoardManager boardManager, Vector2Int cell)
  {
    m_Board = boardManager;
    m_CellPosition = cell;
    transform.position = m_Board.CellToWorld(cell);
  }

  private void Update()
  {
  if (isMoving) return;
    Vector2Int newCellTarget = m_CellPosition;
    
    if (Keyboard.current.upArrowKey.isPressed)
    {
      newCellTarget.y += 1;
    }
    else if (Keyboard.current.downArrowKey.isPressed)
    {
      newCellTarget.y -= 1;
    }
    else if (Keyboard.current.rightArrowKey.isPressed)
    {
      newCellTarget.x += 1;
      if (flip)
      {
        Vector3 scale = transform.localScale;
        scale.x *= -1.0f;
        transform.localScale = scale;
        flip = false;
      }
      

    }
    else if (Keyboard.current.leftArrowKey.isPressed)
    {
      newCellTarget.x -= 1;
      if (!flip)
      {
        Vector3 scale = transform.localScale;
        scale.x *= -1.0f;
        transform.localScale = scale;
        flip = true;
      }
      
    }
        BoardManager.CellData cellData = m_Board.GetCellData(newCellTarget);

        if (cellData != null && cellData.Passable)
        {
            StartCoroutine(SmoothMove(newCellTarget));
        }
    }

    private IEnumerator SmoothMove(Vector2Int targetCell)
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = m_Board.CellToWorld(targetCell);

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        m_CellPosition = targetCell;
        isMoving = false;
    }
}
