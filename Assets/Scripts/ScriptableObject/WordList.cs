using System.Collections.Generic;
using UnityEngine;
using VInspector;
#if UNITY_EDITOR
using VInspector.Libs;
#endif

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

    [Button]
    public void FindMissMatchingNames()
    {
        foreach (var word in words)
        {
            if (word.Image ==null ||word.Label.ToLower().Remove(" ")!=word.Image.name.ToLower().Remove(" "))
            {
                Debug.Log($"{word.name} Image isimle eşleşmedi ({word.Image})",word);
            }
            if (word.Audio ==null || word.Label.ToLower().Remove(" ")!=word.Audio.name.ToLower().Remove(" "))
            {
                Debug.Log($"{word.name} Audio isimle eşleşmedi ({word.Audio})",word);
            }
            
        }
    }
    
    
    
#endif

}