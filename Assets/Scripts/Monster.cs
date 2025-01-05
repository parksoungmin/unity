using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float stopDistance = 3f;
    public float pushForce = 2f;  // 플레이어가 밀었을 때 밀리는 정도 (조정 가능)
    public int hp = 100;
    private int damage = 20;

    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            Player player2 = collision.gameObject.GetComponent<Player>();
            if (player2 != null)
            {
                player2.TakeDamage(damage);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        Destroy(gameObject);
    }
}