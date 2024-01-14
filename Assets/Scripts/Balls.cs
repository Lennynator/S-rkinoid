using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MaxSpeed = 10.0f;
    public float MinSpeed = 5.0f;

    public PlayerController PlayerController;

    private Vector3 lastKnownPosition;

    public float jumpThreshold = 10.0f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerController = FindAnyObjectByType<PlayerController>();
        rb.velocity = new Vector2(0, -MinSpeed);
        lastKnownPosition = transform.position;

    }


    void Update()
    {
        Transform objectTransform = transform;

        Vector3 objectPosition = objectTransform.position;



        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }

        if (rb.velocity.magnitude < MinSpeed)
        {
            if (rb.velocity.y < 0)
            { rb.velocity = new Vector2(rb.velocity.x, -MinSpeed);
            }
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, MinSpeed);
            }

        }
        if (Vector3.Distance(lastKnownPosition, objectPosition) > jumpThreshold)
        {
            objectTransform.position = lastKnownPosition;
        }
        else
        {
            lastKnownPosition = objectPosition;

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("alaraja"))
        {


            Destroy(gameObject);
            PlayerController.ChangeHealth(-1);
        }
    }
}

