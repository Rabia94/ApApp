using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionView : MonoBehaviour
{
    [SerializeField] Transform wordHolder;
    [SerializeField] WordOptionView wordPrefab;
    [SerializeField] TMP_Text questionText;
    [SerializeField] GameObject wrongPanel;
    [SerializeField] GameObject correctPanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] TMP_Text resultText;


    public void SetCurrentQuestion(QuestionData questionData,UnityAction onWrongAnswer, UnityAction onCorrectAnswer)
    {
        questionText.text = questionData.QuestionIndex + "/" + QuestionSettings.QuestionCount;
        var count = wordHolder.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(wordHolder.GetChild(i).gameObject);
        }

        for (int i = 0; i < QuestionSettings.AnswerCount; i++)
        {
            var word = questionData.AllWords[i];
            if (word == questionData.CorrectWord)
            {
                Debug.Log("Correct Word");
                Instantiate(wordPrefab, wordHolder).SetWord(questionData.AllWords[i], onCorrectAnswer);
            }
            else
            {
                Debug.Log("Wrong Word");
                Instantiate(wordPrefab, wordHolder).SetWord(questionData.AllWords[i], onWrongAnswer);
            }
            Debug.Log("Word: " + word.Label + " Category: " + word.Category + " SubCategory: " + word.SubCategory);
        }
    }

    public void ToggleWrongAnswerPanel(bool value)
    {
        wrongPanel.SetActive(value);
    }


    public void ToggleCorrectAnswerPanel(bool value)
    {
        correctPanel.SetActive(value);
    }

    public void ShowResultPage(ResultData resultData)
    {
        resultPanel.SetActive(true);
        resultText.text = "Doğru Cevap: " + resultData.CorrectAnswerCount + " Yanlış Cevap: " + resultData.WrongAnswerCount
            + " Başlangıç Saati: " + resultData.StartedTime + " Bitiş Saati: " + resultData.EndedTime;
    }
}