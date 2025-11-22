using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded = false; 
    private PlayerStats playerStats;

    [SerializeField] private float jumpForce = 10f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        playerStats = GetComponent<PlayerStats>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * playerStats.Speed, rb.linearVelocity.y);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (transform.position.y > collision.transform.position.y + 0.5f)
            {
                EnemyUnityWrapper enemy = collision.gameObject.GetComponent<EnemyUnityWrapper>();

                if (enemy != null)
                {
                    enemy.ReceiveDamage(100);

                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 0.5f);
                }
            }
            else
            {
                PlayerStats stats = GetComponent<PlayerStats>();
                if (stats != null)
                {
                    stats.TakeDamage(10);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}