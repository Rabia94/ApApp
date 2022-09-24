using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField]QuestionView questionView;
    [SerializeField]QuestionModel questionModel;

    private void Awake()
    {
        SetWordData();
        questionView.ToggleWrongAnswerPanel(false);
        questionView.ToggleCorrectAnswerPanel(false);

    }

    [ContextMenu(nameof(SetWordData))]
    public void SetWordData()
    {
        questionView.SetCurrentQuestion(GetWordData(),OnWrongAnswer,OnCorrectAnswer);
    }

    public QuestionData GetWordData()
    {
        return questionModel.GetRandomQuestionData();
    }

    void OnWrongAnswer()
    {
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.SetActive(false);
        questionView.ToggleWrongAnswerPanel(true);
      //  await Task.Delay(1000);
        questionView.ToggleWrongAnswerPanel(false);

    }

    void OnCorrectAnswer()
    {
        questionView.ToggleCorrectAnswerPanel(true);
      //  await Task.Delay(1000);
        SetWordData();
        questionView.ToggleCorrectAnswerPanel(false);
    }
}