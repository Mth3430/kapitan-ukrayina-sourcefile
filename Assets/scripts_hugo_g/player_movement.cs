using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public string[] playerInput = new string[3] { "z", "q", "d" };
    public float speed = 1f;
    public float jump = 1f;
    public float atk_range = 1f;
    public float atk_damage = 1f;
    public float dist_to_ground = 1f;
    public bool is_shoot = false;
    public LayerMask ground;
    public LayerMask ennemy;
    public KeyCode attack_key = KeyCode.E;
    public GameObject shield_prefab;
    private short dir = 1;

    public void set_shoot(bool shoot) {
        is_shoot = shoot;
    }

    bool is_grounded() {
        return Physics2D.Raycast(transform.position, Vector3.down, dist_to_ground, ground).collider != null;
    }

    void attack() {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector3.right * dir, atk_range, ennemy);
        if (hits.Length > 0) {
            foreach (RaycastHit2D hit in hits) {
                if (hit.collider.GetComponent<ennemy_scripts>()) {
                    hit.collider.GetComponent<ennemy_scripts>().take_damages(atk_damage);
                }
            }
        }
    }

    void shield_atk() {
        Debug.Log("shield");
        GameObject obj = Instantiate(shield_prefab, transform.position, Quaternion.identity);
        obj.GetComponent<bouclier>().set_dir(dir);
        obj.GetComponent<bouclier>().set_parent(gameObject);
        is_shoot = true;
    }

    void FixedUpdate()
    {
        if (is_shoot) {
            return;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(playerInput[0]))
        {
            if (is_grounded())
            {
                transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jump);
            }
        }
    }

    void LateUpdate()
    {
        if (is_shoot) {
            return;
        }
        if (Input.GetKey(playerInput[1]))
        {
            if (dir != -1)
            {
                dir = -1;
                transform.localScale *= -1;
            }
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(playerInput[2]))
        {
            if (dir != 1)
            {
                dir = 1;
                transform.localScale *= -1;
            }
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
        if (Input.GetKeyDown(attack_key))
        {
            shield_atk();
        }
    }
}
