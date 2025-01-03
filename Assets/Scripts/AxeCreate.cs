using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCreate : MonoBehaviour
{
    public GameObject prefab; // ���� ������
    public float throwForce = 10f; // ���� ������ ��
    public float throwCooldown = 7f; // ���� ������ ��Ÿ��
    private float lastThrowTime = 0f; // ������ ���� ���� �ð�
    public int numberOfAxes = 1; // ���� ������ ����
    public float delayBetweenThrows = 0.2f; // ������ ���� ����

    public float lifetime = 10f;

    private void Update()
    {
        // ������ ������ ���� Ű �Է� (��: 2�� Ű)
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
            // ���� ����
            GameObject axe = Instantiate(prefab, transform.position, Quaternion.identity);

            // ������ ���� ����
            float randomDirection = Random.Range(-1f, 1f);
            Vector2 throwDirection = new Vector2(randomDirection, 3).normalized;

            // ������ �������� �������� ȸ��
            float angle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg;
            axe.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // ���� ������ ���� ����
            axe.GetComponent<Rigidbody2D>().velocity = throwDirection * throwForce;
           
            Destroy(axe, lifetime);

            // ������ ���� �� ��� ��ٸ��� (������ �α� ����)
            yield return new WaitForSeconds(delayBetweenThrows);
        }
    }
    public void AddCountAxe()
    {
        numberOfAxes++;
    }
}