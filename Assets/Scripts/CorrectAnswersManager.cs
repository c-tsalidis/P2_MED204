using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectAnswersManager : MonoBehaviour
{

    [SerializeField]
    private GameObject [] correctAnswers;
    [SerializeField]
    private int correctAnswersCounter = 0;

    [SerializeField]
    private string efficiency_PlayerPrefs_Key;

    [SerializeField]
    private int efficiency;

    [SerializeField]
    private Text wrongAnswerText;

    [SerializeField]
    private int numberOfQuestionPanels = 4;

    public void CheckAnswers()
    {
        // by default there are no answers selected
        correctAnswersCounter = 0;

        string wrongAnswerQuestionNumberText = "";
        int wrongAnswersCounter = 0;
        for(int i = 0; i < correctAnswers.Length; i++)
        {
            if(correctAnswers[i].GetComponent<AnswerQuestionQuiz>() != null)
            {
                AnswerQuestionQuiz answerQuestionQuiz = correctAnswers[i].GetComponent<AnswerQuestionQuiz>();
                if(answerQuestionQuiz.correctAnswerIsSelected == true)
                {
                    correctAnswersCounter++;
                }
                else if(answerQuestionQuiz.correctAnswerIsSelected == false) // then the user chose the incorrect asnwer
                {
                    wrongAnswersCounter++;
                    for(int j = 0; j < numberOfQuestionPanels; j++)
                    {
                        if(answerQuestionQuiz.questionPanelNumber == j)
                        {
                            wrongAnswerQuestionNumberText += (j + 1).ToString() + ", ";
                        }
                        wrongAnswerText.text = "Svaret til spørgsmål " + wrongAnswerQuestionNumberText  + " er forkert";
                    }
                }
            }
        }
        Debug.Log("Wrong answers counter: " + wrongAnswersCounter);
        if(wrongAnswersCounter == 0) // if there's no wrong answers
        {
            wrongAnswerText.gameObject.SetActive(false);
        }
        else
        {
            wrongAnswerText.gameObject.SetActive(true);
        }

        
        float division = (100 * correctAnswersCounter) / correctAnswers.Length;

        efficiency = Mathf.RoundToInt(division);

        PlayerPrefs.SetInt(efficiency_PlayerPrefs_Key, efficiency);
    }
}
