using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Switch : MonoBehaviour
{
    public GameObject full;
    public GameObject wind;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void fullon()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    public void fulloff()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
