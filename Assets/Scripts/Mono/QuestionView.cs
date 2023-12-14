using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionView : MonoBehaviour
{
    [SerializeField] GridLayoutGroup wordHolder;
    [SerializeField] WordOptionView wordPrefab;
    [SerializeField] TMP_Text questionText;
    [SerializeField] ResultView resultPanel;
    [SerializeField] private float cellSizeMultiplier = 1.75f;

    public int LeftAnswerCount => wordHolder.transform.childCount;
    private Vector2 defaultCellSize;
    private void Awake()
    {
        defaultCellSize = wordHolder.cellSize;
        questionText.text = 1 + "/" + QuestionSettings.QuestionCount;
    }

    public void SetCurrentQuestion(QuestionData questionData,UnityAction onWrongAnswer, UnityAction onCorrectAnswer)
    {
        wordHolder.cellSize = defaultCellSize;
        questionText.text = questionData.QuestionIndex + "/" + QuestionSettings.QuestionCount;
        var count = wordHolder.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(wordHolder.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < QuestionSettings.NumberOfOptions; i++)
        {
            if (questionData.AllWords.Count-1 < i)
            {
                return;
            }
            var word = questionData.AllWords[i];
            if (word == questionData.CorrectWord)
            {
                Debug.Log("Correct Word");
                Instantiate(wordPrefab, wordHolder.transform).SetWord(questionData.AllWords[i], onCorrectAnswer);
            }
            else
            {
                Debug.Log("Wrong Word");
                Instantiate(wordPrefab, wordHolder.transform).SetWord(questionData.AllWords[i], onWrongAnswer);
            }
            Debug.Log("Word: " + word.Label + " Category: " + word.Category + " SubCategory: " + word.Group);
        }
    }

    public void MakeNotInteractableLastAnswer()
    {
        wordHolder.transform.GetChild(0).GetComponent<Button>().interactable = false;
    }
    
    
    public void ShowResultPage(ResultData resultData)
    {
        resultPanel.ShowResultPage(resultData);
    }

    public void IncreaseCellSize()
    {
        wordHolder.cellSize *= cellSizeMultiplier;
    }
    
    public void SetConstraint(GridLayoutGroup.Constraint constraint)
    {
        wordHolder.constraint = constraint;
    }
}