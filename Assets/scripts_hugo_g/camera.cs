using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Menu.activeSelf) {
                Menu.SetActive(false);
            } else {
                Menu.SetActive(true);
            }
        }
    }
}
