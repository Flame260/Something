using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public static PlayerBehaviourScript Instance;
    private Rigidbody2D rb;
    public Weapons weapon;

    private Vector2 mousePos;
    private Vector2 moveDir;

    [Header("Dash Settings")]
    public float dashDis = 2f;
    public float dashDur = 0.1f;
    public int maxDashAmount = 2;
    public float dashCD = 10f;
    private bool isDashing;
    private Vector2 dashDir;
    private int dashAmount;
    private float dashTimer;
    private float dashCDTimer;

    [Header("Player Base Settings")]
    public float baseHP = 100f;
    private float HP;
    public float baseSpeed = 5f;
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = baseHP;
        speed = baseSpeed;
        isDashing = false;
        dashAmount = maxDashAmount;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        DashCD();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            DashMovement();
            return;
        }

        if (!isDashing)
        {
            Movement();
        }
        LookDir();
    }

    private void GetInputs()
    {
        //Get Input for Movement Direction
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        // Nomalize Diagonal Movement to Prevent Faster Movement
        if (moveDir.magnitude > 1f)
        {
            moveDir.Normalize();
        }
        
        //Gets Mouse Position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //Gets Input and check condition for Dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashAmount > 0 && !isDashing)
        {
            Debug.Log("dash");
            StartDash();
        }

        //Get Input for Shooting
        if (Input.GetMouseButtonDown(0))
        {
            //weapon.Shoot();
        }
    }

    private void Movement()
    {
        rb.linearVelocity = moveDir * speed;
    }

    private void LookDir()
    {
        Vector2 lookDir = mousePos - rb.position;
        rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    private void StartDash()
    {
        isDashing = true;
        dashAmount -= 1;
        dashCDTimer = dashCD;
        dashTimer = dashDur;
        dashDir = moveDir.normalized;
    }

    private void DashMovement()
    {
        dashTimer -= Time.fixedDeltaTime;

        if (dashTimer <= 0)
        {
            isDashing = false;
            return;
        }

        float dashSpeed = dashDis / dashDur;
        rb.linearVelocity = dashDir * dashSpeed;
    }

    private void DashCD()
    {
        if (dashAmount < maxDashAmount)
        {
            dashCDTimer -= Time.fixedDeltaTime;
            if (dashCDTimer <= 0)
            {
                dashAmount = maxDashAmount;
            }
        }
    }

    public void DamagePlayer(int damage)
    {
        HP -= damage;
        HP = Mathf.Clamp(HP, 0, baseHP);

        if (HP <= 0)
        {
            //playerDie();
        }
    }
}
