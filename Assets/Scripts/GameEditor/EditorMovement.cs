using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMovement : MonoBehaviour {
    public float movementx;
    public float movementy;
    public float speed;
    public Vector3 movementVector;
    public MouseClick editorClick;
    public Camera editorCam;
    public Camera playerCam;
    public bool editorControl;

    public PlayerMovement player;
    private void Start()
    {
        editorClick = GetComponent<MouseClick>();
        editorControl = true;
        editorClick.canEdit = true;
        playerCam.enabled = false;
        editorCam.enabled = true;

        
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
        if (Input.GetButtonDown("Play"))
        {
            SwitchControl();
        }

    }

    public void SwitchControl()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        
        if (editorControl == true)
        {
            player.ControlPlayer();
            editorControl = false;
            editorClick.canEdit = false;
            playerCam.enabled = true;
            editorCam.enabled = false;
        }
        else
        {
            player.StopControllingPlayer();
            editorControl = true;
            editorClick.canEdit = true;
            playerCam.enabled = false;
            editorCam.enabled = true;



        }
    }
}
