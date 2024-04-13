using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrading_damage : MonoBehaviour
{


    private spell playerReference;
    private spell playerReference2;
    private spell playerReference3;
    private spell playerReference4;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("Companion");
        GameObject playerObject2 = GameObject.Find("Companion2");
        GameObject playerObject3 = GameObject.Find("Companion3");
        GameObject playerObject4 = GameObject.Find("Companion4");
        playerReference = playerObject.GetComponent<spell>();
        playerReference2 = playerObject2.GetComponent<spell>();
        playerReference3 = playerObject3.GetComponent<spell>();
        playerReference4 = playerObject4.GetComponent<spell>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Transform parent = transform.parent;
        if (collision.name == "Player")
        {
            playerReference.AddDamage(2);
            playerReference2.AddDamage(2);
            playerReference3.AddDamage(2);
            playerReference4.AddDamage(2);


            for (int i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }
    }
}
