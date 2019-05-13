using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothScrollRectSnapping : MonoBehaviour
{    
    // Have this in mind for future updates to make it smoother: Mathf.SmoothDamp
    // https://docs.unity3d.com/ScriptReference/Mathf.SmoothDamp.html


     // Based on this tutorial: https://www.youtube.com/watch?v=9B7ahj1kaYs
    [SerializeField]
    private RectTransform scrollablePanel; // the scrollable panel
    [SerializeField]
    private GameObject [] gridElements; // all the questions (panels)

    [SerializeField]
    private RectTransform center; // the center gameobject to have in mind
    [SerializeField]
    private float scrollForce = 5f;
    private float [] distance; // distances between the grid elements to the center
    private bool isBeingDragged = false;
    private int gridElementsDistance; // distance between the grid elements
    [SerializeField]
    private bool gridElementNumber_isChangedOnClick = false;
    
    public int gridElementNumber; // the number that the panel refers to --> Panel 1 is question 1, so gridElementNumber = 1


    private void Start()
    {
        distance = new float[gridElements.Length];
        // gridElementsDistance = (int) Mathf.Abs(gridElements[1].GetComponent<RectTransform>().position.x - gridElements[0].GetComponent<RectTransform>().position.x);
        gridElementsDistance = 300; // the distance between each panel is 300
        // print(gridElementsDistance);
    }

    // called once every frame
    private void Update()
    {
        // goes through all the grid elements
        for(int i = 0; i < gridElements.Length; i++)
        {
            // calculates the distance from the center to each panel
            distance[i] = Mathf.Abs(center.transform.position.x - gridElements[i].transform.position.x);
        }

        // returns the smallest of every element of the distance array
        float minimumDistance = Mathf.Min(distance);
        
        // goes through all the grid elements
        for(int i = 0; i < gridElements.Length; i++)
        {
            // if the minimum distance is the same as the distance from the question panel i
            if(minimumDistance == distance[i] && gridElementNumber_isChangedOnClick == false)
            {
                // the question panel that should be shown is i
                gridElementNumber = i;
            }
        } 
        // if the scrollrect is not being dragged
        if(!isBeingDragged)
        {
            // lerp the panel question to be the grid element number times minus the distance
            LerpToGridElement(gridElementNumber * -gridElementsDistance);
        }
    }

    // Takes care of displaying the question panel corresponding to the distance to the center
    private void LerpToGridElement(int position)
    {
         // linearly interpolates between a and b by time t
        float newX = Mathf.Lerp(scrollablePanel.anchoredPosition.x, position, Time.deltaTime * scrollForce);
        Vector2 newPosition = new Vector2(newX, scrollablePanel.anchoredPosition.y);
        // set the scrollable panel's anchored position to the new position
        scrollablePanel.anchoredPosition = newPosition;
    }

    // set the fact that panel is being is dragged to true
    // the panel is being dragged
    public void StartDrag()
    {
        isBeingDragged = true;
    }

    // set the fact that panel is being is dragged to false
    // the panel is not being dragged
    public void EndDrag()
    {
        isBeingDragged = false;
    }


    // changing the grid Element number depending on which signifier the user clicks on
    public void ChangeGridElementNumber(int newGridElementNumber)
    {
        // the grid element number has been changed
        // to be able to modify the grid element number (because it  is updated in each frame in the Update method)
        gridElementNumber_isChangedOnClick = true; 
        // the gridElementNumber is the new grid element number corresponding to the signifier button that the user clicked on
        gridElementNumber = newGridElementNumber;
        // start a timer --> wait for a couple of seconds to make the sliding transition smoother
        StartCoroutine(WaitForAWhile(newGridElementNumber));
    }

    // start a timer --> wait for a couple of seconds to make the sliding transition smoother 
    IEnumerator WaitForAWhile(int newNumber)
    {
         // waiting for 5 seconds
        yield return new WaitForSeconds(5);
        Debug.Log("Changed the grid element number to: " + newNumber);
        // the grid element number has not been changed
        // to be able to modify the grid element number (because it  is updated in each frame in the Update method)
        gridElementNumber_isChangedOnClick = false;
    }

}
