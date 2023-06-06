using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class QuestionModel 
{
    [SerializeField] WordList wordList;
    List<Word> words=>wordList.Words;
    public ResultData ResultData=new ResultData();



    public QuestionData GetRandomQuestionData()
    {
        var categoryWords = GetCategoryWords(QuestionSettings.Category);
        var word = categoryWords.GetRandomElement();


        switch (QuestionSettings.Difficulty)
        {
            case Difficulty.Kolay:
                return SetEasyQuestion(word);
            case Difficulty.Orta:
                return SetMediumQuestion(word);
            case Difficulty.Zor:
                return SetHardQuestion(word);
            case Difficulty.CokZor:
                return SetVeryHardQuestion(word);
            default:
                return null;
        }
    }

    QuestionData SetQuestionData(Word word)
    {
        var data = new QuestionData();
        data.CorrectWord = word;
        data.AllWords.Add(word);
        return data;
    }

    QuestionData SetEasyQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        var restCount = QuestionSettings.AnswerCount - data.AllWords.Count;
        for (int i = 0; i < restCount; i++)
        {
            data.AllWords.Add(GetDifferentCategoryWord(word.Category, data.AllWords));
        }
        return data;
    }



    QuestionData SetMediumQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        for (int i = 0; i < QuestionSettings.AnswerCount * .5f - 1; i++)
        {
            data.AllWords.Add(GetSameCategoryWord(word.Category, data.AllWords));
        }
        var restCount = QuestionSettings.AnswerCount - data.AllWords.Count;
        for (int i = 0; i < restCount; i++)
        {
            data.AllWords.Add(GetDifferentCategoryWord(word.Category, data.AllWords));
        }
        return data;
    }

    QuestionData SetHardQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        for (int i = 0; i < QuestionSettings.AnswerCount * .5f - 1; i++)
        {
            data.AllWords.Add(GetSameSubCategoryWord(word.Group, data.AllWords));
        }
        var restCount = QuestionSettings.AnswerCount - data.AllWords.Count;
        for (int i = 0; i < restCount; i++)
        {
            data.AllWords.Add(GetDifferentCategoryWord(word.Category, data.AllWords));
        }
        return data;
    }

    QuestionData SetVeryHardQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        for (int i = 0; i < (QuestionSettings.AnswerCount-1)*.5f ; i++)
        {
          data.AllWords.Add(GetSameCategoryWord(word.Category, data.AllWords));
        }
        var restCount = QuestionSettings.AnswerCount - data.AllWords.Count;
        for (int i = 0; i < restCount; i++)
        {
            data.AllWords.Add(GetSameSubCategoryWord(word.Group, data.AllWords));
        }
        return data;
    }

    Word GetSameSubCategoryWord(int group, List<Word> questionWords)
    {
        var categoryWords = GetGroupWords(group);
        var randomWord = categoryWords.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = categoryWords.GetRandomElement();
        }
        return randomWord;
    }

    Word GetSameCategoryWord(Category category, List<Word> questionWords)
    {
        var categoryWords = GetCategoryWords(category);
        var randomWord = categoryWords.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = categoryWords.GetRandomElement();
        }
        return randomWord;
    }

    Word GetDifferentSubCategoryWord(int group, List<Word> questionWords)
    {
        var categoryWords = words;
        var wordsToRemove = GetGroupWords(group);
        foreach (var word in wordsToRemove)
        {
            if (words.Contains(word))
                categoryWords.Remove(word);
        }
        var randomWord = categoryWords.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = categoryWords.GetRandomElement();
        }
        return randomWord;
    }

    Word GetDifferentCategoryWord(Category category, List<Word> questionWords)
    {
        var categoryWords = words;
        var wordsToRemove = GetCategoryWords(category);
        foreach (var word in wordsToRemove)
        {
            if (words.Contains(word))
                categoryWords.Remove(word);
        }
        var randomWord = categoryWords.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = categoryWords.GetRandomElement();
        }
        return randomWord;
    }

    public List<Word> GetCategoryWords(Category category)
    {
        List<Word> categoryWords = new List<Word>();
        categoryWords.AddRange(words.FindAll(w => w.Category == category));
        return categoryWords.Distinct().ToList();
    }
    
    public List<int> GetCategoryGroups(Category category)
    {
        List<int> groups = new List<int>();
        List<Word> categoryWords = GetCategoryWords(category);
        foreach (var word in categoryWords)
        {
            if (!groups.Contains(word.Group))
            {
                groups.Add(word.Group);
            }
        }

        return groups;
    }

    public List<Word> GetGroupWords(int group)
    {
        List<Word> categoryWords = new List<Word>();
        categoryWords.AddRange(words.FindAll(w => w.Group == group));
        return categoryWords.Distinct().ToList();
    }
}
