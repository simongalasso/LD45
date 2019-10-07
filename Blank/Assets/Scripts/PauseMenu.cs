using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject crosshair;
    public bool gamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(/*KeyCode.Escape*/KeyCode.Q))
        {
            if (!gamePaused)
                Pause();
            else
                Resume();
        }
    }

    private void Pause()
    {
        gamePaused = true;
        transform.GetChild(0).gameObject.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Victory()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Resume()
    {
        gamePaused = false;
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
