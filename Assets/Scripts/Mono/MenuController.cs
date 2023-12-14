using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] MenuView menuView;

    private void Awake()
    {
        menuView.SetMenu();
    }

    public void SelectMode(int i)
    {
        QuestionSettings.Data.Mode = (Mode)i;
        OpenQuestionSettingsMenu();
    }

    void OpenQuestionSettingsMenu()
    {
        menuView.OpenQuestionSettingsMenu();
    }


}