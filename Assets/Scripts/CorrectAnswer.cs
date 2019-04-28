using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public bool correctAnswerSelected = false;
    
    [SerializeField]
    private GameObject [] nonToggleIncorrectAnswers;

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
            else // if it's not a toggable question --> (single option questions)
            {
                correctAnswerSelected = true;  
                if(nonToggleIncorrectAnswers != null)
                {
                    for(int i = 0; i < nonToggleIncorrectAnswers.Length; i++)
                    {
                        if(nonToggleIncorrectAnswers[i].GetComponent<IncorrectAnswer>() != null)
                        {
                            IncorrectAnswer incorrectAnswer = nonToggleIncorrectAnswers[i].GetComponent<IncorrectAnswer>();
                            incorrectAnswer.Unselect();
                            /*
                            int incorrectAnswersCounter = 0;
                            if(incorrectAnswer.incorrectAnswerSelected == true)
                            {
                                incorrectAnswersCounter++;
                                correctAnswerSelected = false;
                            }
                            if(incorrectAnswersCounter == 0) // if no incorrect answers are selected
                            {
                                correctAnswerSelected = true;
                            }       
                             */
                        }
                    }
                }
            }
        }
    }

    public void Unselect()
    {
        correctAnswerSelected = false;
    }

}
