using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class all_var_script : MonoBehaviour
{
    public int nbr_win = 0;
    public int nbr_win_to_win = 3;

    public void add_nbr_win(int nbr_win) {
        this.nbr_win += nbr_win;
    }

    public int get_nbr_win() {
        return nbr_win;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate() {
        if (nbr_win >= nbr_win_to_win) {
            nbr_win = 0;
            SceneManager.LoadScene("Finish");
        }
    }
}
