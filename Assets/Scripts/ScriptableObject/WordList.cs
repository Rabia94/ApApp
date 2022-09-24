using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ApApp/WordList")]
public class WordList : ScriptableObject
{
    [SerializeField] List<Word> words;

    public List<Word> Words { get
        {
            var result = new List<Word>();
            result.AddRange(words);
            return result;
        } }
}