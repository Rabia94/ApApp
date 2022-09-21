using System;
using UnityEngine;

[Serializable]
public class QuestionModel 
{
    [SerializeField]WordList wordList;
    public CategoryGroup[] LevelCategories;

    public Word GetRandomLevelWord(int level)
    {
        var words = wordList.GetWords(LevelCategories[Math.Clamp(level - 1, 0, LevelCategories.Length - 1)]);
        return words.GetRandomElement();
    }
}