using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_player : MonoBehaviour
{
    public GameObject player;
    public GameObject _camera;
    public bool detect_car = false;

    void Start()
    {
        player = GameObject.Find("captain");
        _camera = GameObject.Find("Main Camera");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == player) {
            _camera.transform.position = new Vector3(player.transform.position.x, _camera.transform.position.y, -10);
        }
    }
}
