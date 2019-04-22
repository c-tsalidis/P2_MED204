using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartManager : MonoBehaviour
{
    public enum State { Blueprint, Highlighted, Finished};
    public GameObject [] shipPart;


    public bool isSelected;


    public void ChangePrefab(State newState)
    {
        Debug.Log("New state of " + gameObject.transform.name + ": " + newState);
        if(newState != State.Finished) // if the state of the prefab is not the finished one, because once it's finished we don't want to change it back to unfinished states
        {
            if(newState == State.Blueprint)
            {
                
                shipPart[0].SetActive(true);
                shipPart[1].SetActive(false);
                shipPart[2].SetActive(false);
                 
                /*
                Debug.Log(shipPart[0].transform.childCount); 
                shipPart[0].GetComponentInChildren<Renderer>().enabled = true;
                shipPart[1].GetComponentInChildren<Renderer>().enabled = false;
                shipPart[2].GetComponentInChildren<Renderer>().enabled = false;
                 */
                  
            }
            else if(newState == State.Highlighted)
            // else 
            {
                
                shipPart[0].SetActive(false);
                shipPart[1].SetActive(true);
                shipPart[2].SetActive(false);
                 
                 /*
                shipPart[0].GetComponentInChildren<Renderer>().enabled = false;
                shipPart[1].GetComponentInChildren<Renderer>().enabled = true;
                shipPart[2].GetComponentInChildren<Renderer>().enabled = false;
                  */
            }
        }
        if(PrefabSelectionAR.statusOfText == "Engine")
        {
            shipPart[0].SetActive(false);
            shipPart[1].SetActive(true);
            shipPart[2].SetActive(false);
        }
    }
    public void ChangePrefab(int newState)
    {
        if(newState != 2) // if not finished
        {
            if(newState == 0) // --> blueprint
            {
                shipPart[0].SetActive(true);
                shipPart[1].SetActive(false);
                shipPart[2].SetActive(false);
            }
            else if(newState == 1)// it's 1 --> highlight
            {
                shipPart[0].SetActive(false);
                shipPart[1].SetActive(true);
                shipPart[2].SetActive(false);
            }
        }
    }
}
