using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    public Rigidbody2D rb;
    float xDir;
    float yDir;
    Vector2 movement;
    public bool started = false;
    public bool waitingMid;
    int leftPoints = 0;
    int rightPoints = 0;
    [SerializeField] GameObject leftGoal;
    [SerializeField] GameObject RightGoal;
    [SerializeField] TextMeshProUGUI leftScore;
    [SerializeField] TextMeshProUGUI rightScore;
    public int win = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xDir = Random.Range(-1, 1);
        yDir = Random.Range(-1, 1);
        if (xDir < 0)
        {
            xDir = -1;
        }
        else if (xDir == 0)
        {
            xDir = 1;
        }
        else
        {
            xDir = 1;
        }
        if (yDir < 0) 
        { 
            yDir = -0.5f;
        }
        else if (yDir == 0)
        {
            yDir = 0.5f;
        }
        else
        {
            yDir = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!started || waitingMid) 
        {
            
        }
        else
        {
            movement = new Vector2(xDir, yDir);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Paddle")
        {
            if(collision.gameObject.transform.position.y < transform.position.y && yDir < 0)
            {
                yDir = yDir * -1;
            }
            xDir = -xDir;
        }
        else if(collision.gameObject.tag == "Wall")
        {
            yDir = -yDir;
        }
        else if(collision.gameObject.tag == "Goal")
        {
            if(collision.gameObject.name == "LeftGoal")
            {
                rightPoints++;
                if(rightPoints == 9)
                {
                    win = -1;
                }
                rightScore.SetText(rightPoints.ToString());
                xDir = 1;
            }
            else
            {
                leftPoints++;
                if (leftPoints == 9)
                {
                    win = 1;
                }
                leftScore.SetText(leftPoints.ToString());
                xDir = -1;
            }
            transform.position = new Vector2(0, 0);
            movement = new Vector2(0, 0);
            yDir = Random.Range(-1, 1);
            if (yDir < 0)
            {
                yDir = -0.5f;
            }
            else if (yDir == 0)
            {
                yDir = 0.5f;
            }
            else
            {
                yDir = 0.5f;
            }
            waitingMid = true;
            StartCoroutine(waitTime(1f));
        }
        
    }

    IEnumerator waitTime(float time)
    {
        Debug.Log("Wait started");
        yield return new WaitForSeconds(time);
        waitingMid = false;
        Debug.Log("Wait ended");
    }

}
