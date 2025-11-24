using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public GameObject Player;
    public float speed;
    Vector2 mousePOS;
    Vector3 direction;


    void Update()
    {
        //movement input

        mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //shooting
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shoot();
        }
        //dashing

        //runing stmaina

    }

    private void FixedUpdate()
    {

        rb.linearVelocity = Direction() * speed;
        //look at mouse
        Vector2 lookDir = mousePOS - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    Vector3 Direction()
    {
        float h;
        float v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = new Vector3(h, v, 0);

        return direction;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Physics2D.OverlapCircle(Player.transform.position, 0.05f);
        if (other.gameObject.tag == "BigRoom")
        {
            Debug.Log("hi");
        }
    }
}
