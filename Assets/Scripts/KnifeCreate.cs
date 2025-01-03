using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCreate: MonoBehaviour
{
    public GameObject knifePrefab; // 칼 프리팹
    public float throwForce = 10f; // 칼 던지는 힘
    public float throwCooldown = 3f; // 칼 던지기 쿨타임
    private float lastThrowTime = 0f; // 마지막 칼 던진 시간
    public float pulseAngle = -30;
    public int numberOfKnifes = 1; // 던질 칼의 개수
    public float delayBetweenThrows = 0.2f; // 칼을 던질 간격

    public float lifeTime = 10f;

    Monster[] monsters;

    public int damage = 30;

    private void Update()
    {
        // 칼을 던지기 위한 키 입력 (예: 스페이스바)
        if (Time.time - lastThrowTime >= throwCooldown)
        {
            lastThrowTime = Time.time;
            StartCoroutine(ThrowKnife());
        }
    }

    IEnumerator ThrowKnife()
    {
        // 모든 몬스터를 찾아서 가장 가까운 몬스터 찾기
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

        // 가장 가까운 몬스터가 있으면 칼을 던진다
        if (nearestMonster != null)
        {
            for (int i = 0; i < numberOfKnifes; i++)
            {
                // 칼을 생성하고 던진다
                GameObject knife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
                Vector2 direction = (nearestMonster.transform.position - transform.position).normalized;

                // 칼이 던져지는 방향으로 회전시킴
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                knife.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + pulseAngle));

                // 칼 던지는 힘을 적용
                knife.GetComponent<Rigidbody2D>().velocity = direction * throwForce;

                Destroy(knife, lifeTime);
                // 칼을 던진 후 잠시 기다린다 (간격을 두기 위함)
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