using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Pause()
    {
        Time.timeScale = 0;
    }
    private void UnPause()
    {
        Time.timeScale = 1;
    }
    public void Resume()
    {
        UnPause();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale == 1)
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Resume();
            }
        }
    }
}
