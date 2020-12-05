using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if(Directory.Exists("ogapy"))
        {
            Directory.CreateDirectory("kyon");
        }
        else
        {
            Directory.CreateDirectory("ogapy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Settings.Quit();

    }
}
