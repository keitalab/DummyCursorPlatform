using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSession : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Onclick()
    {
        Settings.experimentSessionCounts.Clear();
    }
}
