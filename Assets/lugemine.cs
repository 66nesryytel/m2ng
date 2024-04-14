using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lugemine : MonoBehaviour
{

    public Text text;
    private EnemyWaveManager waveReference;

    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<Text>();

        GameObject gameManagerObject = GameObject.Find("Gamemanager");
        waveReference = gameManagerObject.GetComponent<EnemyWaveManager>();
    }


    void Update()
    {
        text.text = "Wave: " + waveReference.currentWave;

    }
}
