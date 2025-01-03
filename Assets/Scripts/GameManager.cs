using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Masage time;
    public GameObject addAxeButton;  // ���� ���� ���� ��ư
    public GameObject addKnifeButton;  // Į ���� ���� ��ư

    public int puseTime = 5;

    private void Awake()
    {
        time = GetComponent<Masage>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if ((int)(Time.time+1) % puseTime == 0)
        {
            addAxeButton.SetActive(true);
            addKnifeButton.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OnButtonClick()
    {
        Time.timeScale = 1;
        addAxeButton.SetActive(false);
        addKnifeButton.SetActive(false);
    }
}
