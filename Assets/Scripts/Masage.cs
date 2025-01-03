using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Masage : MonoBehaviour
{
    public GameObject gameoverText;
    public TextMeshProUGUI time;
    private float _time = 0;
    void Start()
    {
    }

    private void Update()
    {
        _time += Time.deltaTime;
        time.text = $"Time : {(int)_time}";
    }
    void OnGameOver()
    {
        gameoverText.SetActive(true);
    }
}
