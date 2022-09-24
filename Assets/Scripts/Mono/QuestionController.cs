using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField]QuestionView questionView;
    [SerializeField]QuestionModel questionModel;

    private void Awake()
    {
        SetWordData();
    }

    [ContextMenu(nameof(SetWordData))]
    public void SetWordData()
    {
        questionView.SetCurrentQuestion(GetWordData());
    }

    public QuestionData GetWordData()
    {
        return questionModel.GetRandomQuestionData();
    }

}