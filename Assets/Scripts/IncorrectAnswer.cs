using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectAnswer : MonoBehaviour
{
    public bool incorrectAnswerSelected = false;
    [SerializeField]
    private GameObject nonToggleCorrectAnswer;
    [SerializeField]
    private GameObject [] nonToggleIncorrectAnswers;

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
            else // if it's a non toggle question
            {
                incorrectAnswerSelected = true;
                if(nonToggleCorrectAnswer != null && nonToggleIncorrectAnswers != null)
                {
                    if(nonToggleCorrectAnswer.GetComponent<CorrectAnswer>() != null)
                    {
                        CorrectAnswer correctAnswer = nonToggleCorrectAnswer.GetComponent<CorrectAnswer>();
                        correctAnswer.Unselect();
                        /*
                        if(correctAnswer.correctAnswerSelected == true)
                        {
                            incorrectAnswerSelected = false;
                        }
                         */
                        foreach (GameObject nonToggleIncorrectAnswer in nonToggleIncorrectAnswers)
                        {
                            if( nonToggleIncorrectAnswer.GetComponent<IncorrectAnswer>() != null)
                            {
                                IncorrectAnswer incorrectAnswer = nonToggleIncorrectAnswer.GetComponent<IncorrectAnswer>();
                                incorrectAnswer.Unselect();
                                /*
                                int incorrectAnswerCounter = 0;
                                if(incorrectAnswer.incorrectAnswerSelected == true)
                                {
                                    incorrectAnswerCounter++;
                                }
                                if(incorrectAnswerCounter == 0)
                                {
                                    incorrectAnswerSelected = true;
                                }
                                else
                                {
                                    incorrectAnswerSelected = false;
                                }
                                 */
                            }
                        }
                    }
                }
            }
        }
    }

    public void Unselect()
    {
        incorrectAnswerSelected = false;
    }
}
