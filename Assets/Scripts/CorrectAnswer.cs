using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public bool correctAnswerSelected = false;

    public void MarkCorrectAnswerAsSelected()
    {
        
        if(gameObject.GetComponent<AnswerQuestionQuiz>() != null)
        {
            AnswerQuestionQuiz answerQuestionQuiz = gameObject.GetComponent<AnswerQuestionQuiz>();
            if(answerQuestionQuiz.isToggle == true)
            {
                if(answerQuestionQuiz.toggleText == true)
                {
                    correctAnswerSelected = true;
                }
                else
                {
                    correctAnswerSelected = false;
                }
            }
            else
            {
                correctAnswerSelected = true;
            }
        }
    }

}
