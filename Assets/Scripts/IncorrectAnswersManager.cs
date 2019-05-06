using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectAnswersManager : MonoBehaviour
{
    [SerializeField]
    private GameObject [] incorrectAnswers;
    [SerializeField]
    private int incorrectAnswersCounter = 0;

    public void CheckAnswers()
    {
        // by default there are no answers selected
        // numberOfCorrectAnswersSelected = 0;
        incorrectAnswersCounter = 0;
         for(int i = 0; i < incorrectAnswers.Length; i++)
        {
            if(incorrectAnswers[i].GetComponent<AnswerQuestionQuiz>() != null)
            {
                AnswerQuestionQuiz answerQuestionQuiz = incorrectAnswers[i].GetComponent<AnswerQuestionQuiz>();
                if(answerQuestionQuiz.correctAnswerIsSelected == true)
                {
                    incorrectAnswersCounter++;
                }
                else if(answerQuestionQuiz.correctAnswerIsSelected == false)
                {
                    incorrectAnswersCounter++;
                }
            }
        }
    }
}
