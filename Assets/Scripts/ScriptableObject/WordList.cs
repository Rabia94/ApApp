using System.Collections.Generic;
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
        }
        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.AssetDatabase.SaveAssets();
    }

    [Button]
    public void FindMissingObjects()
    {
        foreach (var word in words)
        {
            if (string.IsNullOrWhiteSpace(word.Label))
            {
                Debug.Log($"{word.name} Label eksik",word);
            }
            if (word.Image == null)
            {
                Debug.Log($"{word.name} Image eksik",word);
            }
            if (word.Audio == null)
            {
                Debug.Log($"{word.name} Audio eksik",word);
            }
            
        }
    }

    
    
#endif

}