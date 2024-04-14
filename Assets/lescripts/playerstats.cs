using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerstats : MonoBehaviour
{
    public static playerstats playerStats;
    
    public GameObject player;
    public Slider healthSlider;
    
    public float health;
    public float maxhealth;

    public SimpleFlash otherScript;

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
        healthSlider.value = CalculateHealthPercentage();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        healthSlider.value = CalculateHealthPercentage();
    }
    
    public void TakeDamage(float damage)
    {
        otherScript = player.GetComponent<SimpleFlash>();
        otherScript.Flash();

        health -= damage;
        CheckDeath();
        healthSlider.value = CalculateHealthPercentage();

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

    float CalculateHealthPercentage()
    {
        return health / maxhealth;
    }
}
