using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{


    public void StartGame()
    {

        StartCoroutine(start());
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Lahkun...");
        Application.Quit();
    }

    public void GoToLore()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
