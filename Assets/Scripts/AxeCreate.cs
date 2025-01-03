using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCreate : MonoBehaviour
{
    public GameObject prefab; // 도끼 프리팹
    public float throwForce = 10f; // 도끼 던지는 힘
    public float throwCooldown = 7f; // 도끼 던지기 쿨타임
    private float lastThrowTime = 0f; // 마지막 도끼 던진 시간
    public int numberOfAxes = 1; // 던질 도끼의 개수
    public float delayBetweenThrows = 0.2f; // 도끼를 던질 간격

    public float lifetime = 10f;

    private void Update()
    {
        // 도끼를 던지기 위한 키 입력 (예: 2번 키)
        if (Time.time - lastThrowTime >= throwCooldown)
        {
            lastThrowTime = Time.time;
            StartCoroutine(ThrowMultipleAxes());
        }
    }

    IEnumerator ThrowMultipleAxes()
    {
        for (int i = 0; i < numberOfAxes; i++)
        {
            // 도끼 생성
            GameObject axe = Instantiate(prefab, transform.position, Quaternion.identity);

            // 랜덤한 방향 설정
            float randomDirection = Random.Range(-1f, 1f);
            Vector2 throwDirection = new Vector2(randomDirection, 3).normalized;

            // 도끼가 던져지는 방향으로 회전
            float angle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg;
            axe.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // 도끼 던지는 힘을 적용
            axe.GetComponent<Rigidbody2D>().velocity = throwDirection * throwForce;
           
            Destroy(axe, lifetime);

            // 도끼를 던진 후 잠시 기다리기 (간격을 두기 위함)
            yield return new WaitForSeconds(delayBetweenThrows);
        }
    }
    public void AddCountAxe()
    {
        numberOfAxes++;
    }
}