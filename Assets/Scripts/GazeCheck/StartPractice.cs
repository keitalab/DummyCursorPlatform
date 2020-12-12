using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartPractice : MonoBehaviour {
    public void onClick () {
        SceneManager.LoadScene ("CountDown");
    }
}