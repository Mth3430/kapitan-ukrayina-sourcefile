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
        map = Random.Range(1, 100);
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
        print(map);
        if (map < 50)
        {
            map1.SetActive(true);
        }
        if (map >= 50)
        {
            map2.SetActive(true);
        }
        else
        {
            map1.SetActive(true);
        }
        captain.transform.position = spawnpoint.transform.position;
        isstarted = true;
    }
}
