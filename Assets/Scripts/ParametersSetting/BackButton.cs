using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackButton : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnClick()
    {
        Settings.resetParams();
        SceneManager.LoadScene("StartScreen");
    }
}
