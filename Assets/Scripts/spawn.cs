using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public all_mobs spawnMobs;
    public float elapsedTime;
    public float spawnTime;
    public int chance = 15;
    public bool is_active = false;

    public void set_active(bool is_active)
    {
        this.is_active = is_active;
    }

    void FixedUpdate()
    {
        if (!is_active) {
            return;
        }
        if (elapsedTime >= spawnTime) {
            elapsedTime = 0;
            if (Random.Range(0, 100) < chance) {
                int randomIndex = (Random.Range(0, 100) <= 2) ? 1 : 0;
                if (randomIndex == 1 && spawnMobs.nbr_vlad >= spawnMobs.max_vlad) {
                    if (spawnMobs.nbr_rus >= spawnMobs.max_rus) {
                        return;
                    }
                    spawnMobs.nbr_rus += 1;
                    randomIndex = 0;
                } else if (randomIndex == 1) {
                    spawnMobs.nbr_vlad += 1;
                } else {
                    if (spawnMobs.nbr_rus >= spawnMobs.max_rus) {
                        return;
                    }
                    spawnMobs.nbr_rus += 1;
                }
                Instantiate(spawnObjects[randomIndex], transform.position, Quaternion.identity);
            }
        } else {
            elapsedTime += Time.deltaTime;
        }
    }
}
