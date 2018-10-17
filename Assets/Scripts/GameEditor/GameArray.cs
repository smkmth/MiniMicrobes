using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArray : MonoBehaviour {

    public int[] FinalArray;
    public int amountOfRows = 19;
  



	// Use this for initialization
	void Start () {
        FinalArray = new int[200];
        foreach (int element in FinalArray)
        {

            FinalArray[element] = 0;
        }
		

    }
	


    public void AddWallToArray(int arrayx, int arrayy)
    {
       // string name = whattoadd.name;


        //Element = currentColumn * rowsNumber + currentRow
        int index = arrayx * amountOfRows + arrayy;
        FinalArray[index] = 1;


    }

    
}
