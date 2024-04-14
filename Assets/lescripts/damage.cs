using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    public float maxhealth;
    public float currenthealth;

    public Rigidbody2D rb;

    [SerializeField] public SimpleFlash otherScript;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        otherScript = GetComponent<SimpleFlash>();
    }

    

    public void TakeDamage(float damage)
    {
        if (otherScript != null)
        {
            otherScript.Flash();
        }
        currenthealth -= damage;
        CheckDeath();
    }

    private void CheckOverheal()
    {
        if(currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }
    }

    private void CheckDeath()
    {
        if(currenthealth <= 0)
        {
            Destroy(gameObject);

        }
    }
}
