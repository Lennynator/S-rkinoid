using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject barPrefab; 
    public int rowCount = 4;
    public int objectsPerRow = 8;

    public float spawnChance = 0.1f;
    public float spawnIncreaseRate = 0.01f;
    private float nextSpawnTime;

    public bool isEnemyActive = false;
    public GameObject enemyPrefab;

    public BlinkingText blinkingText;

    public Vector2 spawnArea = new Vector2(4.5f, 4.75f); 
    public float spacing = 1.0f;

    public AudioSource musicAudioSource;
    public GameObject ballPrefab;

    public Transform player;

    public int currentlevel;

    public enemy enemy;




    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(5f, 10f);
        player = GameObject.Find("särki").transform;
        currentlevel = PlayerPrefs.GetInt("currentlevel", 0);



        blinkingText.StopBlinking();

        if (currentlevel == 2)
        {
            enemy.MoveSpeed = 5f;
        }


        SpawnGrid();
       

    }

    void Update()
    {
        if (!isEnemyActive)
        {
            if (Time.time > nextSpawnTime && Random.value < spawnChance)
            {
                SpawnEnemy();

                IncreaseSpawnChanceOverTime();
            }
        }
       

    }

    IEnumerator DelayBlinkingText()
    {

        yield return new WaitForSeconds(3f); 
        blinkingText.StartBlinking();
    }

    

    void SpawnGrid()
    {
        float startX = transform.position.x - spawnArea.x / 4;
        float startY = transform.position.y + spawnArea.y / 2;

        
            for (int i = 0; i < rowCount; i++)
            {

                for (int j = 0; j < objectsPerRow; j++)
                {

                    float xPos = startX + j * spacing;
                    float yPos = startY - i * spacing;
                    Vector3 spawnPosition = new Vector3(xPos, yPos, 0);

                    Instantiate(barPrefab, spawnPosition, Quaternion.identity);
                }
            }

        }
       
        
    
    void SpawnEnemy()
    {
        isEnemyActive = true;
        if (musicAudioSource != null)
        {
            musicAudioSource.Play();


        }
        StartCoroutine(DelayBlinkingText());
        blinkingText.StartBlinking();
        Vector2 spawnPosition1 = new Vector2(-3.6f, 6f);
        Vector2 spawnPosition2 = new Vector2(5.5f, 6f);

        Vector2 spawnPosition = Random.Range(0f, 1f) < 0.5f ? spawnPosition1 : spawnPosition2;

        GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

       
    }

    public void RespawnBall()
    {
        Vector3 spawnPosition = new Vector3(player.position.x, player.position.y + 1.0f, player.position.z);

        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        transform.position = Vector3.zero;
    }

    public void EnemyDestroyed()
    {
        {

            isEnemyActive = false;
            blinkingText.StopBlinking();
            if (musicAudioSource != null)
            {
                musicAudioSource.Stop(); 
            }
            nextSpawnTime = Time.time + Random.Range(1f, 5f);
        }

    }

    void IncreaseSpawnChanceOverTime()
    {
        spawnChance += spawnIncreaseRate * Time.deltaTime;
    }

}