using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHeart : MonoBehaviour
{
    public PlayerController controller;
    public scoremanager scoremanager;
    public float speed = 2.0f;

    void Start()
    {
        controller = FindAnyObjectByType<PlayerController>();
        scoremanager = FindAnyObjectByType<scoremanager>();

    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("särki"))
        {
            if (controller.PLAYERHP < controller.maxHP)
            {
                controller.ChangeHealth(1);
            }
            else
            {
                scoremanager.addpoint();
            }
            
            Destroy(gameObject);

        }
    }
   
}
