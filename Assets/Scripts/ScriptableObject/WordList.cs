using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VInspector;

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

#if UNITY_EDITOR

    [Button]
    public void SetAllWords()
    {
        words.Clear();
        string[] guids = UnityEditor.AssetDatabase.FindAssets("t:Word");
        foreach (string guid in guids)
        {
            string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
            Word word = UnityEditor.AssetDatabase.LoadAssetAtPath<Word>(path);
            words.Add(word);
            // Now you can work with your Word object
        }

    }
#endif

}