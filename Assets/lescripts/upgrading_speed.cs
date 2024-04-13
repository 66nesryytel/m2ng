using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrading_speed : MonoBehaviour
{


    private playermovement playerReference;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        playerReference = playerObject.GetComponent<playermovement>();
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerReference.AddSpeed(2);
            Destroy(transform.parent.gameObject);
        }
    }
}
