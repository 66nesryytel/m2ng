using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mypos = transform.position;
            Vector2 direction = (mousePos - mypos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<testprojectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }

    public void AddDamage(float a)
    {
        minDamage += a;
        maxDamage += a;
    }
}
