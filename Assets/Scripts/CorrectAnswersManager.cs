using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswersManager : MonoBehaviour
{

    [SerializeField]
    private GameObject [] correctAnswers;
    [SerializeField]
    private GameObject [] incorrectAnswers;

    [SerializeField]
    private int numberOfCorrectAnswersSelected; 
    [SerializeField]
    private int numberOfIncorrectAnswersSelected;
    
    public void CheckAnswers()
    {
        // by default there are no answers selected
        numberOfCorrectAnswersSelected = 0;
        numberOfIncorrectAnswersSelected = 0;

        for(int i = 0; i < correctAnswers.Length; i++)
        {
            GameObject go = correctAnswers[i];
            if(go.GetComponent<CorrectAnswer>() != null)
            {
                // Debug.Log(go.transform.name + " has the CorrectAnswer script attached to it!!");
                CorrectAnswer correctAnswer = go.GetComponent<CorrectAnswer>();
                if(correctAnswer.correctAnswerSelected == true)
                {
                    numberOfCorrectAnswersSelected++;
                }
            }
        }
        for(int i = 0; i < incorrectAnswers.Length; i++)
        { 
            GameObject go = incorrectAnswers[i];
            if(go.GetComponent<IncorrectAnswer>() != null)
            {
                IncorrectAnswer incorrectAnswer = go.GetComponent<IncorrectAnswer>();
                if(incorrectAnswer.incorrectAnswerSelected == true)
                {
                    numberOfIncorrectAnswersSelected++;
                }
            }
        }
        Debug.Log("Number of correct answers selected: " + numberOfCorrectAnswersSelected);
        Debug.Log("Number of incorrect answers selected: " + numberOfIncorrectAnswersSelected);
    }
}
