using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life_bar : MonoBehaviour
{
    public GameObject back;
    public GameObject front;
    public player_movement player;
    public float life_base = 0;

    private void Start() {
        player = GameObject.Find("captain").GetComponent<player_movement>();
        life_base = player.life;
    }

    void Update()
    {
        float life = player.life;
        float ratio = life / life_base;
        front.transform.localScale = new Vector3(ratio, 1, 1);
        if (ratio < 0.3) {
            back.GetComponent<Image>().color = Color.red;
        } else if (ratio < 0.6) {
            back.GetComponent<Image>().color = Color.yellow;
        } else {
            back.GetComponent<Image>().color = Color.green;
        }
    }
}
