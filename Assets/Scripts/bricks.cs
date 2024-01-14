using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class bricks : MonoBehaviour
{
    [SerializeField]
    public GameObject powerUpPrefab;
    public GameObject heartPrefab;
    public float dropChance = 0.9f;


    private int HP = 3;
    private Transform squareTransform;
    public spawner spawner;
    public int currentlevel = 0;


    private void Start()
    {

        squareTransform = transform.Find("Square");
        currentlevel = PlayerPrefs.GetInt("currentlevel", 0);

    }


  


    public void OnCollisionEnter2D(Collision2D collision)
    {
        HP--;

        if (HP == 2)
        {
            squareTransform.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (HP == 1)
        {
            squareTransform.GetComponent<Renderer>().material.color = Color.red;
        }

        if (HP == 0)
        {

            Destroy(gameObject);
            scoremanager.instance.addpoint();

            if (Random.value < dropChance)
            {
                DropPowerUp();
            }

            CheckWinCondition();
        }
    }
    void DropPowerUp()
    {
        if (Random.value > 0.5) {
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity); }
        else
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
    }

    void CheckWinCondition()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        if (bricks.Length == 1)
        {
            HandleWin();
        }
    }



    void HandleWin()
    {
        currentlevel++;

        PlayerPrefs.SetInt("currentlevel", currentlevel);
        PlayerPrefs.Save();

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex < totalScenes - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("WinScreen");
        }

    }



}






