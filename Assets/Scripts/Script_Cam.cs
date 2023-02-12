using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Cam : MonoBehaviour
{
    public float smoothing = 0.5f;
    public float smoothingbase = 0.5f;
    public GameObject[] Spawn_Points;
    public GameObject player;
    player_movement player_script;

    private void Start() {
        foreach (var spawnp in Spawn_Points)
        {
            spawnp.GetComponent<spawn>().set_active(true);
        }
        player_script = player.GetComponent<player_movement>();
        smoothingbase = smoothing;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            smoothing = 2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            smoothing = smoothingbase;
        }
    }

    private void Update() {
        if (Input.GetKey(player_script.playerInput[1]))
        {
            transform.Translate(Vector3.left * Time.deltaTime * player_script.speed * smoothing);
        }
        if (Input.GetKey(player_script.playerInput[2]))
        {
            transform.Translate(Vector3.right * Time.deltaTime * player_script.speed * smoothing);
        }
    }
}
