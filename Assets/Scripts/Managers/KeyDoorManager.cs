using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorManager : MonoBehaviour {
    public List<Key> takenKeys;
    public List<GameObject> levelKeys;
    public List<Door> openDoors;
   

    public void AddKey(Key key)
    {
        takenKeys.Add(key);
    }

    public void FlushLists()
    {
        takenKeys.Clear();
        levelKeys.Clear();
        openDoors.Clear();
    }



    

	
}
