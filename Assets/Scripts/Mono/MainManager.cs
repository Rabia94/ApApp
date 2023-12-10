using NonMono;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static UserData UserData;
    [SerializeField] private int _patientInfoSceneIndex;
    [SerializeField] private int _welcomeSceneIndex;

    private void Awake()
    {
        UserData = SaveManager.GetUserData();
        if (UserData == null)
        {
            SceneManager.LoadScene(_patientInfoSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(_welcomeSceneIndex);
        }
    }

}