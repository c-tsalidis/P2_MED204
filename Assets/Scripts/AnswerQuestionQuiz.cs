﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerQuestionQuiz : MonoBehaviour
{
    [SerializeField]
    private string buttonText;
    [SerializeField]
    private Text answer;
    public bool isToggle;
    
    public bool toggleText;

    // [SerializeField]
    // private GameObject [] restOfAnswers;

    public bool isCorrectAnswer = false;

    public bool correctAnswerIsSelected = false;
    public bool isSelected;

    public void AnswerQuizQuestion()
    {
        answer.text = buttonText;
        isSelected = true;
        GameObject parent = gameObject.transform.parent.gameObject;
        if(isCorrectAnswer == true)
        {
            correctAnswerIsSelected = true;
        }
        // Debug.Log(parent.transform.childCount);
        if(parent.transform.childCount > 0)
        {
            for(int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                if(child.GetComponent<AnswerQuestionQuiz>() != null)
                {
                    AnswerQuestionQuiz answerQuestionQuiz = child.GetComponent<AnswerQuestionQuiz>();
                    if(answerQuestionQuiz.isCorrectAnswer == true && gameObject == child)
                    {
                        correctAnswerIsSelected = true;
                    }
                    if(child != gameObject)
                    {
                        Unselect(child);
                    }
                }
            }
        }
    }

    public void Unselect(GameObject gameObject)
    {
        AnswerQuestionQuiz answerQuestionQuiz = gameObject.GetComponent<AnswerQuestionQuiz>();
        if(isToggle == true)
        {
            answerQuestionQuiz.answer.text = "";
        }
        answerQuestionQuiz.isSelected = false;
        answerQuestionQuiz.correctAnswerIsSelected = false;
        Debug.Log("Unchecked: " + gameObject.name);
    }

}
