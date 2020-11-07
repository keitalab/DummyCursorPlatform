using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSpeed : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Onclick()
    {
        Settings.cursorSpeeds.Clear();
    }
}
