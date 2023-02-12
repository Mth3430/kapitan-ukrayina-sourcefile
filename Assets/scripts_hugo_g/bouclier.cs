using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouclier : MonoBehaviour
{
    public Vector3 Pos_init;
    public GameObject parent;
    public float speed = 1f;
    public float dist = 5f;
    public short dir = 1;
    public short dir_init = 1;
    public float damage = 1f;

    public void set_parent(GameObject parent) {
        this.parent = parent;
    }

    public void set_dir(short dir)
    {
        this.dir = dir;
        this.dir_init = dir;
    }

    void Start()
    {
        Pos_init = transform.position;
        Debug.Log("bouclier");
    }

    private void OnDestroy() {
        parent.GetComponent<player_movement>().set_shoot(false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        print("collision");
        if (other.gameObject.GetComponent<ennemy_scripts>()) {
            other.gameObject.GetComponent<ennemy_scripts>().take_damages(damage);
        }
        if (other.gameObject.tag != "Player") {
            dir *= -1;
        }
    }

    void Update()
    {
        if (((transform.position.x > Pos_init.x + dist && dir_init == 1) || (transform.position.x < Pos_init.x - dist && dir_init == -1)) && (dir == dir_init))
        {
            dir *= -1;
        }
        if (dir != dir_init && ((transform.position.x <= Pos_init.x && dir_init == 1) || (transform.position.x >= Pos_init.x && dir_init == -1)))
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * dir);
    }
}
