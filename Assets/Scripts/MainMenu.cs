using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public all_var_script all_var;

    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }

    public void return_menu()
    {
        if (!all_var) {
            all_var = GameObject.Find("all_var").GetComponent<all_var_script>();
        }
        all_var.Reset();
        SceneManager.LoadScene(0);
    }
}
