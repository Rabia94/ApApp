using System;

[Serializable]
public class QuestionSettingsData
{
    public Mode Mode{ get; set; }
    public Difficulty Difficulty{ get; set; } 
    public int QuestionCount{ get; set; }
    public int WordRepeatCount;
    public int NumberOfOptions;
    public Category Category{ get; set; }
    public int GroupIndex{ get; set; }
}