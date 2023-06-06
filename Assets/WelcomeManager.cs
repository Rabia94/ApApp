using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _welcome;
    [SerializeField] private Button _startButton;
    [SerializeField] private int _gameMenuIndex;
    private void Awake()
    {
        _welcome.SetText("Hoş geldin "+ MainManager.UserData.Name+ "!");
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OpenGameMenu);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OpenGameMenu);
    }

    private void OpenGameMenu()
    {
        SceneManager.LoadScene(_gameMenuIndex);
    }
}