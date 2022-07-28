using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    bool isPaused = true;
    public bool canPause = true;
    public GameObject pauseMenuCanvas;
    // Update is called once per frame
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                if(canPause)
                Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
