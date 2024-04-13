using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstats : MonoBehaviour
{
    public static playerstats playerStats;
    
    public GameObject player;
    
    public float health;
    public float maxhealth;

    private void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
       // DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxhealth;
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    private void CheckOverheal()
    {
        if (health> maxhealth)
        {
            health = maxhealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(player);
        }
    }
}
