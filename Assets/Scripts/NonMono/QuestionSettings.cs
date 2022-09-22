using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionSettings 
{
    public static Mode Mode;
    public static Difficulty Difficulty;
    public static int QuestionCount = 3;
    public static int AnswerCount = 5;
    public static List<Category> Categories = new List<Category> { Category.Aksesuar, Category.AltGiyim };
}
