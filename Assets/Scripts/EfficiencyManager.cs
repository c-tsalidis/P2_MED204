using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfficiencyManager : MonoBehaviour
{
    // private variables

    // the private variables have the [SerializeField] so as to be able to
    // view them and modify them directly in the Unity Editor

    [SerializeField]
    private int overallEfficiency; // the overall efficiency of the user

     [SerializeField]
    private Text overallEfficiencyText; // the text responsible for showing the overall eficiency

    [SerializeField]
    private Transform [] subjectPanels; // the transform components of the panels of each subject

    [SerializeField]
    private float xOffset; // the offset of the panels in the x axis

    [SerializeField]
    private float yOffset;  // the offset of the panels in the y axis

    [SerializeField]
    private Text [] efficienciesTexts; // the efficiencies texts of each subject

    public int [] efficiencies; // the efficiencies of each subject
    
    
    // Start is called before the first frame update
    void Start()
    {
        // get the int efficiencies of each subject stored in the device
        efficiencies[0] = PlayerPrefs.GetInt("Efficiency Maths");
        efficiencies[1] = PlayerPrefs.GetInt("Efficiency Physics");
        efficiencies[2] = PlayerPrefs.GetInt("Efficiency Biology");
        efficiencies[3] = PlayerPrefs.GetInt("Efficiency Chemistry");
        efficiencies[4] = PlayerPrefs.GetInt("Efficiency Geography");

        // goes through all the efficiencies
        for (int i = 0; i < efficiencies.Length ; i++)
        {
            // the overall efficiency is at first 0, but then is summed up with each efficiency
            overallEfficiency += efficiencies[i];
            // initialize the texts of the efficiencies of each subject texts
            efficienciesTexts[i].text = efficiencies[i].ToString() + " %";
        }    

        // the overall efficiency is the sum of all the efficiencies divided by the number of efficiencies
        // round it to an integer in case it gives a float number
        overallEfficiency = Mathf.RoundToInt(overallEfficiency / efficiencies.Length);
        
        // setting the the overall efficiency text to be the overall efficiency int as a string +  the % sign
        overallEfficiencyText.text = overallEfficiency.ToString() + " %";
    }

    // Update method executed every frame
    private void Update()
    {
        // goes through all the subject panels
        for(int i = 0; i < subjectPanels.Length; i++)
        {
            // sets the size of each subject panel
            // x axis --> xOffset value for the width of the panel
            // y axis --> yOffset value + the efficiency of the subject for the height of the panel 
            subjectPanels[i].GetComponent<RectTransform>().sizeDelta = new Vector2(xOffset, efficiencies[i] + yOffset);
        }
        
    }
}
