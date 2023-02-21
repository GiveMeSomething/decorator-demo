using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField]
  private float speed = 5f;

  private Rigidbody2D rb;

  public Vector2 Direction { get; set; }

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Direction == null)
    {
      return;
    }

    // Destroy bullet if it goes out of screen
    if (transform.position.magnitude > 10f)
    {
      Destroy(gameObject);
    }

    // Move bullet forward
    rb.velocity = Direction * speed;
  }
}