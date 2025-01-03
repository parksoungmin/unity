using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject objectToSpawn; // 생성할 오브젝트
    public int numberOfObjects = 10; // 생성할 오브젝트 수
    public float spawnDistanceMin = 10f; // 최소 생성 거리
    public float spawnDistanceMax = 15f; // 최대 생성 거리
    public float spawnDirectionRange = 360f; // 랜덤 방향 범위 (0~360)

    void Start()
    {
        SpawnObjectsOutsideCamera();
    }

    void SpawnObjectsOutsideCamera()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // 카메라의 뷰포트 좌표를 가져옵니다.
            Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f); // 화면의 중앙
            Vector3 viewportPosition = Camera.main.ViewportToWorldPoint(screenCenter);

            // 카메라 밖으로 랜덤한 방향으로 오브젝트를 생성할 위치 설정
            float spawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax); // 랜덤 거리
            float randomAngle = Random.Range(0f, spawnDirectionRange); // 랜덤 각도 (0~360도)

            // 각도를 이용해 x, y 좌표를 계산 (2D 평면에서 방향 계산)
            Vector3 spawnDirection = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad), 0);
            Vector3 spawnPosition = viewportPosition + spawnDirection * spawnDistance;

            // 오브젝트를 생성합니다.
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
