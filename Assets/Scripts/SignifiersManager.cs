using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignifiersManager : MonoBehaviour
{
    public GameObject [] coloredSignifiers;
    public GameObject [] blankSignifiers;

    public SmoothScrollRectSnapping smoothScrolling;

    // private int [] gridElementNumber = {0, 1, 2, 3};
    public int gridElementNumber;

    private void Start()
    {
        
    }

    private void Update()
    {

        gridElementNumber = smoothScrolling.gridElementNumber;

        for(int i = 0; i < coloredSignifiers.Length; i++)
        {
            if(gridElementNumber == i)
            {
                // Debug.Log("Blue!!");
                // signifiers[i].GetComponent<Image>().color = new Color(79, 170, 255, 255);
                coloredSignifiers[i].SetActive(true);
                blankSignifiers[i].SetActive(false);
            }
            else
            {
                // signifiers[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                coloredSignifiers[i].SetActive(false);
                blankSignifiers[i].SetActive(true);
            }
        }
    }
}
