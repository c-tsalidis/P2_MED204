using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerQuestionQuiz : MonoBehaviour
{
    // private variables
    // private variables have the [SerializeField] so as to be able to modify them and/or see them directly in the Unity Editor
   [SerializeField]
    private string buttonText;
    [SerializeField]
    private Text answer;

    // public variables
    public bool isToggle; // to check if it's a toggable answer
    public bool toggleText; // to check is the text is toggled or not
    public bool isCorrectAnswer = false; // to check if this gameobject is the correct answer to the question
    public bool correctAnswerIsSelected = false; // to check if the correct answer is selected
    public bool incorrectAnswerIsSelected = false; // to check if the incorrect answer is selected
    public bool isSelected; // to check if this gameobject has been selected
    public int questionPanelNumber; // the question panel number this gameobject belongs to

    // this method is called every time the user clicks on the button gamobject this script is attached to
    public void AnswerQuizQuestion()
    {
        answer.text = buttonText; // the answer text is the same as the answer of this button's text
        isSelected = true; // mark this choice as selected 
        GameObject parent = gameObject.transform.parent.gameObject; // get the parent object of this gameobject to get all the choices of the question this choice belongs to
        if(isCorrectAnswer == true) // if this button is the correct option
        {
            // then it means that the correct answer has been selected
            correctAnswerIsSelected = true;
        }
        // Debug.Log(parent.transform.childCount);
        // if the parent object has more than 0 children then it means that there is at least one option to answer to in this question
        if(parent.transform.childCount > 0)
        {
            // goes through all the children of the parent --> all the options of the question
            for(int i = 0; i < parent.transform.childCount; i++)
            {
                // get the child of the parent number i
                GameObject child = parent.transform.GetChild(i).gameObject;
                // if the child object has the AnswerQuestionQuiz script attached to it
                if(child.GetComponent<AnswerQuestionQuiz>() != null)
                {
                    AnswerQuestionQuiz answerQuestionQuiz = child.GetComponent<AnswerQuestionQuiz>();
                    // if this current choice is the correct answer and this gameobject is the same as the child
                    if(answerQuestionQuiz.isCorrectAnswer == true && gameObject == child)
                    {
                        // the correct answer has been selected by the user
                        correctAnswerIsSelected = true;
                    }
                    // if the  correct answer hasn't been selected by the user and the gameobject this script is attached to is the same as the child gamerobject
                    if(answerQuestionQuiz.isCorrectAnswer == false && gameObject == child)
                    {
                        // then the user selected wrong answer
                        incorrectAnswerIsSelected = true;
                    }
                    // if the child is not the same as the gameobject this script is attached to
                    // then it means that the child gameobject is an option that the user wants to unselect
                    if(child != gameObject)
                    {
                        // unselect the option that the user doesn't select
                        Unselect(child);
                    }
                }
            }
        }
    }

    // Unchecking the options as selected
    public void Unselect(GameObject gameObject)
    {
        // get the script of the option
        AnswerQuestionQuiz answerQuestionQuiz = gameObject.GetComponent<AnswerQuestionQuiz>();
        // if it's a toggle option
        if(isToggle == true)
        {
            // set the text to an empty string
            answerQuestionQuiz.answer.text = "";
        }
        // mark option as not selected
        answerQuestionQuiz.isSelected = false;
        // mark correct answer as not selected
        answerQuestionQuiz.correctAnswerIsSelected = false;
        // mark incorrect answer as not selected
        answerQuestionQuiz.incorrectAnswerIsSelected = false;
        // Debug.Log("Unchecked: " + gameObject.name);
    }

}