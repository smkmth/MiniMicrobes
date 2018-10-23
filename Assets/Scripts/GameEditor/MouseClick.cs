using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameArray gameArray;
    public Grid grid;
    public GameObject Wall;
    public GameObject EnemeySpawn;
    public GameObject PlayerSpawn;
    public bool canEdit;
    public GameArray.Entity EditorMode;
    public GameOverManager gameOver;
    public bool playerSpawnSet;

    
    private void Start()
    {
        canEdit = true;
        gameArray = GetComponent<GameArray>();
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
    }
    void Update()
    {


        if (canEdit)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                Debug.Log("switch");
                EditorMode = GameArray.Entity.Wall;

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                EditorMode = GameArray.Entity.Player;

            } if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                EditorMode = GameArray.Entity.LeftRightEnemey;

            }

            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "GridSquare")
                    {
                        if (EditorMode == GameArray.Entity.Wall)
                        {
                            GridCell gridcell = hit.transform.gameObject.GetComponent<GridCell>();
                            gridcell.tag = "OccupiedGridSquare";
                            gameArray.AddWallToArray(gridcell.x, gridcell.y);
                            GameObject wall = Instantiate(Wall, hit.transform);
                            wall.layer = 10;
                            wall.transform.Translate(0, 0, 0.5f);
                            Debug.Log(gridcell.x + " " + gridcell.y);
                        }
                        else if (EditorMode == GameArray.Entity.Player)
                        {
                            if (!playerSpawnSet)
                            {
                                playerSpawnSet = true;
                            }
                            else
                            {
                                Destroy(PlayerSpawn);
                            }
                            GridCell gridcell = hit.transform.gameObject.GetComponent<GridCell>();
                            gridcell.tag = "OccupiedGridSquare";
                            gameArray.AddElementToArray(gridcell.x, gridcell.y, GameArray.Entity.Player);
                            PlayerSpawn = Instantiate(PlayerSpawn, hit.transform);
                            PlayerSpawn spawnLogic = PlayerSpawn.GetComponent<PlayerSpawn>();
                            spawnLogic.PlayerSpawnLocation = (hit.transform);
                            gameOver.SetPlayerSpawn(spawnLogic);

                            Debug.Log(gridcell.x + " " + gridcell.y);

                        

                        }
                        else if (EditorMode == GameArray.Entity.LeftRightEnemey)
                        {
                            GridCell gridcell = hit.transform.gameObject.GetComponent<GridCell>();
                            gridcell.tag = "OccupiedGridSquare";
                            gameArray.AddElementToArray(gridcell.x, gridcell.y,GameArray.Entity.LeftRightEnemey);
                            GameObject enemey = Instantiate(EnemeySpawn, hit.transform);
                            Patrol enemeyLogic = enemey.GetComponent<Patrol>();
                            enemeyLogic.movingDirection = Patrol.MovingDirections.LeftRight;
                            enemeyLogic.started = true;
                            enemeyLogic.moveSpeed = 10;
                            enemey.layer = 10;
                            enemey.transform.Translate(0, 0, 0.5f);
                            Debug.Log(gridcell.x + " " + gridcell.y);

                        }

                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "OccupiedGridSquare")
                    {

                        GridCell gridcell = hit.transform.gameObject.GetComponent<GridCell>();
                        gameArray.RemoveElementFromArray(gridcell.x, gridcell.y);
                        Debug.Log("Removed " + gridcell.x + " " + gridcell.y);
                        Destroy(hit.transform.GetChild(0).gameObject);
                    }


                }


            }
        }
    }
}
