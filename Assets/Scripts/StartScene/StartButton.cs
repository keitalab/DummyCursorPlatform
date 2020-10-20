﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Canvas _canvas;
    public void OnClick()
    {
        SceneManager.LoadScene("CountDown");
        // Canvasを非表示に
        _canvas.gameObject.SetActive(false);
    }
}
