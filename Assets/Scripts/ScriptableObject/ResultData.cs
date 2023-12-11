using UnityEngine;

public struct ResultData
{
    public Difficulty Difficulty => QuestionSettings.Difficulty;
    public int QuestionCount => QuestionSettings.QuestionCount;
    public int NumberOfOptions => QuestionSettings.NumberOfOptions;
    public int ResultPercentage => (int)(100f * CorrectAnswerCount / QuestionCount);
    public int CorrectAnswerCount;
    public int WrongAnswerCount;
    public float Time { get; set; }
    public float TimePerQuestion => Time / QuestionCount;
}