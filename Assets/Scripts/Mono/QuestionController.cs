using System.Collections.Generic;
using System.Threading.Tasks;
using NonMono;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    private int currentQuestionIndex { get; set; } = 1;
    private float startTime;
    private List<Word> subCategoryWords;
    private Dictionary<Word, int> wordCountDictionary=new();

    float currentWordAudioCalledTime;
    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        Invoke(nameof(SetWordData), 1);
    }

    private void Initialize()
    {
        HideClue();
        subCategoryWords = questionModel.GetCategoryGroupWords(QuestionSettings.Data.Category,QuestionSettings.Data.GroupIndex);
        foreach (var word in subCategoryWords)
        {
            wordCountDictionary.Add(word,0);
        }
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

    public void SetWordData()
    {
        currentWordAudioCalledTime = 0;
        currentData = GetWordData();
        currentData.QuestionIndex = currentQuestionIndex;
        questionView.SetCurrentQuestion(currentData, OnWrongAnswer,OnCorrectAnswer);
        PlayCurrentWordAudio();
        clueText.SetText(currentData.CorrectWord.Label);
        HideClue();
        questionView.SetConstraint(GridLayoutGroup.Constraint.FixedRowCount);
    }

    private QuestionData GetWordData()
    {
        List<Word> availableWords = new();
        foreach (var wordCountPair in wordCountDictionary)
        {
            if (wordCountPair.Value < QuestionSettings.Data.WordRepeatCount)
            {
                availableWords.Add(wordCountPair.Key);
            }
        }

        Word word = availableWords[Random.Range(0, availableWords.Count)];

        QuestionData data= questionModel.GetRandomQuestionData(word);
        wordCountDictionary[word] += 1;
        
        
        data.AllWords = data.AllWords.RandomizeList();
        return data;
    }

    async void OnWrongAnswer()
    {
        if (currentQuestionIndex > questionModel.ResultData.WrongAnswerCount + questionModel.ResultData.CorrectAnswerCount)
            questionModel.ResultData.WrongAnswerCount++;
        Destroy(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
        audioSource.PlayOneShot(wrongAudioClip);
        await Task.Delay(5);
        if (questionView.LeftAnswerCount <= 2)
        {
            questionView.IncreaseCellSize();
            questionView.SetConstraint(GridLayoutGroup.Constraint.FixedColumnCount);
        }
        else
        {
            questionView.SetConstraint(GridLayoutGroup.Constraint.FixedRowCount);
        }
        if (questionView.LeftAnswerCount == 1)
        {
            questionView.MakeNotInteractableLastAnswer();
            ShowClue();
            await Task.Delay(2000);
            currentQuestionIndex++;
            SetWordData();
        }
        else
        {
            PlayCurrentWordAudio();
        }
        await Task.Delay(500);

    }

    async void OnCorrectAnswer()
    {
        audioSource.PlayOneShot(correctAudioClip);
        await Task.Delay(1500);
        if (currentQuestionIndex > questionModel.ResultData.WrongAnswerCount + questionModel.ResultData.CorrectAnswerCount)
        {
            questionModel.ResultData.CorrectAnswerCount++;
        }
        
        currentQuestionIndex++;

        if (currentQuestionIndex<=QuestionSettings.Data.QuestionCount)
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
        float lastCalledInterval = Time.time - currentWordAudioCalledTime;
        if (lastCalledInterval < 1)
        {
            Debug.Log($"Audio called multiple time. Last called {lastCalledInterval} seconds ago");
            return;
        }
        audioSource.PlayOneShot(currentData.CorrectWord.Audio,1);
        currentWordAudioCalledTime = Time.time;
    }

    void ShowResultPage()
    {
        questionView.ShowResultPage(questionModel.ResultData);
        int score = (int)(questionModel.ResultData.CorrectAnswerCount * 100f / QuestionSettings.Data.QuestionCount);
        int highestValue = SaveManager.GetCategoryResult(QuestionSettings.Data.Category, QuestionSettings.Data.GroupIndex);
        if (score > highestValue)
        {
            SaveManager.SaveCategoryResult(QuestionSettings.Data.Category, QuestionSettings.Data.GroupIndex,score);
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