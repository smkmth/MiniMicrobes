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
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerCanMove = false;
        rb.gravityScale = 0;
		
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
   
}
