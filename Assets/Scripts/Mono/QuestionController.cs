using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField] QuestionView questionView;
    [SerializeField] QuestionModel questionModel;
    [SerializeField] AudioSource audioSource;

    QuestionData currentData;
    int currentQuestionIndex = 1;

    private void Awake()
    {
        SetWordData();
        questionView.ToggleWrongAnswerPanel(false);
        questionView.ToggleCorrectAnswerPanel(false);

    }

    [ContextMenu(nameof(SetWordData))]
    public void SetWordData()
    {
        currentData = GetWordData();
        currentData.QuestionIndex = currentQuestionIndex;
        questionView.SetCurrentQuestion(currentData, OnWrongAnswer,OnCorrectAnswer);
        PlayCurrentWordAudio();

    }

    public QuestionData GetWordData()
    {
        return questionModel.GetRandomQuestionData();
    }

    async void OnWrongAnswer()
    {
        if (currentQuestionIndex > questionModel.ResultData.WrongAnswerCount + questionModel.ResultData.CorrectAnswerCount)
            questionModel.ResultData.WrongAnswerCount++;
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.SetActive(false);
        questionView.ToggleWrongAnswerPanel(true);
        await Task.Delay(300);
        PlayCurrentWordAudio();
        await Task.Delay(1000);
        questionView.ToggleWrongAnswerPanel(false);
    }

    async void OnCorrectAnswer()
    {
        questionView.ToggleCorrectAnswerPanel(true);
        await Task.Delay(1000);
        if (currentQuestionIndex > questionModel.ResultData.WrongAnswerCount + questionModel.ResultData.CorrectAnswerCount)
            questionModel.ResultData.CorrectAnswerCount++;
        currentQuestionIndex++;
        questionView.ToggleCorrectAnswerPanel(false);

        if (currentQuestionIndex<=QuestionSettings.QuestionCount)
        {
            SetWordData();
        }
        else
        {
            ShowResultPage();
        }   
    }

    public void PlayCurrentWordAudio()
    {
        audioSource.PlayOneShot(currentData.CorrectWord.Audio);
    }

    void ShowResultPage()
    {
        questionView.ShowResultPage(questionModel.ResultData);
    }


}