using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_scene : MonoBehaviour
{
    public GameObject[] scenes;
    public GameObject[] spawn_ppoints;
    public GameObject _camera;
    public Vector3 position;
    public float speed = 200f;
    public bool is_active = false;
    public all_var_script all_var;

    private void Start() {
        position = transform.position;
        _camera = GameObject.Find("Main Camera");
    }

    IEnumerator wait_end(Collider2D collider) {
        _camera.GetComponentInChildren<detect_player>().detect_car = true;
        _camera.GetComponent<Script_Cam>().follow_car = true;
        collider.gameObject.SetActive(false);
        is_active = true;
        yield return new WaitForSeconds(2f);
        is_active = false;
        transform.position = position;
        all_var.add_nbr_win(1);
        foreach (GameObject scene in scenes) {
            scene.SetActive(false);
        }
        collider.gameObject.SetActive(true);
        int rand = Random.Range(0, scenes.Length);
        scenes[rand].SetActive(true);
        collider.gameObject.transform.position = spawn_ppoints[0].transform.position;
        _camera.GetComponent<Script_Cam>().follow_car = false;
        _camera.GetComponentInChildren<detect_player>().detect_car = false;
        _camera.transform.position = new Vector3(spawn_ppoints[0].transform.position.x, _camera.transform.position.y, _camera.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            StartCoroutine(wait_end(other));
        }
    }

    private void FixedUpdate() {
        if (is_active) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
