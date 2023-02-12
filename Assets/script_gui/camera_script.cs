using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    public float speed = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
