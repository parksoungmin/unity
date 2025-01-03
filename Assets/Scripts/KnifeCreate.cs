using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCreate: MonoBehaviour
{
    public GameObject knifePrefab; // Į ������
    public float throwForce = 10f; // Į ������ ��
    public float throwCooldown = 3f; // Į ������ ��Ÿ��
    private float lastThrowTime = 0f; // ������ Į ���� �ð�
    public float pulseAngle = -30;
    public int numberOfKnifes = 1; // ���� Į�� ����
    public float delayBetweenThrows = 0.2f; // Į�� ���� ����

    public float lifeTime = 10f;

    Monster[] monsters;

    public int damage = 30;

    private void Update()
    {
        // Į�� ������ ���� Ű �Է� (��: �����̽���)
        if (Time.time - lastThrowTime >= throwCooldown)
        {
            lastThrowTime = Time.time;
            StartCoroutine(ThrowKnife());
        }
    }

    IEnumerator ThrowKnife()
    {
        // ��� ���͸� ã�Ƽ� ���� ����� ���� ã��
        Monster[] monsters = FindObjectsOfType<Monster>();
        Monster nearestMonster = null;
        float minDistance = Mathf.Infinity;

        foreach (Monster monster in monsters)
        {
            float distance = Vector2.Distance(transform.position, monster.transform.position);
            if (distance < minDistance)
            {
                nearestMonster = monster;
                minDistance = distance;
            }
        }

        // ���� ����� ���Ͱ� ������ Į�� ������
        if (nearestMonster != null)
        {
            for (int i = 0; i < numberOfKnifes; i++)
            {
                // Į�� �����ϰ� ������
                GameObject knife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
                Vector2 direction = (nearestMonster.transform.position - transform.position).normalized;

                // Į�� �������� �������� ȸ����Ŵ
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                knife.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + pulseAngle));

                // Į ������ ���� ����
                knife.GetComponent<Rigidbody2D>().velocity = direction * throwForce;

                Destroy(knife, lifeTime);
                // Į�� ���� �� ��� ��ٸ��� (������ �α� ����)
                yield return new WaitForSeconds(delayBetweenThrows);
            }
        }
    }
    public void AddCountNife()
    {
        numberOfKnifes++;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision Detected with: " + collider.gameObject.name);
        if (collider.CompareTag("Monster"))
        {
            Monster monster = collider.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}