using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerQuestion : MonoBehaviour
{
    [SerializeField]
    private string buttonText;
    [SerializeField]
    private Text answer;

    public void AnswerQuizQuestion()
    {
        answer.text = buttonText;
    }
}
