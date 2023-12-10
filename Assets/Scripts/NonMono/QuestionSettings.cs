using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionSettings 
{
    public static Mode Mode;
    public static Difficulty Difficulty { get; set; }
    public static int QuestionCount = 3;
    public static int WordRepeatCount = 1;
    public static int AnswerCount = 5;
    public static Category Category;
    public static int GroupIndex;
}