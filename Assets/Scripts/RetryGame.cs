using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RetryGame : MonoBehaviour
{

   

    public void LoadScene() {
        PlayerPrefs.SetInt("currentlevel", 0);
        PlayerPrefs.SetInt("health", 4);
        PlayerPrefs.SetInt("ammo", 3);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1");
    }
}
