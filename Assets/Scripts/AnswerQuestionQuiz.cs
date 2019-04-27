using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerQuestionQuiz : MonoBehaviour
{
    [SerializeField]
    private string buttonText;
    [SerializeField]
    private Text answer;
    public bool isToggle;
    
    public bool toggleText;

    public void AnswerQuizQuestion()
    {
        answer.text = buttonText;
        if(isToggle == true)
        {
            toggleText = !toggleText;
            if(toggleText == true)
            {
                answer.text = buttonText;
            }
            else
            {
                answer.text = "";
            }
        }
        else
        {
            answer.text = buttonText;
        }
    }
}
