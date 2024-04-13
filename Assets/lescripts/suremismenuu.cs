using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class suremismenuu : MonoBehaviour
{

    public GameObject deathMenu;
    public static bool isPaused;
    private playerstats playerReference;

    // Start is called before the first frame update
    void Start()
    {
        deathMenu.SetActive(false);
    }

    private void Update()
    {
        playerReference = GetComponent<playerstats>();
        float mängijaelud = playerReference.health;
        
        if (mängijaelud <= 0) 
        {
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        
        
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
