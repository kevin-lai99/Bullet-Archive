
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
  public GameObject bulletResource;

  public float minRotation;
  public float maxRotation;
  public int numberOfBullets;
  public bool isRandom;
  public float cooldown;

  float timer;
  public float bulletSpeed;

  public Vector2 bulletVelocity;

  float[] rotations;

  void Start()
  {
    timer = cooldown;
    rotations = new float[numberOfBullets];
    if (!isRandom)
    {
      DistributedRotations();
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (timer <= 0)
    {
      SpawnBullets();
      timer = cooldown;

    }
    timer -= Time.deltaTime;
  }

  public float[] RandomRotations()
  {
    for (int i = 0; i < numberOfBullets; i++)
    {
      rotations[i] = Random.Range(minRotation, maxRotation);
    }
    return rotations;
  }

  public float[] DistributedRotations()
  {
    for (int i = 0; i < numberOfBullets; i++)
    {
      var fraction = (float)i / ((float)numberOfBullets -1);
      var difference = maxRotation - minRotation;
      var fractionOfDifference = fraction * difference;
      rotations[i] = fractionOfDifference + minRotation;  // add minRotation to undo Difference
    }
    foreach (var rotation in rotations) print(rotation);
    return rotations;
  }

  public GameObject[] SpawnBullets()
  {
    if (isRandom)
    {
      RandomRotations();
    }

    GameObject[] spawnedBullets = new GameObject[numberOfBullets];

    for (int i = 0; i < numberOfBullets; i++)
    {
      spawnedBullets[i] = Instantiate(bulletResource);
      var bullet = spawnedBullets[i].GetComponent<Bullet>();
      bullet.rotation = rotations[i];
      bullet.velocity = bulletVelocity;
      bullet.speed = bulletSpeed;
    }
    return spawnedBullets;
  }

}
