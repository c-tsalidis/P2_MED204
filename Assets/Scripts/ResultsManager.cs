using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultsPanel;

    [SerializeField]
    private string playerPrefsKey;

    [SerializeField]
    private Text efficiencyText;
    
    public void ShowResults()
    {
        int efficiency = PlayerPrefs.GetInt(playerPrefsKey);
        resultsPanel.SetActive(true);
        efficiencyText.text = efficiency.ToString() + "%";
    }

    public void ReturnToQuestions()
    {
        resultsPanel.SetActive(false);
    }
}
