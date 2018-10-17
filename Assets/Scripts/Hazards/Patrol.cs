using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {


    public Rigidbody2D rb;
    public Vector2 moveDirection;
    public float moveSpeed;
    public bool started;
    public bool moving;
    public char movingDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        started = false;
    }

    public void InitEnemey(char direction, float speed)
    {
        moveSpeed = speed;
        movingDirection = direction; 


    }

    // Update is called once per frame
    void FixedUpdate () {
        if (started == true)
        {
            if (moving != true)
            {
                UnfreezeObject(movingDirection);
                moving = true;
            }
            rb.AddForce(moveDirection * moveSpeed);
        }
        else
        {
            FreezeObject();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection *= -1;
    }


    public void UnfreezeObject(char constraint)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (constraint == 'x')
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        } else if (constraint == 'y')
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;

        }

    }

    public void FreezeObject()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    


}
