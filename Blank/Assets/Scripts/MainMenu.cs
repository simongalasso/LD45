using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadLevel(int TargetScene)
    {
    	SceneManager.LoadScene(TargetScene);
    }

    public void Quit()
    {
    	Debug.Log("QUIT!");
        Application.Quit();
    }
}
