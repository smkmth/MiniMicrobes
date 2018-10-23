using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public Transform PlayerSpawnLocation;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnPlayer()
    {
        Instantiate(player, PlayerSpawnLocation);
    }

}
