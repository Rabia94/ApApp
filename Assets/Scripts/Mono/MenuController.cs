using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] MenuView menuView;
    [SerializeField] MenuModel questionModel;


    private void Awake()
    {
        menuView.SetMenu();
    }

    public void SelectMode(int i)
    {
        QuestionSettings.Mode = (Mode)i;
        OpenQuestionSettingsMenu();
    }

    void OpenQuestionSettingsMenu()
    {
        menuView.OpenQuestionSettingsMenu();
    }


}