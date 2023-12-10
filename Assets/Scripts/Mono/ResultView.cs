using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ResultView : MonoBehaviour
{
    [SerializeField] TMP_Text difficultyText;
    [SerializeField] TMP_Text numberOfOptionsText;
    [SerializeField] TMP_Text questionText;
    [SerializeField] TMP_Text correctAnswerText;
    [SerializeField] TMP_Text totalTimeText;
    [SerializeField] TMP_Text timePerQuestionText;
    [SerializeField] TMP_Text resultText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowResultPage(ResultData resultData)
    {
        difficultyText.SetText("Zorluk Seviyesi: " + resultData.Difficulty);
        numberOfOptionsText.SetText("Seçenek Sayısı: " + resultData.NumberOfOptions);
        questionText.SetText("Soru Sayısı: " + resultData.QuestionCount);
        correctAnswerText.SetText("Doğru Sayısı: " + resultData.CorrectAnswerCount);
        totalTimeText.SetText("Toplam Süre: " + resultData.Time.ToString("0.0") + " sn");
        timePerQuestionText.SetText("Soru Başına Geçen Süre: " + (resultData.Time/ resultData.QuestionCount).ToString("0.0") + " sn");
        resultText.SetText("%"+resultData.ResultPercentage.ToString());
        gameObject.SetActive(true);
    }
}
