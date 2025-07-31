using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
  private BoardManager m_Board;
  private Vector2Int m_CellPosition;

  public int startHP;
  int hp;

  public float bulletCooldown;
  float bulletTimer;


  public void Start()
  {
    hp = startHP;
  }

  public void Spawn(BoardManager boardManager, Vector2Int cell)
  {
    m_Board = boardManager;
    m_CellPosition = cell;
    transform.position = m_Board.CellToWorld(cell);
  }


  private void Update()
  {
    bulletTimer -= Time.deltaTime;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Bullet" && bulletTimer <= 0)
    {
      hp -= 1;
      print(hp);
      bulletTimer = bulletCooldown;
    }
  }
}
