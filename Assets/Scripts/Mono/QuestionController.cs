using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        Invoke(nameof(SetWordData), 1);
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
        QuestionData data= questionModel.GetRandomQuestionData();
        data.AllWords = data.AllWords.RandomizeList();
        return data;
    }

    async void OnWrongAnswer()
    {
        if (currentQuestionIndex > questionModel.ResultData.WrongAnswerCount + questionModel.ResultData.CorrectAnswerCount)
            questionModel.ResultData.WrongAnswerCount++;
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.SetActive(false);
        questionView.ToggleWrongAnswerPanel(true);
        await Task.Delay(1000);
        questionView.ToggleWrongAnswerPanel(false);
        PlayCurrentWordAudio();

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
            questionModel.ResultData.Time = Time.time;
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