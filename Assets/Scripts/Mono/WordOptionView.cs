using UnityEngine;
using UnityEngine.UI;

public class WordOptionView : MonoBehaviour
{
    [SerializeField]Image wordImage;

    public void SetWord(Word word)
    {
        wordImage.sprite = word.Image;
    }
}