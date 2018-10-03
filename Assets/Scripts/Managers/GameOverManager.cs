using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public GameObject Player;
    public GameObject PlayerPrefab;
    public KeyDoorManager keyDoorManager;
    public GameObject GameOverMessage;
    public Transform PlayerStartPoint;
    public bool gameOverMenuIsOn = false;
    

    private void Start()
    {
        GameOverMessage.SetActive(false);
        keyDoorManager = GetComponent<KeyDoorManager>();
        ResetGame();
    }

    private void Update()
    {
        if (Player == null)
        {
            GameOver();

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



    public void ResetGame()
    {
        gameOverMenuIsOn = false;


        Player = Instantiate(PlayerPrefab, PlayerStartPoint, true);
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
