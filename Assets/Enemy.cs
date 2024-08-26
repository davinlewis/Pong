using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Rigidbody2D rb;
    Vector2 movement;
    int yVal;
    float error;
    [SerializeField] Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        error = Random.Range(0, 3f);
        if (ball.transform.position.y > transform.position.y+error)
        {
            yVal = 1;
        }
        else if (ball.transform.position.y < transform.position.y - error)
        {
            yVal = -1;
        }
        else
        {
            yVal = 0;
        }
        movement = new Vector2 (0, yVal);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * movementSpeed;
    }
}
