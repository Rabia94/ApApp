using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.TMP_Dropdown;

public class MenuView : MonoBehaviour
{
    [SerializeField] GameObject modePanel;
    [SerializeField] GameObject questionSettingsPanel;
    [SerializeField] TMP_Dropdown category;
    [SerializeField] TMP_Dropdown difficulty;
    [SerializeField] TMP_Dropdown numberOfChoices;
    [SerializeField] TMP_InputField numberOfQuestions;


    public void OpenQuestionSettingsMenu()
    {
        modePanel.SetActive(false);
        questionSettingsPanel.SetActive(true);
    }

    public void SetMenu()
    {
        SetCategory();
        SetDifficulty();
        SetNumberOfChoices();
        SetNumberOfQuestions();
        ListenValueChange();
    }

    void SetCategory()
    {
        category.options.Clear();
        for (int i = 0; i < Enum.GetNames(typeof(Category)).Length; i++)
        {
            OptionData optionData = new OptionData();
            optionData.text = ((Category)i).ToString();
            category.options.Add((optionData));
        }
        category.value = (int)QuestionSettings.Category;
    }

    void SetDifficulty()
    {
        difficulty.options.Clear();
        for (int i = 0; i < Enum.GetNames(typeof(Difficulty)).Length; i++)
        {
            OptionData optionData = new OptionData();
            optionData.text = ((Difficulty)i).ToString();
            difficulty.options.Add((optionData));
        }
        difficulty.value = (int)QuestionSettings.Difficulty;
    }

    void SetNumberOfChoices()
    {
        numberOfChoices.value = QuestionSettings.AnswerCount-2;
    }
    void SetNumberOfQuestions()
    {
        numberOfQuestions.text= QuestionSettings.QuestionCount.ToString();
    }

    void ListenValueChange()
    {
        category.onValueChanged.AddListener((x)=> { UpdateQualitySettings(); });
        difficulty.onValueChanged.AddListener((x) => { UpdateQualitySettings(); });
        numberOfChoices.onValueChanged.AddListener((x) => { UpdateQualitySettings(); });
        numberOfQuestions.onValueChanged.AddListener((x) => { UpdateQualitySettings(); });
    }

    public void UpdateQualitySettings()
    {
        QuestionSettings.Category = (Category)category.value;
        QuestionSettings.Difficulty = (Difficulty)difficulty.value;
        QuestionSettings.AnswerCount = numberOfChoices.value + 2;
        Int32.TryParse(numberOfQuestions.text, out QuestionSettings.QuestionCount);
        Debug.Log(QuestionSettings.Category);
        Debug.Log(QuestionSettings.Difficulty);
        Debug.Log(QuestionSettings.AnswerCount);
        Debug.Log(QuestionSettings.QuestionCount);
    }
}