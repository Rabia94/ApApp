using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using VInspector;

public class ResultView : MonoBehaviour
{
    [SerializeField] TMP_Text difficultyText;
    [SerializeField] TMP_Text numberOfOptionsText;
    [SerializeField] TMP_Text questionText;
    [SerializeField] TMP_Text correctAnswerText;
    [SerializeField] TMP_Text totalTimeText;
    [SerializeField] TMP_Text timePerQuestionText;
    [SerializeField] TMP_Text resultText;
    [SerializeField] private Survey survey;

    private ResultData result= new ResultData();
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowResultPage(ResultData resultData)
    {
        result = resultData;
        difficultyText.SetText("Zorluk Seviyesi: " + resultData.Difficulty);
        numberOfOptionsText.SetText("Seçenek Sayısı: " + resultData.NumberOfOptions);
        questionText.SetText("Soru Sayısı: " + resultData.QuestionCount);
        correctAnswerText.SetText("Doğru Sayısı: " + resultData.CorrectAnswerCount);
        totalTimeText.SetText("Toplam Süre: " + resultData.Time.ToString("0.0") + " sn");
        timePerQuestionText.SetText("Soru Başına Geçen Süre: " + resultData.TimePerQuestion.ToString("0.0") + " sn");
        resultText.SetText("%"+resultData.ResultPercentage);
        gameObject.SetActive(true);
        SendSurveyData();
    }

    [Button]
    private void SendSurveyData()
    {
        survey.Send(survey.GetFormResultDictionary(result));
    }

   

}
