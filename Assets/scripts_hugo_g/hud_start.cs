using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud_start : MonoBehaviour
{
    public GameObject hud;
    public GameObject cine;
    public GameObject pause;
    public GameObject opt;

    void Update()
    {
        if (hud.activeInHierarchy  == false && cine.activeInHierarchy  == false) {
            hud.SetActive(true);
        }
        if (!cine.activeInHierarchy ) {
            hud.SetActive(!pause.activeInHierarchy && !opt.activeInHierarchy);
        }
    }
}
