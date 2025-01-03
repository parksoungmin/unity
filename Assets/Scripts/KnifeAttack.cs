using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    private int damage = 20;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Monster"))
        {
            Monster monster = collider.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
