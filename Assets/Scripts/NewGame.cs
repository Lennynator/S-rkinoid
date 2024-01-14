using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewGame : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("currentlevel", 0);
        PlayerPrefs.SetInt("health", 4);
        PlayerPrefs.SetInt("ammo", 3);
        PlayerPrefs.SetInt("score", 0);



        PlayerPrefs.Save();
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
}
