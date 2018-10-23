using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMovement : MonoBehaviour {
    public float movementx;
    public float movementy;
    public float speed;
    public Vector3 movementVector;
    public MouseClick editorClick;
 
    public bool editorControl;
    public PlayerMovement player;


    private void Start()
    {
        editorClick = GetComponent<MouseClick>();

    }

    // Update is called once per frame
    void Update () {
        if (editorControl == true)
        {
            movementx = Input.GetAxis("Horizontal");
            movementy = Input.GetAxis("Vertical");
            movementVector = new Vector3(movementx, movementy, 0);

            transform.Translate(movementVector * speed);
        }
        else
        {



        }
    

    }



}
