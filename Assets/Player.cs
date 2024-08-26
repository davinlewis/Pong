using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Ball ball;
    Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }        
        movement = new Vector2(0, Input.GetAxis("Vertical"));
        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            ball.started = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * movementSpeed;
    }
}
