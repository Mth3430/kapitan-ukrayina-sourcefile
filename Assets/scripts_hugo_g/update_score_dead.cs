using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class update_score_dead : MonoBehaviour
{
    public TextMeshProUGUI score;
    public all_var_script all_var;

    private void Start() {
        if (!all_var) {
            all_var = GameObject.Find("all_var").GetComponent<all_var_script>();
        }
        score.text = "Final score: " + all_var.nbr_kill;
    }
}
