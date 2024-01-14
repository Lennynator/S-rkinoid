using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public Transform Player;
    private Rigidbody2D rb;
    private Vector2 Movement;
    public float MoveSpeed = 5f; 
    public spawner spawnerScript;
    public scoremanager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("särki").transform;
        scoreManager = FindObjectOfType<scoremanager>();
        spawnerScript = FindObjectOfType<spawner>();
    }

    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            Movement = direction;
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(Movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * MoveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("särki"))
        {
            Destroy(gameObject);
            if (spawnerScript != null)
            {
                spawnerScript.EnemyDestroyed();
            }
            if (spawnerScript != null && spawnerScript.blinkingText != null)
            {
                spawnerScript.blinkingText.StopBlinking();
            }
            else if (spawnerScript.blinkingText != null)
            {
                spawnerScript.blinkingText.StopBlinking();
            }
        }
        if (collision.gameObject.CompareTag("ball"))
        {
            Destroy(gameObject);
            if (spawnerScript != null)
            {
                spawnerScript.EnemyDestroyed();
                spawnerScript.blinkingText.StopBlinking();
                scoreManager.addpoint();
            }
        }
    }
}
