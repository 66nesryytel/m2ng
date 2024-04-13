using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYMOVEMENT : MonoBehaviour
{

    public float speed = 0.5f;
    public Transform target;


    private void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       
    }

 
}
