using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5.0f;

    public int maxHP = 4;

    public int PLAYERHP = 4;

    public int PlayerAmmo = 3;

    public int maxAmmo = 3;


    private Vector3 originalScale;


    public Health healthScript;

    public spawner spawner;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthScript = GetComponent<Health>();
        PLAYERHP = healthScript.HealthValue;
        PlayerAmmo = healthScript.AmmoValue;
        originalScale = transform.localScale;

        GameObject spawnerObject = GameObject.Find("spawner");

        if (spawnerObject != null)
        {
            spawner = spawnerObject.GetComponent<spawner>();
        }

      
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = moveDirection * moveSpeed;

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = originalScale;
        }

        if (Input.GetKeyDown("space") && PlayerAmmo != 0)
        {
            spawner.RespawnBall();
            ChangeAmmo(-1);

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tappajahauki"))
        {
            
            ChangeHealth(-1);

          

        }
    }

    public void ChangeHealth(int change)
    {

           
        if (PLAYERHP > maxHP)
        {
            PLAYERHP = maxHP;
        } 


        if (PLAYERHP == 1)
        {
            Destroy(gameObject);
            healthScript.HealthValue = PLAYERHP;
            SceneManager.LoadScene("LoseScreen");

        }
        else
        {
            PLAYERHP = PLAYERHP + change;
            healthScript.HealthValue = PLAYERHP;
            PlayerPrefs.SetInt("health", PLAYERHP); 
            PlayerPrefs.Save();

        }
        

    }

    public void ChangeAmmo(int change)
    {


        if (PlayerAmmo > maxAmmo)
        {
            PlayerAmmo = maxAmmo;
        }


        if (PlayerAmmo == 0)
        {
            healthScript.AmmoValue = PlayerAmmo;

        }
        else
        {
            PlayerAmmo = PlayerAmmo + change;
            healthScript.AmmoValue = PlayerAmmo;
            PlayerPrefs.SetInt("ammo", PlayerAmmo); 
            PlayerPrefs.Save();


        }

    }

}
