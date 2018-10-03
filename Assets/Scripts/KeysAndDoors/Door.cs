using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Color doorColor;
    public string doorName;
    public BoxCollider2D boxCollider;
    public KeyDoorManager keyManager;

    // Use this for initialization
    void Start()
    {
        
        boxCollider = GetComponent<BoxCollider2D>();
        keyManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<KeyDoorManager>();

    }


    public void OpenDoor()
    {
        boxCollider.isTrigger = true;


    }

    public void CloseDoor()
    {
        boxCollider.isTrigger = false;
    }

    public void CheckKey()
    {

        foreach (Key key in keyManager.takenKeys)
        {

            if (key.whatDoorThisOpens == doorName)
            {

                OpenDoor();
                keyManager.openDoors.Add(this);
            }
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            CheckKey();
        }


    }
}

