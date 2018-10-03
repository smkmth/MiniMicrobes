using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorManager : MonoBehaviour {
    public List<Key> keys;
   

    public void AddKey(Key key)
    {
        keys.Add(key);
    }


    

	
}
