using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float maxSpeed;
    public float movement;
    public Vector2 movementVector;
    public Vector2 burstJumpVector;
    public Vector2 continueJumpVector;
    public Rigidbody2D rb;
    public bool grounded;
    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask groundLayer;
    public bool bursting;
    public bool playerCanMove;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
       // StopControllingPlayer();
		
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);
        if (playerCanMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                movement = Input.GetAxis("Horizontal");
                movementVector = new Vector2(movement, 0);

                rb.AddForce(movementVector * speed);


            }
            else
            {
                movement = 0;
            }

            if (grounded || bursting)
            {
                rb.gravityScale = 1;
            }
            else
            {
                rb.gravityScale = 10;
            }


            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(burstJumpVector, ForceMode2D.Impulse);
            }

            if (Input.GetButton("Jump"))
            {
                bursting = true;

                rb.AddForce(burstJumpVector, ForceMode2D.Force);



            }
            else
            {
                bursting = false;
            }
        } 


    }

    public void ControlPlayer()
    {
        Debug.Log("trying");
        playerCanMove = true;
        rb.gravityScale = 10;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public void StopControllingPlayer()
    {
        Debug.Log("trying back");

        playerCanMove = false;
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;


    }

}
