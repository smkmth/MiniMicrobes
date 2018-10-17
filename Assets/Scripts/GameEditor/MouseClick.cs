using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameArray gameArray;
    public Grid grid;
    public GameObject Wall;


    private void Start()
    {
        gameArray = GetComponent<GameArray>();
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "GridSquare")
                {
                    GridCell gridcell = hit.transform.gameObject.GetComponent<GridCell>();
                    gameArray.AddWallToArray(gridcell.x, gridcell.y);
                    Instantiate(Wall, hit.transform);


                    Debug.Log(gridcell.x + " " + gridcell.y);

                }
            }
        }
    }
}
