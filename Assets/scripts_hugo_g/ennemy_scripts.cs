using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_scripts : MonoBehaviour
{
    public float life = 3;

    public void take_damages(float damage)
    {
        life -= damage;
    }

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
