using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public GameObject Player;
    public GameObject PlayerPrefab;
    public KeyDoorManager keyDoorManager;
    public GameObject GameOverMessage;
    public PlayerSpawn PlayerSpawner;
    public bool gameIsRunning = false;
    public bool gameOverMenuIsOn = false;
    

    private void Start()
    {
        keyDoorManager = GetComponent<KeyDoorManager>();
    }

    private void Update()
    {
        if (gameIsRunning)
        {

            if (Player = null)
            {

                GameOver();
            }
        }
        if (gameOverMenuIsOn)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ResetGame();
            }
        }


    }

    public void GameOver()
    {
        GameOverMessage.SetActive(true);
        gameOverMenuIsOn = true;
    }

    public void SetPlayerSpawn(PlayerSpawn playerSpawn)
    {
        if (PlayerSpawner != null)
        {
            PlayerSpawner = playerSpawn;
        } else
        {
            PlayerSpawner = null;
            PlayerSpawner = playerSpawn;

        }
    }

    public void ResetGame()
    { 
        gameOverMenuIsOn = false;


        PlayerSpawner.SpawnPlayer();
        GameOverMessage.SetActive(false);
        foreach(Key key in keyDoorManager.takenKeys)
        {
            key.gameObject.SetActive(true);
            
        }

        foreach(Door door in keyDoorManager.openDoors)
        {
            door.CloseDoor();
        }

        keyDoorManager.FlushLists();


    }





}
