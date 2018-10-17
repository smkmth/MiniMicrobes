using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMovement : MonoBehaviour {
    public float movementx;
    public float movementy;
    public float speed;
    public Vector3 movementVector;
    

	
	// Update is called once per frame
	void Update () {

        movementx = Input.GetAxis("Horizontal");
        movementy = Input.GetAxis("Vertical");
        movementVector = new Vector3(movementx, movementy, 0);

        transform.Translate(movementVector * speed);


     


    }
}
