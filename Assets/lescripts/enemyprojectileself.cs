using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectileself : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerstats.playerStats.TakeDamage(damage);
        }
    }
}
