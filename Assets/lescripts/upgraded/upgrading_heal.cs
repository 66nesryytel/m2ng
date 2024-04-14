using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrading : MonoBehaviour
{

   
    private playerstats playerReference;
    private GameObject gameManagerObject;

    audio audioManager;


    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("Gamemanager");
        playerReference = gameManagerObject.GetComponent<playerstats>();
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
            playerReference.HealCharacter(10f);
            
            for (int i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }
    }
}
