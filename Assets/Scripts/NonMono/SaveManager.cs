using UnityEngine;

namespace NonMono
{
    public static class SaveManager
    {
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