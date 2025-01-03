using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 20;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Monster"))
        {
            Monster monster = collider.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }
        }
    }
}
