using NonMono;

public static class QuestionSettings
{
    private static QuestionSettingsData questionSettingsData;

    public static QuestionSettingsData Data
    {
        get
        {
            if (questionSettingsData == null)
            {
                questionSettingsData = SaveManager.GetQuestionSettings();
            }
            return questionSettingsData;
        } 
    } 
}