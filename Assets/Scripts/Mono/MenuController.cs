using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] MenuView menuView;
    [SerializeField] MenuModel questionModel;


    public void SelectMode() { }
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