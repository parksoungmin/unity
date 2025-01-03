using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ ������Ʈ
    public int numberOfObjects = 10; // ������ ������Ʈ ��
    public float spawnDistanceMin = 10f; // �ּ� ���� �Ÿ�
    public float spawnDistanceMax = 15f; // �ִ� ���� �Ÿ�
    public float spawnDirectionRange = 360f; // ���� ���� ���� (0~360)

    void Start()
    {
        SpawnObjectsOutsideCamera();
    }

    void SpawnObjectsOutsideCamera()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ī�޶��� ����Ʈ ��ǥ�� �����ɴϴ�.
            Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f); // ȭ���� �߾�
            Vector3 viewportPosition = Camera.main.ViewportToWorldPoint(screenCenter);

            // ī�޶� ������ ������ �������� ������Ʈ�� ������ ��ġ ����
            float spawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax); // ���� �Ÿ�
            float randomAngle = Random.Range(0f, spawnDirectionRange); // ���� ���� (0~360��)

            // ������ �̿��� x, y ��ǥ�� ��� (2D ��鿡�� ���� ���)
            Vector3 spawnDirection = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad), 0);
            Vector3 spawnPosition = viewportPosition + spawnDirection * spawnDistance;

            // ������Ʈ�� �����մϴ�.
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
