using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Word")]
public class Word : ScriptableObject
{
    public Category Category;
    public string Label;
    public Sprite Image;
    public AudioClip Audio;
}
