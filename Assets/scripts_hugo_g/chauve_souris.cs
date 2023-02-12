using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chauve_souris : MonoBehaviour
{
    public int dir = 1;
    public int up = 1;
    public float speed = 1f;
    public float deathg_time = 1f;
    public Animator animator;

    IEnumerator wait_death()
    {
        yield return new WaitForSeconds(deathg_time);
        Destroy(gameObject);
    }

    private void Start() {
        animator.SetBool("fly", true);
        StartCoroutine(wait_death());
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
        if (Random.Range(0, 100) <= 15) {
            up = -up;
        }
        if (Random.Range(0, 100) <= 15) {
            dir = -dir;
        }
        transform.Translate(new Vector3(dir, up, 0) * speed * Time.deltaTime);
    }

    void Update()
    {
        move();
    }
}
