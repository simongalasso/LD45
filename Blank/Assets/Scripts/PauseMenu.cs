using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject crosshair;

    private bool gamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(/*KeyCode.Escape*/KeyCode.Q))
        {
            if (!gamePaused)
                Pause();
            else
                Resume();
            gamePaused = !gamePaused;
        }
    }

    private void Pause()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Resume()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
