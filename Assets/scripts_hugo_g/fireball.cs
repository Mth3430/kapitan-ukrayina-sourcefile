using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float dmg = 1f;
    public float dir = 1f;
    public float speed = 1f;

    public void set_pos(Vector3 pos) {
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<player_movement>().take_damage(dmg);
        }
        Destroy(gameObject);
    }

    public void set_dir(float dir) {
        this.dir = dir;
    }

    private void Update() {
        transform.Translate(Vector3.right * dir * Time.deltaTime * speed);
    }
}
