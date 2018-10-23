using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {


    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public float moveSpeed;
    public bool started;
    private bool moving;
    public MovingDirections movingDirection;
    private SpriteRenderer sp;
    public enum MovingDirections
    {
        UpDown,
        LeftRight,
        DownUp,
        RightLeft,

    };

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        started = false;
    }

    public void InitEnemey(MovingDirections direction, float speed)
    {
        moveSpeed = speed;
        movingDirection = direction;
        

    }

    // Update is called once per frame
    void FixedUpdate () {
        
        if (movingDirection == MovingDirections.LeftRight)
        {
            moveDirection = Vector2.left;
        } 
        else if (movingDirection == MovingDirections.RightLeft)
        {
            moveDirection = Vector2.left;
        }
        else if (movingDirection == MovingDirections.UpDown)
        {
            moveDirection = Vector2.up;

        }
         else if (movingDirection == MovingDirections.DownUp)
        {
            moveDirection = Vector2.up;

        }

        if (started == true)
        {
            rb.AddForce(moveDirection * moveSpeed);
            if (moving != true)
            {
                UnfreezeObject(movingDirection);
                moving = true;
            }
        }
        else
        {
            FreezeObject();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection *= -1;
        //transform.Rotate(Vector2.right * -90);

    }


    public void UnfreezeObject(MovingDirections direction)
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (direction == MovingDirections.LeftRight || direction == MovingDirections.RightLeft)
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else if (direction == MovingDirections.UpDown || direction == MovingDirections.DownUp)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;

        }

    }

    public void FreezeObject()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    
    


}
