using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public string[] playerInput = new string[3] { "z", "q", "d" };
    public float speed = 1f;
    public float jump = 1f;
    public float dist_to_ground = 1f;
    public LayerMask ground;

    bool is_grounded() {
        return Physics2D.Raycast(transform.position, Vector3.down, dist_to_ground, ground).collider != null;
    }

    void LateUpdate()
    {
        if (Input.GetKey(playerInput[0]))
        {
            if (is_grounded())
            {
                Debug.Log("jump");
                transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jump);
            }
        }
        if (Input.GetKey(playerInput[1]))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(playerInput[2]))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (is_grounded())
            {
                Debug.Log("jump");
                transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jump);
            }
        }
    }
}
