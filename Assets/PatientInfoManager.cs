using NonMono;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PatientInfoManager : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _saveButton;
    [SerializeField] private GameObject _demographicPanel;
    [SerializeField] private GameObject _patientInfoPanel;
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_Dropdown _gender;
    [SerializeField] private TMP_InputField _day;
    [SerializeField] private TMP_InputField _month;
    [SerializeField] private TMP_InputField _year;
    [SerializeField] private TMP_Dropdown _education;
    [SerializeField] private TMP_InputField _employment;
    
    
    
    
    [SerializeField] private TMP_Dropdown _afaziTuru;
    [SerializeField] private TMP_Dropdown _seyDiyor;
    [SerializeField] private TMP_Dropdown _duydugunuAnlamak;
    [SerializeField] private TMP_Dropdown _konusmaktaZorluk;
    [SerializeField] private TMP_Dropdown _konusmaktaTekrar;
    [SerializeField] private TMP_Dropdown _okumaktaZorluk;
    [SerializeField] private TMP_Dropdown _yazmakdaZorluk;
    [SerializeField] private int _welcomeSceneIndex;

    private void OnEnable()
    {
        _nextButton.onClick.AddListener(DemographicNextPage);
        _previousButton.onClick.AddListener(PreviousPage);
        _saveButton.onClick.AddListener(SaveUserData);
        _demographicPanel.SetActive(true);
        _patientInfoPanel.SetActive(false);
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(DemographicNextPage);
        _previousButton.onClick.RemoveListener(PreviousPage);
        _saveButton.onClick.RemoveListener(SaveUserData);
    }

    void DemographicNextPage()
    {
        if (SetErrorIfEmpty(_name) && SetErrorIfEmpty(_day) && SetErrorIfEmpty(_month) &&
            SetErrorIfEmpty(_year)&& SetErrorIfEmpty(_employment))
        {
            _demographicPanel.SetActive(false);
            _patientInfoPanel.SetActive(true);
        }
        else
        {
            SetErrorIfEmpty(_name);
            SetErrorIfEmpty(_day);
            SetErrorIfEmpty(_month);
            SetErrorIfEmpty(_year);
            SetErrorIfEmpty(_employment);
        }
    }

    void DeviceUsageNextPage()
    {
     
    }
    
    void PreviousPage()
    {
        _demographicPanel.SetActive(true);
        _patientInfoPanel.SetActive(false);
    }
    
    void SaveUserData()
    {
        MainManager.UserData = new UserData
        {
            Name = _name.text,
            Gender = _gender.options[_gender.value].text,
            Birthday = $"{_day.text}/{_month.text}/{_year.text}",
            Education = _education.options[_education.value].text,
            Employment = _employment.text,
            AfaziTuru = _afaziTuru.options[_afaziTuru.value].text,
            SeyDiyor = _seyDiyor.options[_seyDiyor.value].text,
            DuydugunuAnlamak = _duydugunuAnlamak.options[_duydugunuAnlamak.value].text,
            KonusmaktaZorluk = _konusmaktaZorluk.options[_konusmaktaZorluk.value].text,
            KonusmaktaTekrar = _konusmaktaTekrar.options[_konusmaktaTekrar.value].text,
            OkumaktaZorluk = _okumaktaZorluk.options[_okumaktaZorluk.value].text,
            YazmakdaZorluk = _yazmakdaZorluk.options[_yazmakdaZorluk.value].text,
        };
        
        SaveManager.SaveUserData();
        SceneManager.LoadScene(_welcomeSceneIndex);
    }

    
    bool SetErrorIfEmpty(TMP_InputField inputField)
    {
        if (string.IsNullOrWhiteSpace(inputField.text))
        {
            inputField.placeholder.color = Color.red;
            return false;
        }

        return true;
    }

}