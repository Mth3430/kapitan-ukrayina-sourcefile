using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public string[] playerInput = new string[3] { "z", "q", "d" };
    public float speed = 1f;
    public float jump = 1f;
    public float life = 3f;
    public float atk_range = 1f;
    public float atk_damage = 1f;
    public float dist_to_ground = 1f;
    public bool is_dead = false;
    public bool is_shoot = false;
    public LayerMask ground;
    public LayerMask ennemy;
    public LayerMask ennemy2;
    public KeyCode attack_key = KeyCode.E;
    public GameObject shield_prefab;
    public GameObject shield_pos;
    public GameObject death_pannel;
    public GameObject opt;
    public GameObject pause;
    public GameObject cine;
    public GameObject groundSample;
    public GameObject SpawnPoint;
    public Animator animator;
    private short dir = 1;
    private bool is_jumping = false;
    public AudioSource audio;
    public AudioClip attackcac;
    public AudioClip attackdist;
    public AudioClip death;
    public AudioClip hurt;
    public AudioClip hurt2;
    public AudioClip hurt3;
    public AudioClip jumped;
    public AudioClip cnon;
    int randhurt;

    public void take_damage(float damage) {
        life -= damage;
        if (life <= 0) {
            death_pannel.SetActive(true);
            Time.timeScale = 0f;
            is_dead = true;
            audio.PlayOneShot(death);
            print("dead");
        }
        randhurt = UnityEngine.Random.Range(1,30);
        if (randhurt < 10)
            audio.PlayOneShot(hurt);
        if (randhurt > 10 && randhurt < 20)
            audio.PlayOneShot(hurt2);
        if (randhurt > 20)
            audio.PlayOneShot(hurt3);
    }

    public void set_shoot(bool shoot) {
        is_shoot = shoot;
    }

    bool is_grounded() {
        return Physics2D.Raycast(transform.position, Vector3.down, dist_to_ground, ground).collider != null;
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("attack1", false);
    }

    void attack() {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y / 2), Vector3.right * dir, atk_range, ennemy);
        RaycastHit2D[] hits1 = Physics2D.RaycastAll(transform.position + Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y), Vector3.right * dir, atk_range, ennemy);
        RaycastHit2D[] hits2 = Physics2D.RaycastAll(transform.position, Vector3.right * dir, atk_range, ennemy);
        RaycastHit2D[] hitsr = Physics2D.RaycastAll(transform.position + Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y / 2), Vector3.right * dir, atk_range, ennemy2);
        RaycastHit2D[] hits1r = Physics2D.RaycastAll(transform.position + Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y), Vector3.right * dir, atk_range, ennemy2);
        RaycastHit2D[] hits2r = Physics2D.RaycastAll(transform.position, Vector3.right * dir, atk_range, ennemy2);
        animator.SetBool("attack1", true);
        if (hits.Length > 0) {
            foreach (RaycastHit2D hit in hits) {
                if (hit.collider.GetComponent<ennemy_scripts>()) {
                    print("hit ennemy");
                    hit.collider.GetComponent<ennemy_scripts>().take_damages(atk_damage);
                }
            }
        }
        if (hits1.Length > 0) {
            foreach (RaycastHit2D hit in hits1) {
                if (hit.collider.GetComponent<ennemy_scripts>()) {
                    print("hit ennemy");
                    hit.collider.GetComponent<ennemy_scripts>().take_damages(atk_damage);
                }
            }
        }
        if (hits2.Length > 0) {
            foreach (RaycastHit2D hit in hits2) {
                if (hit.collider.GetComponent<ennemy_scripts>()) {
                    print("hit ennemy");
                    hit.collider.GetComponent<ennemy_scripts>().take_damages(atk_damage);
                }
            }
        }
        if (hitsr.Length > 0) {
            foreach (RaycastHit2D hit in hitsr) {
                if (hit.collider.GetComponent<ennemy_scripts_Russkof>()) {
                    print("hit ennemy");
                    hit.collider.GetComponent<ennemy_scripts_Russkof>().take_damages(atk_damage);
                }
            }
        }
        if (hits1r.Length > 0) {
            foreach (RaycastHit2D hit in hits1r) {
                if (hit.collider.GetComponent<ennemy_scripts_Russkof>()) {
                    print("hit ennemy");
                    hit.collider.GetComponent<ennemy_scripts_Russkof>().take_damages(atk_damage);
                }
            }
        }
        if (hits2r.Length > 0) {
            foreach (RaycastHit2D hit in hits2r) {
                if (hit.collider.GetComponent<ennemy_scripts_Russkof>()) {
                    print("hit ennemy");
                    hit.collider.GetComponent<ennemy_scripts_Russkof>().take_damages(atk_damage);
                }
            }
        }
        audio.PlayOneShot(attackcac);
        StartCoroutine(wait());
    }

    void shield_atk() {
        animator.SetBool("throw_shield", true);
        GameObject obj = Instantiate(shield_prefab, shield_pos.transform.position, Quaternion.identity);
        obj.GetComponent<bouclier>().set_dir(dir);
        obj.GetComponent<bouclier>().set_parent(gameObject);
        is_shoot = true;
        audio.PlayOneShot(attackdist);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "limits") {
            print("c'est non");
            audio.PlayOneShot(cnon);
        }
    }

    void FixedUpdate()
    {
        if (is_shoot || is_dead) {
            return;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(playerInput[0]))
        {
            if (is_grounded())
            {
                transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jump);
                is_jumping = true;
                animator.SetBool("jump", true);
                audio.PlayOneShot(jumped);
            }
        }
    }

    void LateUpdate()
    {
        if (pause.activeInHierarchy || opt.activeInHierarchy || cine.activeInHierarchy) {
            return;
        }
        bool walk = false;
        if (is_shoot || is_dead) {
            return;
        }
        if (transform.position.y < groundSample.transform.position.y) {
            transform.position = new Vector3(transform.position.x, SpawnPoint.transform.position.y, transform.position.z);
        }
        if (animator.GetBool("wait")) {
            animator.SetBool("wait", false);
        }
        if (is_jumping && is_grounded()) {
            is_jumping = false;
            animator.SetBool("jump", false);
        }
        if (Input.GetKey(playerInput[1]))
        {
            if (dir != -1)
            {
                dir = -1;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            walk = true;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(playerInput[2]))
        {
            if (dir != 1)
            {
                dir = 1;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            walk = true;
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
        animator.SetBool("walk", walk);
    }
}
