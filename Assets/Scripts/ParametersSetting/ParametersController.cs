using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParametersController : MonoBehaviour
{
    public static bool isSet = false;
    void Start()
    {
    }

    public void InputParameters()
    {
        isSet = true;
        SceneManager.LoadScene("StartScreen");
    }
}
