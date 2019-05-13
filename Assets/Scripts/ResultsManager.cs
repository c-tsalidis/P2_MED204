using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the results of the user
/// </summary>
public class ResultsManager : MonoBehaviour
{

    // private variables
    // [SerializeField] used to be able to modify and view the private variables directly in the Unity Editor 
    
    // the results panel
    [SerializeField]
    private GameObject resultsPanel;

    // the name of the efficiency's key stored in the device using PlayerPrefs
    [SerializeField]
    private string playerPrefsKey;

    // the text that shows the efficiency of the subject to the user
    [SerializeField]
    private Text efficiencyText;

    // called when the user clicks on the "Finish" button of the quiz
    // displays the results of the quiz to the user  
    public void ShowResults()
    {
        // gets the efficiency of the subject (part of the boat) stored in the device
        int efficiency = PlayerPrefs.GetInt(playerPrefsKey);
        // activates the results panel
        resultsPanel.SetActive(true);
        // sets the efficiency text to be the efficiency of the subject (part of the boat)
        efficiencyText.text = efficiency.ToString() + "%";
    }

    // hides the results from the user
    public void ReturnToQuestions()
    {
        // deactivates the results panel
        resultsPanel.SetActive(false);
    }
}
