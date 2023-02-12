using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hud_script : MonoBehaviour
{
    public TextMeshProUGUI score;
    public all_var_script all_var;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + all_var.nbr_kill;
    }
}
