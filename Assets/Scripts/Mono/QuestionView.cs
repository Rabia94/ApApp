using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionView : MonoBehaviour
{
    [SerializeField] Transform wordHolder;
    [SerializeField] WordOptionView wordPrefab;


    public void SetCurrentQuestion(QuestionData questionData)
    {
        var count = wordHolder.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(wordHolder.GetChild(i).gameObject);
        }

        for (int i = 0; i < QuestionSettings.AnswerCount; i++)
        {
            Instantiate(wordPrefab, wordHolder).SetWord(questionData.AllWords[i]);
        }
    }


}
