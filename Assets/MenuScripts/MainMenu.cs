using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Gamescene");
    }

    public void WinToMenu()
    {
        SceneManager.LoadScene("MenuScenes");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
        //SceneManager.LoadScene("Quit");
    }
}
