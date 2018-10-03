using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public GameObject Player;
    public GameObject PlayerPrefab;
    public KeyDoorManager keyDoorManager;
    public GameObject GameOverMessage;
    public Transform PlayerStartPoint;
    

    private void Start()
    {
        GameOverMessage.SetActive(false);
        keyDoorManager = GetComponent<KeyDoorManager>();
    }

    private void Update()
    {
        if (Player == null)
        {
            GameOver();

        }


    }

    public void GameOver()
    {
        GameOverMessage.SetActive(true);

    }

    public void ResetGame()
    {

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
