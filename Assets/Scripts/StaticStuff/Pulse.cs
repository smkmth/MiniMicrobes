using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {


    // Grow parameters
    public float approachSpeed = 0.02f;
    public float growthBound = 2f;
    public float shrinkBound = 0.5f;
    private float currentRatio = 1;

    // The text object we're trying to manipulate
    private float originalFontSize;

    // And something to do the manipulating
    private Coroutine routine;
    private bool keepGoing = true;
    private bool closeEnough = false;


    // Use this for initialization
    void Start () {


        routine = StartCoroutine(Pulseing());


    }

    public void StopPulsing()
    {
        StopAllCoroutines();
        
    }

    // Update is called once per frame
   
    IEnumerator Pulseing()
    {
        // Run this indefinitely
        while (keepGoing)
        {
            // Get bigger for a few seconds
            while (currentRatio != growthBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                
                gameObject.transform.localScale = Vector3.one * currentRatio;
                

                yield return new WaitForEndOfFrame();
            }

            // Shrink for a few seconds
            while (currentRatio != shrinkBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

               
                gameObject.transform.localScale = Vector3.one * currentRatio;
                

                yield return new WaitForEndOfFrame();
            }
        }
    }
}

