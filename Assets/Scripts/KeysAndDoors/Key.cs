using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    //its how we know what key this is 
    public string whatDoorThisOpens;
    public KeyDoorManager keyDoorManager;
    public Transform keyLocation;

	// Use this for initialization
	void Start () {

        keyDoorManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<KeyDoorManager>();
        keyLocation = gameObject.transform;
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            DestroyKey();
            keyDoorManager.AddKey(this);
            keyDoorManager.levelKeys.Add(gameObject);
        }
        
    }


    public void DestroyKey()
    {

        gameObject.SetActive(false);
    }

    
}
