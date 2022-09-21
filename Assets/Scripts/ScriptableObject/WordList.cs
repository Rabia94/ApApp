using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ApApp/WordList")]
public class WordList : ScriptableObject
{
    public List<Word> Words = new List<Word>();

    public List<Word> GetWords(CategoryGroup categories)
    {
        List<Word> words = new List<Word>();
        foreach (var category in categories.Categories)
        {
            words.AddRange(Words.FindAll(w => w.Category == category));
        }
        return words.Distinct().ToList();
    }
}