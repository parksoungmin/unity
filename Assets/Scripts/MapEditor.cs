using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform planeTr;
    public GameObject tilePrefab;
    public Sprite[] map;

    private int posX = 50, posY = 50;

    private void Awake()
    {
        if (planeTr.childCount > 0) return;

        for (int x = -posX; x < posY; x++)
        {
            for (int y = -posY; y < posY; y++)
            {
                GameObject tile = Instantiate(tilePrefab);
                tile.transform.localPosition = new Vector3(x, y, 0f);
                tile.transform.SetParent(planeTr);

                int rand = Random.Range(0, 10);
                if (rand < 1 )
                {
                    tile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = map[Random.Range(0, map.Length)];
                }
            }
        }
    }

}
