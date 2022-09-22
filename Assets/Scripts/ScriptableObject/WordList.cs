using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ApApp/WordList")]
public class WordList : ScriptableObject
{
    public List<Word> Words = new List<Word>();


    public List<Word> GetCategoryWords(Category category)
    {
        List<Word> words = new List<Word>();
        words.AddRange(Words.FindAll(w => w.Category == category));
        return words.Distinct().ToList();
    }

    public List<Word> GetSubCategoryWords(SubCategory subCategory)
    {
        List<Word> words = new List<Word>();
        words.AddRange(Words.FindAll(w => w.SubCategory == subCategory));
        return words.Distinct().ToList();
    }



}