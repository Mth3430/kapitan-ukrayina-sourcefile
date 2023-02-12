using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject cinematic;
    public GameObject map1;
    public GameObject map2;
    public GameObject captain;
    public GameObject spawnpoint;
    private bool isstarted;
    int map;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!cinematic.activeInHierarchy && isstarted == false) {
            startingblock();
        }
    }

    void startingblock()
    {
        map = Random.Range(0, 1);
        if (map == 0)
        {
            map1.SetActive(true);
        }
        else
        {
            map2.SetActive(true);
        }
        captain.transform.position = spawnpoint.transform.position;
        isstarted = true;
    }
}
