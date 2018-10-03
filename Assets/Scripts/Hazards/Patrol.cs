using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {


    public Rigidbody2D rb;
    public Vector2 moveDirection;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        rb.AddForce(moveDirection);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection *= -1;
    }


}
