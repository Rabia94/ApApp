using UnityEngine;

public struct ResultData
{
    public Difficulty Difficulty => QuestionSettings.Difficulty;
    public int QuestionCount => QuestionSettings.QuestionCount;
    public int AnswerCount => QuestionSettings.AnswerCount;
    public int CorrectAnswerCount;
    public int WrongAnswerCount;
    public float Time;
}