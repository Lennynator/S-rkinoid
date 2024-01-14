using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 5.0f;
    public float speed = 2.0f;
    public GameObject ballPrefab;
    public float ballSpawnHeight = 3.0f;
    private spawner Spawner;


    private void Start()
    {
        Spawner = FindAnyObjectByType<spawner>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("särki"))
        {
            ApplyPowerUpEffect();
            Destroy(gameObject);

        }
    }

    void ApplyPowerUpEffect()
    {

        Spawner.RespawnBall();


    }
}
