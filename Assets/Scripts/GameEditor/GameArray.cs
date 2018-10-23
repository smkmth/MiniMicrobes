using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArray : MonoBehaviour {

    public int[] FinalArray;
    public int amountOfRows = 19;
    public enum Entity
    {
        Nothing,
        Wall, 
        Player,
        LeftRightEnemey,
        UpDownEnemey

    };
  



	// Use this for initialization
	void Start () {
        FinalArray = new int[200];
        foreach (int element in FinalArray)
        {

            FinalArray[element] = 0;
        }
		

    }
	
    public void AddElementToArray(int arrayx, int arrayy, Entity entity)
    {
        if (entity == Entity.Wall)
        {
            int index = arrayx * amountOfRows + arrayy;
            FinalArray[index] = 1;

        } 
        else if (entity == Entity.LeftRightEnemey)
        {
            int index = arrayx * amountOfRows + arrayy;
            FinalArray[index] = 5;

        }

    }

    public void AddWallToArray(int arrayx, int arrayy)
    {
       // string name = whattoadd.name;


        //Element = currentColumn * rowsNumber + currentRow
        int index = arrayx * amountOfRows + arrayy;
        FinalArray[index] = 1;


    }

    public void RemoveElementFromArray(int arrayx, int arrayy)
    {
        int index = arrayx * amountOfRows + arrayy;
        FinalArray[index] = 0;
    }

    
}
