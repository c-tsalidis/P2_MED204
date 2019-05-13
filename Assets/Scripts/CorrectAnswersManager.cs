using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use the Text class I need to use the UI from the UnityEngine

public class CorrectAnswersManager : MonoBehaviour
{
    // private variables
    // [SerializeField] is used so that the private variables of this script can be seen and modified directly in the Unity Editor
    [SerializeField]
    private GameObject [] correctAnswers; // correct answer buttons
    [SerializeField]
    private int correctAnswersCounter = 0; // this counter keeps track of every correct asnwer selected
    [SerializeField]
    private string efficiency_PlayerPrefs_Key; // the string used to save the efficiencies at
    [SerializeField]
    private int efficiency; // efficiency of each part of the ship after taking the quizz
    [SerializeField]
    private Text wrongAnswerText; // the text that shows the question numbers that were answered wrong
    [SerializeField]
    private int numberOfQuestionPanels = 4; // the amount of questions the quiz has (which is the same as the amount of panels)

    // this method is responsible for checking the correct answers or incorrect answers selected by the user, 
    // as well as showing the number of the question that was answered incorrectly so that the user can go back and give it another attempt,
    // as well as calculating the efficiency of the ship part this question option belongs to
    public void CheckAnswers()
    {
        // by default there are no correct answers selected
        correctAnswersCounter = 0;
        string wrongAnswerQuestionNumberText = "";
        // by default there are no wrong answers selected
        int wrongAnswersCounter = 0;
        for(int i = 0; i < correctAnswers.Length; i++) // this goes through all the correct answers buttons 
        {
            // if the button has the AnswerQuestionQuiz script attached to it
            if(correctAnswers[i].GetComponent<AnswerQuestionQuiz>() != null)
            {
                AnswerQuestionQuiz answerQuestionQuiz = correctAnswers[i].GetComponent<AnswerQuestionQuiz>();
                //  if the current button of the button is selected
                if(answerQuestionQuiz.correctAnswerIsSelected == true)
                {
                    // it means that the correct option has been selected by the user. Therefore, increase the correct answers counter by one
                    correctAnswersCounter++;
                }
                // else if the user didn't select the correct answer, it means the user has either selected a wrong answer or not selected anything
                else if(answerQuestionQuiz.correctAnswerIsSelected == false) // then the user chose the incorrect asnwer
                {
                    // therefore increase the wrong answers counter by one
                    wrongAnswersCounter++;
                    for(int j = 0; j < numberOfQuestionPanels; j++) // go through all the panel questions
                    {
                        // if the panel question number of this question option is the same as j it means that the wrong answer belongs to this question
                        if(answerQuestionQuiz.questionPanelNumber == j)
                        {
                            // add the question number to the string --> Panel number 0 has has the question number 1, that's why it's (j + 1)
                            wrongAnswerQuestionNumberText += (j + 1).ToString() + ", ";
                        }
                        // update the wrong answers text with the updated string with the question numbers
                        wrongAnswerText.text = "Svaret til spørgsmål " + wrongAnswerQuestionNumberText  + " er forkert";
                    }
                }
            }
        }
        // Debug.Log("Wrong answers counter: " + wrongAnswersCounter);
        if(wrongAnswersCounter == 0) // if there's no wrong answers
        {
            // hide the wrongAnswerText gameObject
            wrongAnswerText.gameObject.SetActive(false);
        }
        else // else if there are wrong answers
        {
            // show the wrongAnswerText gamObject
            wrongAnswerText.gameObject.SetActive(true);
        }

        // the efficiency = (amount of correct answers * 100 / the total amount of questions (which is the same as the number of correct answers, as there's only one correct answer per question))
        // example --> if the user selected three correct answers out of 4 questions --> efficiency = 3*100/4 = 75%
        float division = (100 * correctAnswersCounter) / correctAnswers.Length;
        efficiency = Mathf.RoundToInt(division);

        // save the efficiency amount to the device, by storing it int the player prefs efficiency string
        PlayerPrefs.SetInt(efficiency_PlayerPrefs_Key, efficiency);
    }
}
