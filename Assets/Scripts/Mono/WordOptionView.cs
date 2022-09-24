using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordOptionView : MonoBehaviour
{
    [SerializeField]Image wordImage;
    [SerializeField]Button button;

    public void SetWord(Word word,UnityAction onButtonClick)
    {
        wordImage.sprite = word.Image;
        button.onClick.AddListener(onButtonClick);
    }


}