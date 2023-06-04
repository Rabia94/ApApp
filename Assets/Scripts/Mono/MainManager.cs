using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static UserData UserData;
    [SerializeField] private string _patientInfoScene;
    private static string _saveKey = "UserData";

    private void Awake()
    {
        SetUserData();
        if (UserData == null)
        {
            SceneManager.LoadScene(_patientInfoScene);
        }
    }

    private void SetUserData()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            UserData = JsonUtility.FromJson<UserData>(PlayerPrefs.GetString(_saveKey));
        }
    }

    public static void SaveUserData()
    {
        PlayerPrefs.SetString(_saveKey,JsonUtility.ToJson(UserData));
    }
}

public class UserData
{
    public string Name;
    public string Gender;
    public string Birthday;
    public string Education;
    public string Employment;
}