using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moments;

public class Recoder : MonoBehaviour
{
    public Recorder rec;
    void Start()
    {
        rec = GetComponent<Recorder>();
        rec.Record();
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimationController.index >= SelectFile.count) rec.Save();
    }
}
