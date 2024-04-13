using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testprojectile : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if(collision.GetComponent<enemydamage>() != null)
            {
                collision.GetComponent<enemydamage>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
