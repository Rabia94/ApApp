using System;
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
        //SetNumberOfChoices();
        SetNumberOfQuestions();
        ListenValueChange();
        UpdateQualitySettings();
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
        kelimeTekrarSayısı.onValueChanged.AddListener((x) => { UpdateQualitySettings(); });
    }

    private void UpdateQualitySettings()
    {
//        QuestionSettings.Category = (Category)category.value;
        QuestionSettings.Difficulty = (Difficulty)difficulty.value;
        int cevapSayısı;
        Int32.TryParse(numberOfChoices.options[numberOfChoices.value].text, out cevapSayısı);
        QuestionSettings.AnswerCount = cevapSayısı;         
        int tekrar;
        Int32.TryParse(kelimeTekrarSayısı.options[kelimeTekrarSayısı.value].text, out tekrar);
        QuestionSettings.QuestionCount = tekrar * _questionModel.GetSelectedCategoryGroupWords().Count;
        Debug.Log(QuestionSettings.Category);
        Debug.Log(QuestionSettings.Difficulty);
        Debug.Log(QuestionSettings.AnswerCount);
        Debug.Log(QuestionSettings.QuestionCount);
    }
}