using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class all_var_script : MonoBehaviour
{
    public int nbr_win = 0;
    public int nbr_win_to_win = 3;
    public int nbr_kill = 0;

    public void add_nbr_kill(int nbr_kill) {
        this.nbr_kill += nbr_kill;
    }

    public void add_nbr_win(int nbr_win) {
        this.nbr_win += nbr_win;
    }

    public int get_nbr_win() {
        return nbr_win;
    }

    public void Reset() {
        nbr_win = 0;
        nbr_kill = 0;
    }

    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("GameController");
        if (obj.Length > 1)
            Destroy(gameObject);
        nbr_kill = 0;
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate() {
        if (nbr_win >= nbr_win_to_win) {
            nbr_win = 0;
            SceneManager.LoadScene("Finish");
        }
    }
}
