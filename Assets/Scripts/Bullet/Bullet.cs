using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public Vector2 velocity;
  public float speed;
  public float rotation;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
    transform.Translate(velocity * speed * Time.deltaTime);
    }
}
