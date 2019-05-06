using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothScrollRectSnapping : MonoBehaviour
{


    /*
    // made with this: Mathf.SmoothDamp
    // https://docs.unity3d.com/ScriptReference/Mathf.SmoothDamp.html

    [SerializeField]
    private Scrollbar scrollBar; 
    // [SerializeField]
    // private Transform target;
    // [SerializeField]
    private float smoothTime = 0.3f;
    [SerializeField]
    private float yVelocity = 0.0f;

    [SerializeField]
    private float targetValue;

    [SerializeField]
    private float currentVelocity;

    // Update is called once per frame
    void Update()
    {
        float value = scrollBar.value;

        if(value > 0 && value < 0.25)
        {
            targetValue = 0.25f;
        }
        else if(value > 0.25 && value < 0.5)
        {
            targetValue = 0.55f;
        }
        else if(value > 0.5 && value < 0.75)
        {
            targetValue = 0.75f;
        }
        else
        {
            targetValue = 1;
        }

        float newValue = Mathf.SmoothDamp(value, targetValue, ref currentVelocity, smoothTime);
        scrollBar.value = newValue;
        
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        
    }
     */


     // made with this: https://www.youtube.com/watch?v=9B7ahj1kaYs

    [SerializeField]
    private RectTransform scrollablePanel;
    [SerializeField]
    private GameObject [] gridElements;

    [SerializeField]
    private RectTransform center;
    [SerializeField]
    private float scrollForce = 5f;
    private float [] distance; // distances between the grid elements to the center
    private bool isBeingDragged = false;
    private int gridElementsDistance; // distance between the grid elements
    public int gridElementNumber; //

    [SerializeField]
    private bool gridElementNumber_isChangedOnClick = false;

    private void Start()
    {
        distance = new float[gridElements.Length];
        // gridElementsDistance = (int) Mathf.Abs(gridElements[1].GetComponent<RectTransform>().position.x - gridElements[0].GetComponent<RectTransform>().position.x);
        gridElementsDistance = 300;
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
            /*
            if(minimumDistance <= distance[i])
            {
                gridElementNumber = i-1;
            }
            else if(minimumDistance >= distance[i])
            {
                gridElementNumber = i+1;
            }
             */
        } 
        if(!isBeingDragged)
        {
            LerpToGridElement(gridElementNumber * -gridElementsDistance);
        }
    }

    private void LerpToGridElement(int position)
    {
        float newX = Mathf.Lerp(scrollablePanel.anchoredPosition.x, position, Time.deltaTime * scrollForce); // linearly interpolates between a and b by t
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
        yield return new WaitForSeconds(5);
        Debug.Log("Changed the grid element number to: " + newNumber);
        gridElementNumber_isChangedOnClick = false;
    }

}
