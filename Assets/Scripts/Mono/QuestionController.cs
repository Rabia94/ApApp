using System.Threading.Tasks;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField] QuestionView questionView;
    [SerializeField] QuestionModel questionModel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip wrongAudioClip;
    [SerializeField] private AudioClip correctAudioClip;
    
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
        Destroy(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
        questionView.ToggleWrongAnswerPanel(true);
        audioSource.PlayOneShot(wrongAudioClip);
        await Task.Delay(1000);
        questionView.ToggleWrongAnswerPanel(false);
        PlayCurrentWordAudio();
        Debug.Log(questionView.LeftAnswerCount);
        if (questionView.LeftAnswerCount <= 2)
        {
            questionView.IncreaseCellSize();
        }
    }

    async void OnCorrectAnswer()
    {
        questionView.ToggleCorrectAnswerPanel(true);
        audioSource.PlayOneShot(correctAudioClip);
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