using NonMono;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text welcome;
    [SerializeField] private Button startButton;
    [SerializeField] private Button deleteUserDataButton;
    [SerializeField] private int gameMenuIndex;
    private void Awake()
    {
        welcome.SetText("Hoşgeldin "+ MainManager.UserData.Name+ "!");
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(OpenGameMenu);
        deleteUserDataButton.onClick.AddListener(DeleteUserData);
    }
    
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OpenGameMenu);
        deleteUserDataButton.onClick.RemoveListener(DeleteUserData);
    }
    
    
    private void OpenGameMenu()
    {
        SceneManager.LoadScene(gameMenuIndex);
    }
    
    private void DeleteUserData()
    {
        SaveManager.DeleteUserData();
        SceneManager.LoadScene(0);
    }

}