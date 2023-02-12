using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausemenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused= false;
    }

    void pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale= 0f;
        GameIsPaused= true;
    }
}
