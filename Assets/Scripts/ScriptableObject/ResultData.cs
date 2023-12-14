using UnityEngine;

public struct ResultData
{
    public Difficulty Difficulty => QuestionSettings.Data.Difficulty;
    public int QuestionCount => QuestionSettings.Data.QuestionCount;
    public int NumberOfOptions => QuestionSettings.Data.NumberOfOptions;
    public int ResultPercentage => (int)(100f * CorrectAnswerCount / QuestionCount);
    public int CorrectAnswerCount;
    public int WrongAnswerCount;
    public float Time { get; set; }
    public float TimePerQuestion => Time / QuestionCount;
}