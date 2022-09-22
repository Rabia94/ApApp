using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class QuestionModel 
{
    [SerializeField]WordList wordList;

    public QuestionData GetRandomQuestionData()
    {
        var words = wordList.GetWords(QuestionSettings.Categories);
        var data = new QuestionData();
        data.CorrectWord = words.GetRandomElement();
        data.AllWords.Add(data.CorrectWord);
        if(words.Count< QuestionSettings.AnswerCount)
        {
            return null;
        }

        for (int i = 0; i < QuestionSettings.AnswerCount-1; i++)
        {
            var randomWord = words.GetRandomElement();
            while (data.AllWords.Contains(randomWord))
            {
                randomWord = words.GetRandomElement();
            }
            data.AllWords.Add(randomWord);
        }
        return data;
    }
}