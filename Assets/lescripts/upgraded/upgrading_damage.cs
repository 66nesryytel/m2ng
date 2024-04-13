using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrading_damage : MonoBehaviour
{


    private spell playerReference;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        playerReference = playerObject.GetComponent<spell>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Transform parent = transform.parent;
        if (collision.name == "Player")
        {
            playerReference.AddDamage(10);
            for (int i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }
    }
}
