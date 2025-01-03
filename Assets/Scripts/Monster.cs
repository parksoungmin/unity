using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float stopDistance = 3f;
    public float pushForce = 2f;  // �÷��̾ �о��� �� �и��� ���� (���� ����)
    public int hp = 100;

    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D ������Ʈ�� �����ɴϴ�.
    }

    private void FixedUpdate()
    {
        // ���Ϳ� �÷��̾� ���� �Ÿ��� stopDistance���� ũ�� �÷��̾ ����
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            // �÷��̾ ���� �̵� (Rigidbody2D�� velocity�� ����Ͽ� ����)
            Vector2 direction = (player.position - transform.position).normalized; // �÷��̾� ���� ���� ���
            rb.velocity = direction * speed; // velocity�� �����Ͽ� �̵�
        }
        else
        {
            // stopDistance �̳��� ������ ����
            rb.velocity = Vector2.zero;
        }
    }

    // �÷��̾ �о��� �� ����Ǵ� ��
    private void OnCollisionStay2D(Collision2D collision)
    {
        // �÷��̾���� �浹�� ���� ��
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾ �� ��, �и� �������� ���� ���� �߰�
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // �и��� ���� ���
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // �и��� ���� �߰�
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