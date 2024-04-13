using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class jälitamängijat : MonoBehaviour
{
    public Transform target;
    public float speed; //peab olema sama mis mängijal
    public Vector3 offset = new Vector3(1,1,0);
    private Vector2 targetPosition;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (target != null)
        {
            targetPosition = target.position + offset;
            transform.position = Vector2.Lerp(transform.position, targetPosition , speed * Time.deltaTime);
        }
        
    }
}
