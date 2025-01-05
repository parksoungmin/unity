using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;

    public Slider HpbarSlider;

    public Player player;

    private void Start()
    {
        if (player != null)
        currentHp = player.currentHp;
    }
    void Update()
    {
        if (player != null && HpbarSlider != null)
        {
            currentHp = player.currentHp;
            HpbarSlider.value = (float)currentHp / (float)maxHp;
        }
    }
}
