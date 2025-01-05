using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public int currentHp = 100;
    private float hitTime = 1;
    private float currentHitTime = 0;
    private bool gameOver = false;

    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!gameOver)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
            currentHitTime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damage)
    {
        if (hitTime <= currentHitTime)
        {
            currentHitTime = 0;
            currentHp -= damage;
            if (currentHp <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        if (gameManager != null)
        {
            gameOver = true;
            gameManager.OnPlayerDie();
        }
    }

}