using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviour {
    public EditorMovement editorMovement;
    public PlayerMovement playerMovement;
    public GameOverManager gameOverManager;
    public MouseClick editorClick;
    public Camera editorCam;
    public Camera playerCam;


    // Use this for initialization
    void Start () {

        editorMovement = GetComponentInChildren<EditorMovement>();
        gameOverManager = GetComponentInChildren<GameOverManager>();
        editorClick = GetComponentInChildren<MouseClick>();
        editorMovement.editorControl = true;
        editorClick.canEdit = true;
        playerCam.enabled = false;
        editorCam.enabled = true;


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Play"))
        {
            SwitchControl();
        }
        
    }

    public void SwitchControl()
    {
        //GameObject playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");


        if (editorMovement.editorControl == true)
        {
            gameOverManager.gameIsRunning = true;
            gameOverManager.ResetGame();
            PlayerControl();
        }
        else
        {
            EditorControl();

        }
       
        
    }


    public void PlayerControl()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        playerMovement.ControlPlayer();
        editorMovement.editorControl = false;
        editorClick.canEdit = false;
        playerCam.enabled = true;
        editorCam.enabled = false;
    }


    public void EditorControl()
    {
        playerMovement.StopControllingPlayer();
        Destroy(playerMovement.gameObject);
        editorMovement.editorControl = true;
        editorClick.canEdit = true;
        playerCam.enabled = false;
        editorCam.enabled = true;
        gameOverManager.gameIsRunning = false;

    }


    private void NoPlayer()
    {
        Debug.Log("NoPlayerInScene");
    }
}
