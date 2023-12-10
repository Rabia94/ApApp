using System.Threading.Tasks;
using NonMono;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    [SerializeField] QuestionView questionView;
    [SerializeField] QuestionModel questionModel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip wrongAudioClip;
    [SerializeField] private AudioClip correctAudioClip;
    [SerializeField] private TMP_Text clueText;
    [SerializeField]Button clueButton;

    [SerializeField] QuestionData currentData;
    int currentQuestionIndex = 1;
    private float startTime;

    private void Awake()
    {
        Invoke(nameof(SetWordData), 1);
        startTime = Time.time + 1;
    }

    private void OnEnable()
    {
        clueButton.onClick.AddListener(ShowClue);
    }

    private void OnDisable()
    {
        clueButton.onClick.RemoveListener(ShowClue);
    }

    [ContextMenu(nameof(SetWordData))]
    public void SetWordData()
    {
        currentData = GetWordData();
        currentData.QuestionIndex = currentQuestionIndex;
        questionView.SetCurrentQuestion(currentData, OnWrongAnswer,OnCorrectAnswer);
        PlayCurrentWordAudio();
        clueText.SetText(currentData.CorrectWord.Label);
        HideClue();
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
        audioSource.PlayOneShot(wrongAudioClip);
        if (questionView.LeftAnswerCount <= 2)
        {
            questionView.IncreaseCellSize();
        }
        if (questionView.LeftAnswerCount == 1)
        {
            questionView.MakeNotInteractableLastAnswer();
            await Task.Delay(500);
            ShowClue();
        }
        PlayCurrentWordAudio();
        await Task.Delay(1000);
        Debug.Log(questionView.LeftAnswerCount);
        if (questionView.LeftAnswerCount == 1)
        {
            SetWordData();
        }
    }

    async void OnCorrectAnswer()
    {
        audioSource.PlayOneShot(correctAudioClip);
        await Task.Delay(1500);
        if (currentQuestionIndex > questionModel.ResultData.WrongAnswerCount + questionModel.ResultData.CorrectAnswerCount)
            questionModel.ResultData.CorrectAnswerCount++;
        currentQuestionIndex++;

        if (currentQuestionIndex<=QuestionSettings.QuestionCount)
        {
            SetWordData();
        }
        else
        {
            questionModel.ResultData.Time = Time.time-startTime;
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
        int score = (int)(questionModel.ResultData.CorrectAnswerCount * 100f / QuestionSettings.QuestionCount);
        int highestValue = SaveManager.GetCategoryResult(QuestionSettings.Category, QuestionSettings.GroupIndex);
        if (score > highestValue)
        {
            SaveManager.SaveCategoryResult(QuestionSettings.Category, QuestionSettings.GroupIndex,score);
        }
    }

    void ShowClue()
    {
        PlayCurrentWordAudio();
        clueText.enabled=true;
    }
    void HideClue()
    {
        clueText.enabled=false;
    }
}