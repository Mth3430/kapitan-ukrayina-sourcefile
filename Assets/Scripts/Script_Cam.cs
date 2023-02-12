using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Cam : MonoBehaviour
{
    public float smoothing = 0.5f;
    public float smoothingbase = 0.5f;
    public float dir = 1f;
    public bool follow_car = false;
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
            smoothing = 3f;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            smoothing = smoothingbase;
        }
    }

    private void Update() {
        if (follow_car) {
            return;
        }
        if (player.transform.position.x + 1f > transform.position.x && player.transform.position.x - 1f < transform.position.x) {
            return;
        }
        if (player.transform.position.x > transform.position.x) {
            dir = 1f;
        } else {
            dir = -1f;
        }
        transform.Translate(Vector3.right * dir * (player.GetComponent<player_movement>().speed + 2f) * Time.deltaTime * smoothing);
    }
}
