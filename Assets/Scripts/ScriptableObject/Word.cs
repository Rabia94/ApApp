using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ApApp/Word")]
public class Word : ScriptableObject
{
    public Category Category;
    [Range(1,20)] public int Group;
    public string Label;
    public Sprite Image;
    public AudioClip Audio;
}