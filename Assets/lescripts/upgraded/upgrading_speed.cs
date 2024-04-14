using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrading_speed : MonoBehaviour
{


    private playermovement playerReference;
    audio audioManager;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        playerReference = playerObject.GetComponent<playermovement>();
      
    }

    private void Awake()
    {
        audioManager = GameObject.Find("helivanem").GetComponent<audio>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Transform parent = transform.parent;
        if (collision.name == "Player")
        {
            audioManager.PlaySFX(audioManager.sfx2);
            playerReference.AddSpeed(0.3f);
            for (int i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }
    }
}
