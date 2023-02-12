using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_scripts : MonoBehaviour
{
    public float life = 3;
    public float speed = 1f;
    public float atk_range = 1f;
    public float dist_to_ground = 1f;
    public float elapsed_time = 0f;
    public float time_beetween_balls = 1f;
    public short dir = 1;
    public bool is_figth = false;
    public bool get_hit = false;
    public Animator animator;
    public GameObject proj_pos;
    public GameObject player;
    public GameObject fireball_prefab;
    public GameObject chauve_souris_prefab;
    public LayerMask player_layer;
    public LayerMask ground;

    IEnumerator wait_death()
    {
        animator.SetBool("death", true);
        yield return new WaitForSeconds(0.9f);
        animator.SetBool("death", false);
        Destroy(gameObject);
    }

    IEnumerator wait_hit()
    {
        animator.SetBool("hit", true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("hit", false);
        get_hit = false;
    }

    IEnumerator wait_atk()
    {
        animator.SetBool("atk", true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("atk", false);
        atk();
        animator.SetBool("atk2", true);
        yield return new WaitForSeconds(0.15f);
        animator.SetBool("atk2", false);
    }

    public void take_damages(float damage)
    {
        if (get_hit || life <= 0) {
            return;
        }
        print("-1");
        life -= damage;
        get_hit = true;
        locate_player();
        StartCoroutine(wait_hit());
    }

    public void spawn_chauve_souris()
    {
        GameObject obj = Instantiate(chauve_souris_prefab, proj_pos.transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<fireball>().set_dir(dir);
        obj.GetComponent<fireball>().set_pos(proj_pos.transform.position);
    }

    public void atk()
    {
        if (elapsed_time >= time_beetween_balls) {
            elapsed_time = 0f;
            if (Random.Range(0, 100) <= 15) {
                spawn_chauve_souris();
                return;
            }
            GameObject obj = Instantiate(fireball_prefab, proj_pos.transform.position, Quaternion.identity) as GameObject;
            obj.GetComponent<fireball>().set_dir(dir);
            obj.GetComponent<fireball>().set_pos(proj_pos.transform.position);
        } else {
            elapsed_time += Time.deltaTime;
        }
    }

    public void locate_player()
    {
        if (transform.position.x < player.transform.position.x) {
            if (dir == -1) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                dir = 1;
            }
        } else {
            if (dir == 1) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                dir = -1;
            }
        }
    }

    public bool is_player() {
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y / 2), Vector3.right * dir, atk_range, player_layer);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y / 2), Vector3.right * dir, atk_range, player_layer);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector3.right * dir, atk_range, player_layer);
        return (hit1.collider != null || hit2.collider != null || hit3.collider != null);
    }

    public void ia_fight() {
        if (is_player()) {
            StartCoroutine(wait_atk());
        } else {
            transform.Translate(Vector3.right * speed * Time.deltaTime * dir);
        }
    }

    public void ia()
    {
        if (get_hit) {
            return;
        }
        if (is_figth || is_player()) {
            is_figth = true;
            ia_fight();
            return;
        }
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y / 2), Vector3.right * dir, dist_to_ground, ground);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - Vector3.up * (gameObject.GetComponent<SpriteRenderer>().size.y / 2), Vector3.right * dir, dist_to_ground, ground);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector3.right * dir, dist_to_ground, ground);
        if (hit1.collider != null || hit2.collider != null || hit3.collider != null) {
            dir *= -1;
            transform.Translate(Vector3.right * dir * speed * Time.deltaTime);
            if (dir == 1) {
                transform.localScale = new Vector3(abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else {
                transform.localScale = new Vector3(-abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            return;
        }
        if (Random.Range(0, 100) < 15) {
            dir *= -1;
        }
        if (dir == 1) {
            transform.localScale = new Vector3(abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(-abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime * dir);
    }

    private float abs(float x)
    {
        if (x < 0) {
            return -x;
        }
        return x;
    }

    void FixedUpdate()
    {
        if (life <= 0)
        {
            StartCoroutine(wait_death());
            return;
        }
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 3f, player_layer);
        if (collider != null || is_player()) {
            is_figth = true;
            locate_player();
        } else if (!get_hit) {
            is_figth = false;
        }
        ia();
    }
}
