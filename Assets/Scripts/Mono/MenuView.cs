using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] GameObject modePanel;
    [SerializeField] GameObject questionSettingsPanel;
    [SerializeField] TMP_Dropdown category;
    [SerializeField] TMP_Dropdown dificulty;
    [SerializeField] TMP_Dropdown numberOfChoices;
    [SerializeField] TMP_InputField numberOfQuestions;


    public void OpenQuestionSettingsMenu()
    {
        modePanel.SetActive(false);
        questionSettingsPanel.SetActive(true);
    }

    public void SetSettings()
    {
        QuestionSettings.Category = (Category)category.value;
    }
}