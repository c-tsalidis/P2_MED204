using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectAnswer : MonoBehaviour
{
    public bool incorrectAnswerSelected = false;

    public void MarkIncorrectAnswerAsSelected()
    {
        if(gameObject.GetComponent<AnswerQuestionQuiz>() != null)
        {
            AnswerQuestionQuiz answerQuestionQuiz = gameObject.GetComponent<AnswerQuestionQuiz>();
            if(answerQuestionQuiz.isToggle == true)
            {
                if(answerQuestionQuiz.toggleText == true)
                {
                    incorrectAnswerSelected = true;
                }
                else
                {
                    incorrectAnswerSelected = false;
                }
            }
            else
            {
                incorrectAnswerSelected = true;
            }
        }
    }
}
