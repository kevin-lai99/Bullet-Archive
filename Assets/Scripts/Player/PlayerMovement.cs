using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public float speed;
  bool flip = false;

  // Update is called once per frame
  void Update()
  {
    transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
    
    if (Input.GetAxis("Horizontal") > 0 && flip)
    {
      Vector3 scale = transform.localScale;
      scale.x *= -1.0f;
      transform.localScale = scale;
      flip = false;
    }
    else if (Input.GetAxis("Horizontal") < 0 && !flip)
    {
      Vector3 scale = transform.localScale;
      scale.x *= -1.0f;
      transform.localScale = scale;
      flip = true;
    }
  }
}
