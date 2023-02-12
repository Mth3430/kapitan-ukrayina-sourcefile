using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misc : MonoBehaviour
{
    public GameObject video;
    public GameObject test2;
    public bool test;
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            video.SetActive(false);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        if (test == true && test2.activeInHierarchy == true)
            yield return new WaitForSeconds(5);
            video.SetActive(true);
        if (test2.activeInHierarchy == false)
            video.SetActive(false);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
            //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(48);
        video.SetActive(false);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
