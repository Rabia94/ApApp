using UnityEngine;

namespace NonMono
{
    public static class SaveManager
    {
        private static string saveKey = "UserData";
        
        public static void SaveUserData()
        {
            PlayerPrefs.SetString("saveKey",JsonUtility.ToJson(typeof(UserData)));
        }
     
        public static UserData GetUserData()
        {
            if (PlayerPrefs.HasKey(saveKey))
            {
                return JsonUtility.FromJson<UserData>(PlayerPrefs.GetString(saveKey));
            }
            else
            {
                return new UserData();
            }
        }
        
        public static void SaveCategoryResult(Category category, int group, int result)
        {
            PlayerPrefs.SetInt(category.ToString()+group,result);
        }
        
        public static int GetCategoryResult(Category category, int group)
        {
           return PlayerPrefs.GetInt(category.ToString()+group,0);
        }

    }
}