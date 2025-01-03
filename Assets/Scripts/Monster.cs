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

    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트를 가져옵니다.
    }

    private void FixedUpdate()
    {
        // 몬스터와 플레이어 간의 거리가 stopDistance보다 크면 플레이어를 추적
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            // 플레이어를 향해 이동 (Rigidbody2D의 velocity를 사용하여 추적)
            Vector2 direction = (player.position - transform.position).normalized; // 플레이어 방향 벡터 계산
            rb.velocity = direction * speed; // velocity를 설정하여 이동
        }
        else
        {
            // stopDistance 이내에 들어오면 멈춤
            rb.velocity = Vector2.zero;
        }
    }

    // 플레이어가 밀었을 때 적용되는 힘
    private void OnCollisionStay2D(Collision2D collision)
    {
        // 플레이어와의 충돌이 있을 때
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어가 밀 때, 밀린 방향으로 힘을 조금 추가
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // 밀리는 방향 계산
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // 밀리는 힘을 추가
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