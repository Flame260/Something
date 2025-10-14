using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public Rigidbody2D rb;
    public Weapon weapon;

    Vector2 movement;
    Vector2 mousePOS;


    void Update()
    {
        //movement input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal,moveVertical).normalized;

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
        //look at mouse
        Vector2 lookDir = mousePOS - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
