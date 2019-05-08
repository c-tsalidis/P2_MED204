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

    private void Update()
    {
        for(int i = 0; i < gridElements.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - gridElements[i].transform.position.x);
        }

        float minimumDistance = Mathf.Min(distance); // returns the smallest of every element of the distance array
        for(int i = 0; i < gridElements.Length; i++)
        {
            
            if(minimumDistance == distance[i] && gridElementNumber_isChangedOnClick == false)
            {
                gridElementNumber = i;
            }
        } 
        if(!isBeingDragged)
        {
            LerpToGridElement(gridElementNumber * -gridElementsDistance);
        }
    }

    private void LerpToGridElement(int position)
    {
        float newX = Mathf.Lerp(scrollablePanel.anchoredPosition.x, position, Time.deltaTime * scrollForce); // linearly interpolates between a and b by time t
        Vector2 newPosition = new Vector2(newX, scrollablePanel.anchoredPosition.y);

        scrollablePanel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        isBeingDragged = true;
    }

    public void EndDrag()
    {
        isBeingDragged = false;
    }

    public void ChangeGridElementNumber(int newGridElementNumber)
    {
        gridElementNumber_isChangedOnClick = true; // to be able to modify the grid element number (because it  is updated in each frame in the Update method)
        gridElementNumber = newGridElementNumber;
        StartCoroutine(WaitForAWhile(newGridElementNumber)); // wait for a couple of seconds to make the sliding transition smooth
    }

    IEnumerator WaitForAWhile(int newNumber)
    {
        yield return new WaitForSeconds(5); // waiting for 5 seconds
        Debug.Log("Changed the grid element number to: " + newNumber);
        gridElementNumber_isChangedOnClick = false;
    }

}
