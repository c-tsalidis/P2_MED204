using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfficiencyManager : MonoBehaviour
{

    public int [] efficiencies;
    [SerializeField]
    private int overallEfficiency;

    [SerializeField]
    private Text overallEfficiencyText;

    [SerializeField]
    private Transform [] subjectPanels;

    [SerializeField]
    private float offset;

    [SerializeField]
    private Text [] efficienciesTexts;

    // Start is called before the first frame update
    void Start()
    {
        efficiencies[0] = PlayerPrefs.GetInt("Efficiency Maths");
        efficiencies[1] = PlayerPrefs.GetInt("Efficiency Physics");
        efficiencies[2] = PlayerPrefs.GetInt("Efficiency Biology");
        efficiencies[3] = PlayerPrefs.GetInt("Efficiency Chemistry");
        efficiencies[4] = PlayerPrefs.GetInt("Efficiency Geography");

        for (int i = 0; i < efficiencies.Length ; i++)
        {
            overallEfficiency += efficiencies[i];
            efficienciesTexts[i].text = efficiencies[i].ToString() + " %";
        }    

        overallEfficiency = Mathf.RoundToInt(overallEfficiency / efficiencies.Length);

        overallEfficiencyText.text = overallEfficiency.ToString() + " %";
    }

    private void Update()
    {
        /* 
        for(int i = 0; i < subjectPanels.Length; i++)
        {
            subjectPanels[i].GetComponent<RectTransform>().sizeDelta = new Vector2(41, efficiencies[i] * offset);
        }
        */
    }
}
