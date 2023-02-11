using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chauve_souris : MonoBehaviour
{
    public int dir = 1;
    public float speed = 1f;
    public int up = 1;
    public Animator animator;

    private void Start() {
        animator.SetBool("fly", true);
    }

    public void set_pos(Vector3 pos)
    {
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "ground") {
            up = -up;
        }
        if (other.gameObject.tag == "wall") {
            dir = -dir;
        }
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<player_movement>().take_damage(1);
            Destroy(gameObject);
        }
    }

    public void move() {
        transform.Translate(new Vector3(dir, up, 0) * speed * Time.deltaTime);
    }

    void Update()
    {
        move();
    }
}
