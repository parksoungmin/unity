using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Masage time;
    public GameObject gameOverText;
    public SpawnMonster spawnMonster;
    public GameObject addAxeButton;  // 도끼 개수 증가 버튼
    public GameObject addKnifeButton;  // 칼 개수 증가 버튼

    private bool gameOver = false;
    public float currentTime = 0f;
    public float UpgradeTime = 20f;


    private void Awake()
    {
        time = GetComponent<Masage>();
        spawnMonster = FindObjectOfType<SpawnMonster>();
    }
    void Start()
    {

    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= UpgradeTime)
        {
            spawnMonster.SpawnObjectsOutsideCamera();
            currentTime = 0f;
            addAxeButton.SetActive(true);
            addKnifeButton.SetActive(true);
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }
    public void OnButtonClick()
    {
        Time.timeScale = 1;
        addAxeButton.SetActive(false);
        addKnifeButton.SetActive(false);
    }
    public void OnPlayerDie()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
}
