using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswersManager : MonoBehaviour
{

    [SerializeField]
    private GameObject [] correctAnswers;
    [SerializeField]
    private int correctAnswersCounter = 0;

    /*
    [SerializeField]
    private GameObject [] incorrectAnswers;
    [SerializeField]
    private int numberOfCorrectAnswersSelected; 
    [SerializeField]
    private int numberOfIncorrectAnswersSelected;

    [SerializeField]
    private string numberOfCorrectAnswersSelected_PlayerPrefs_Key;
    [SerializeField]
    private string numberOfIncorrectAnswersSelected_PlayerPrefs_Key;
    */


    [SerializeField]
    private string efficiency_PlayerPrefs_Key;

    [SerializeField]
    private int efficiency;

    public void CheckAnswers()
    {
        // by default there are no answers selected
        // numberOfCorrectAnswersSelected = 0;
        correctAnswersCounter = 0;
        /*
        */
         for(int i = 0; i < correctAnswers.Length; i++)
        {
            if(correctAnswers[i].GetComponent<AnswerQuestionQuiz>() != null)
            {
                AnswerQuestionQuiz answerQuestionQuiz = correctAnswers[i].GetComponent<AnswerQuestionQuiz>();
                if(answerQuestionQuiz.correctAnswerIsSelected == true)
                {
                    correctAnswersCounter++;
                }
            }
        }

        /*
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
         */
        // Debug.Log("Number of correct answers selected: " + numberOfCorrectAnswersSelected);
        // Debug.Log("Number of incorrect answers selected: " + numberOfIncorrectAnswersSelected);

        // The key of PlayerPrefs go like this: 
        // "Number Of Correct Answers Hull", and so on 
        // "Number Of Incorrect Answers Hull", and so on 
        // PlayerPrefs.SetInt(numberOfCorrectAnswersSelected_PlayerPrefs_Key, numberOfCorrectAnswersSelected);
        // PlayerPrefs.SetInt(numberOfIncorrectAnswersSelected_PlayerPrefs_Key, numberOfIncorrectAnswersSelected);


        // float sum1 = (numberOfCorrectAnswersSelected - (numberOfIncorrectAnswersSelected / 1.50f));
        // float sum2 = (correctAnswers.Length + incorrectAnswers.Length);
        // float division = sum1 / sum2 * 100;
        float division = (100 * correctAnswersCounter) / correctAnswers.Length;

        /*
        Debug.Log(numberOfCorrectAnswersSelected);
        Debug.Log(numberOfIncorrectAnswersSelected / 2);
        Debug.Log(correctAnswers.Length);
        Debug.Log(incorrectAnswers.Length);
        Debug.Log(numberOfCorrectAnswersSelected -(numberOfIncorrectAnswersSelected/2));
        Debug.Log(correctAnswers.Length + incorrectAnswers.Length);
        Debug.Log(sum1);
        Debug.Log(sum2);
        Debug.Log(sum1 / sum2);
         */
        efficiency = Mathf.RoundToInt(division);

        PlayerPrefs.SetInt(efficiency_PlayerPrefs_Key, efficiency);
    }
}
