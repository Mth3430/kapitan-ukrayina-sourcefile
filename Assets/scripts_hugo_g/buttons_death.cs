using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons_death : MonoBehaviour
{
    public bool is_die_button = false;
    public all_var_script all_var;

    public void click_on_button()
    {
        if (is_die_button) {
            Application.Quit();
        } else {
            if (!all_var) {
                all_var = GameObject.Find("all_var").GetComponent<all_var_script>();
                all_var.nbr_kill = 0;
                all_var.nbr_win = 0;
            }
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
