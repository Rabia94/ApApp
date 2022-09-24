using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class QuestionModel 
{
    [SerializeField] WordList wordList;
    List<Word> words=>wordList.Words;


   
    
    public QuestionData GetRandomQuestionData()
    {
        var categoryWords = GetCategoryWords(QuestionSettings.Category);
        var word = categoryWords.GetRandomElement();

        switch (QuestionSettings.Difficulty)
        {
            case Difficulty.Easy:
                return SetEasyQuestion(word);
            case Difficulty.Medium:
                return SetMediumQuestion(word);
            case Difficulty.Hard:
                return SetHardQuestion(word);
            case Difficulty.VeryHard:
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
        for (int i = 0; i < QuestionSettings.AnswerCount - 1; i++)
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
        for (int i = 0; i < QuestionSettings.AnswerCount * .5f - 1; i++)
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
            data.AllWords.Add(GetSameSubCategoryWord(word.SubCategory, data.AllWords));
        }
        for (int i = 0; i < QuestionSettings.AnswerCount * .5f - 1; i++)
        {
            data.AllWords.Add(GetDifferentCategoryWord(word.Category, data.AllWords));
        }
        return data;
    }

    QuestionData SetVeryHardQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        for (int i = 0; i < QuestionSettings.AnswerCount*.5f - 1; i++)
        {
          data.AllWords.Add(GetSameCategoryWord(word.Category, data.AllWords));
        }
        for (int i = 0; i < QuestionSettings.AnswerCount * .5f - 1; i++)
        {
            data.AllWords.Add(GetSameSubCategoryWord(word.SubCategory, data.AllWords));
        }
        return data;
    }

    Word GetSameSubCategoryWord(SubCategory subCategory, List<Word> questionWords)
    {
        var categoryWords = GetSubCategoryWords(subCategory);
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

    Word GetDifferentSubCategoryWord(SubCategory subCategory, List<Word> questionWords)
    {
        var categoryWords = words;
        var wordsToRemove = GetSubCategoryWords(subCategory);
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

    public List<Word> GetSubCategoryWords(SubCategory subCategory)
    {
        List<Word> categoryWords = new List<Word>();
        categoryWords.AddRange(words.FindAll(w => w.SubCategory == subCategory));
        return categoryWords.Distinct().ToList();
    }
}