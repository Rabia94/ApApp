using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static UserData UserData;
    [SerializeField] private int _patientInfoSceneIndex;
    [SerializeField] private int _welcomeSceneIndex;
    private static string _saveKey = "UserData";

    private void Awake()
    {
        SetUserData();
        if (UserData == null)
        {
            SceneManager.LoadScene(_patientInfoSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(_welcomeSceneIndex);
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
    public string AfaziTuru;
    public string SeyDiyor;
    public string DuydugunuAnlamak;
    public string KonusmaktaZorluk;
    public string KonusmaktaTekrar;
    public string OkumaktaZorluk;
    public string YazmakdaZorluk;
}