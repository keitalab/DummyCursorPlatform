using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDelay : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Onclick()
    {
        Settings.cursorDelays.Clear();
    }
}
