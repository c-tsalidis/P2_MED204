using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

/*
    [SerializeField]
    private GameObject draggableObject;
    [SerializeField]
    private float distance;
    private string prefabName;
    [SerializeField]
    private GameObject [] prefabs;
    private bool [] isSelected;

    private void Start()
    {
        isSelected = new bool[prefabs.Length];
    }

    private void Update()
    {
        if((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
            Debug.Log("it's a click on the phone");
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            drag(ray);
        }
        // if it's a computer with a mouse
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("it's a click on the computer with the mouse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            drag(ray);
        }
    }


    private void drag(Ray ray)
    {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            prefabName = hit.transform.name;
            for(int i = 0; i < prefabs.Length; i++)
            {
                if(prefabName == prefabs[i].name)
                {
                    Debug.Log("Found " + prefabName + " which is " + prefabs[i].name);
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                    Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    prefabs[i].transform.position = objPosition;
                    isSelected[i] = true;
                }
                else
                {
                    isSelected[i] = false;
                }
            }
        }
    }


    */


    private bool draggingItem = false;
    [SerializeField]
    private GameObject draggedObject;
    private Vector2 touchOffset;
   
    void Update ()
    {
        if (HasInput)
        {
            DragOrPickUp();
        }
        else
        {
            if (draggingItem)
                DropItem();
        }
    }
     
    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }
 
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;
     
        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null)
                {
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                    draggedObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
                }
            }
        }
    }
 
    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }
 
    void DropItem()
    {
        draggingItem = false;
        draggedObject.transform.localScale = new Vector3(1f,1f,1f);
    }

}
