using System;
using System.Collections.Generic;

[Serializable]
public class QuestionData
{
    public Word CorrectWord;
    public List<Word> AllWords=new List<Word>();
    public int QuestionIndex;
}