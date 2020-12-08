using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {
    public static Event Instance;

    void Awake () {
        if (Instance == null) DontDestroyOnLoad (this);
        else Destroy (this);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape))
            Settings.Quit ();

    }
}