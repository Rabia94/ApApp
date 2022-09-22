using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class QuestionModel 
{
    [SerializeField]WordList wordList;

    public QuestionData GetRandomQuestionData()
    {
        var word = wordList.GetCategoryWords(QuestionSettings.Category).GetRandomElement();

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

        }
        return data;
    }



    QuestionData SetMediumQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        for (int i = 0; i < QuestionSettings.AnswerCount - 1; i++)
        {

        }
        return data;
    }

    QuestionData SetHardQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        for (int i = 0; i < QuestionSettings.AnswerCount - 1; i++)
        {

        }
        return data;
    }

    QuestionData SetVeryHardQuestion(Word word)
    {
        QuestionData data = SetQuestionData(word);
        for (int i = 0; i < QuestionSettings.AnswerCount*.5f - 1; i++)
        {
            GetSameCategoryWord(word.Category, data.AllWords);
        }
        for (int i = 0; i < QuestionSettings.AnswerCount * .5f - 1; i++)
        {
            GetSameSubCategoryWord(word.SubCategory, data.AllWords);
        }
        return data;
    }

    Word GetSameSubCategoryWord(SubCategory subCategory, List<Word> questionWords)
    {
        var words = wordList.GetSubCategoryWords(subCategory);
        var randomWord = words.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = words.GetRandomElement();
        }
        return randomWord;
    }

    Word GetSameCategoryWord(Category category, List<Word> questionWords)
    {
        var words = wordList.GetCategoryWords(category);
        var randomWord = words.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = words.GetRandomElement();
        }
        return randomWord;
    }

    Word GetDifferentSubCategoryWord(SubCategory subCategory, List<Word> questionWords)
    {
        var words = wordList.Words;
        var wordsToRemove = wordList.GetSubCategoryWords(subCategory);
        foreach (var word in wordsToRemove)
        {
            if (words.Contains(word))
                words.Remove(word);
        }
        var randomWord = words.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = words.GetRandomElement();
        }
        return randomWord;
    }

    Word GetDifferentCategoryWord(Category category, List<Word> questionWords)
    {
        var words = wordList.Words;
        var wordsToRemove = wordList.GetCategoryWords(category);
        foreach (var word in wordsToRemove)
        {
            if (words.Contains(word))
                words.Remove(word);
        }
        var randomWord = words.GetRandomElement();

        while (questionWords.Contains(randomWord))
        {
            randomWord = words.GetRandomElement();
        }
        return randomWord;
    }
}