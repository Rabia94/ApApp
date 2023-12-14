using System;
using NonMono;
using TMPro;
using UnityEngine;
using static TMPro.TMP_Dropdown;

public class MenuView : MonoBehaviour
{
    [SerializeField] private  QuestionModel _questionModel;
    [SerializeField] GameObject modePanel;
    [SerializeField] GameObject questionSettingsPanel;
    [SerializeField] TMP_Dropdown category;
    [SerializeField] TMP_Dropdown difficulty;
    [SerializeField] TMP_Dropdown numberOfChoices;
    [SerializeField] TMP_InputField numberOfQuestions;
    [SerializeField] TMP_Dropdown kelimeTekrarSayısı;


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
        UpdateQuestionSettings();
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
        category.value = (int)QuestionSettings.Data.Category;
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
        difficulty.value = (int)QuestionSettings.Data.Difficulty;
    }

    void SetNumberOfChoices()
    {
        numberOfChoices.value = Math.Max(0,(int)(QuestionSettings.Data.NumberOfOptions*.5f)-1);
    }
    void SetNumberOfQuestions()
    {
        numberOfQuestions.text= QuestionSettings.Data.QuestionCount.ToString();
    }

    void ListenValueChange()
    {
        category.onValueChanged.AddListener((x)=> { UpdateQuestionSettings(); });
        difficulty.onValueChanged.AddListener((x) => { UpdateQuestionSettings(); });
        numberOfChoices.onValueChanged.AddListener((x) => { UpdateQuestionSettings(); });
        numberOfQuestions.onValueChanged.AddListener((x) => { UpdateQuestionSettings(); });
        kelimeTekrarSayısı.onValueChanged.AddListener((x) => { UpdateQuestionSettings(); });
    }

    private void UpdateQuestionSettings()
    {
        QuestionSettings.Data.Difficulty = (Difficulty)difficulty.value;
        Int32.TryParse(numberOfChoices.options[numberOfChoices.value].text, out QuestionSettings.Data.NumberOfOptions );
        Int32.TryParse(kelimeTekrarSayısı.options[kelimeTekrarSayısı.value].text, out QuestionSettings.Data.WordRepeatCount);
        QuestionSettings.Data.QuestionCount = QuestionSettings.Data.WordRepeatCount * _questionModel.GetSelectedCategoryGroupWords().Count;
        Debug.Log(QuestionSettings.Data.Category);
        Debug.Log(QuestionSettings.Data.Difficulty);
        Debug.Log(QuestionSettings.Data.NumberOfOptions);
        Debug.Log(QuestionSettings.Data.QuestionCount);
        SaveManager.SaveQuestionSettings();
    }
}