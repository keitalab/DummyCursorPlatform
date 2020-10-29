using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearWindowSize : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Onclick()
    {
        Settings.windowSizes.Clear();
    }
}
