using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages which signifiers are displayed
/// To guide the user in understanding which questions he's answering at that moment
/// If he's answering question number 2, then the signifier corresponding to question 2 will be colored
/// Whereas the rest of the signifiers will be blank 
/// </summary>
public class SignifiersManager : MonoBehaviour
{
    // public variables

    // the colored signifiers (that tell the user which question he's answering)
    public GameObject [] coloredSignifiers;
    // the blank signifiers
    public GameObject [] blankSignifiers;

    // to get the question number the player is currently answering
    // taken from the gridElementNumber
    public SmoothScrollRectSnapping smoothScrolling;
    // the gridElementNumber
    public int gridElementNumber;

    // Update method is called once every frame
    private void Update()
    {
        // the grid element number (same as the question number - 1) is the same as the one in the smootScrolling script
        gridElementNumber = smoothScrolling.gridElementNumber;

        // goes trough all the signifiers
        for(int i = 0; i < coloredSignifiers.Length; i++)
        {
            // if the grid element number is the same as the current value of i,
            // then it means that the user is answering question number i+1
            if(gridElementNumber == i)
            {
                // signifiers[i].GetComponent<Image>().color = new Color(79, 170, 255, 255);
                // activate the colored signifier of index i
                coloredSignifiers[i].SetActive(true);
                // deactivate the blank signifier of index i
                blankSignifiers[i].SetActive(false);
            }
            // else if the user is not answering the question number i + 1
            else
            {
                // signifiers[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                // deactivate the colored signifier of index i
                coloredSignifiers[i].SetActive(false);
                // activate the blank signifier of index i
                blankSignifiers[i].SetActive(true);
            }
        }
    }
}
