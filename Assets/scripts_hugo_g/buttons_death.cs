using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons_death : MonoBehaviour
{
    public bool is_die_button = false;

    public void click_on_button()
    {
        if (is_die_button) {
            Application.Quit();
        } else {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
