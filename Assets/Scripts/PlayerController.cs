using UnityEngine;

public class PlayerController : MonoBehaviour
{

  [SerializeField]
  private float speed = 5f;
  private float cooldown = 1f;
  private float currentCooldown = 1f;
  private Weapon weapon;

  // Start is called before the first frame update
  void Start()
  {
    weapon = new NullWeapon();
  }

  // Update is called once per frame
  void Update()
  {
    // Control player with WASD
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);

    // Use screen bound to bound player movement
    Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
    pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);
    pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
    transform.position = Camera.main.ViewportToWorldPoint(pos);

    // Use weapon with cooldown
    currentCooldown -= Time.deltaTime;
    if (currentCooldown <= 0)
    {
      currentCooldown = cooldown;
      weapon.Fire();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    // Pick up GUN
    if (collision.gameObject.tag == "Gun")
    {
      weapon = new GunDeco(weapon, gameObject);
      Destroy(collision.gameObject);
    }

    // Pick up WAND
    if (collision.gameObject.tag == "Wand")
    {
      weapon = new WandDeco(weapon, gameObject);
      Destroy(collision.gameObject);
    }
  }
}
