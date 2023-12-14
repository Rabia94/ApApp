using UnityEngine;

namespace NonMono
{
    public static class SaveManager
    {
        private static string userSaveKey = "UserData";
        private static string questionSettingsSaveKey = "QuestionSettings";
        
        public static void SaveUserData()
        {
            PlayerPrefs.SetString(userSaveKey,JsonUtility.ToJson(MainManager.UserData));
        }
     
        public static UserData GetUserData()
        {
            if (PlayerPrefs.HasKey(userSaveKey))
            {
                return JsonUtility.FromJson<UserData>(PlayerPrefs.GetString(userSaveKey));
            }

            return null;
        }
        
        public static void SaveCategoryResult(Category category, int group, int result)
        {
            PlayerPrefs.SetInt(category.ToString()+group,result);
        }
        
        public static int GetCategoryResult(Category category, int group)
        {
           return PlayerPrefs.GetInt(category.ToString()+group,0);
        }

        public static void DeleteUserData()
        {
            PlayerPrefs.DeleteAll();
        }
        
        public static void SaveQuestionSettings()
        {
            PlayerPrefs.SetString(questionSettingsSaveKey,JsonUtility.ToJson(QuestionSettings.Data));
        }
        
        public static QuestionSettingsData GetQuestionSettings()
        {
            if (PlayerPrefs.HasKey(questionSettingsSaveKey))
            {
                return JsonUtility.FromJson<QuestionSettingsData>(PlayerPrefs.GetString(questionSettingsSaveKey));
            }
            return new QuestionSettingsData();
        }

    }
}