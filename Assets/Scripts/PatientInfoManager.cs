using NonMono;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PatientInfoManager : MonoBehaviour
{
    //buralar farklı kodlata ayrılması lazım. şimdilik çok dokunmuyorum.
    [SerializeField] private Button demographicPanelNextButton;
    [SerializeField] private Button patientInfoPanelPreviousButton; 
    [SerializeField] private Button saveButton;
    [SerializeField] private GameObject demographicPanel;
    [SerializeField] private DeviceUsageView deviceUsageView;
    [SerializeField] private GameObject patientInfoPanel;
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_Dropdown gender;
    [SerializeField] private TMP_InputField day;
    [SerializeField] private TMP_InputField month;
    [SerializeField] private TMP_InputField year;
    [SerializeField] private TMP_Dropdown education;
    [SerializeField] private TMP_InputField employment;
    [SerializeField] private TMP_Dropdown afaziTuru;
    [SerializeField] private TMP_Dropdown seyDiyor;
    [SerializeField] private TMP_Dropdown duydugunuAnlamak;
    [SerializeField] private TMP_Dropdown konusmaktaZorluk;
    [SerializeField] private TMP_Dropdown konusmaktaTekrar;
    [SerializeField] private TMP_Dropdown okumaktaZorluk;
    [SerializeField] private TMP_Dropdown yazmakdaZorluk;
    [SerializeField] private int welcomeSceneIndex;

    private void OnEnable()
    {
        demographicPanelNextButton.onClick.AddListener(DemographicNextPage);
        deviceUsageView.NextButton.onClick.AddListener(DeviceUsageNextPage);
        deviceUsageView.PreviousButton.onClick.AddListener(DeviceUsagePreviousPage);
        patientInfoPanelPreviousButton.onClick.AddListener(PatientInfoPreviousPage);
        saveButton.onClick.AddListener(SaveUserData);
        demographicPanel.SetActive(true);
        deviceUsageView.gameObject.SetActive(false);
        patientInfoPanel.SetActive(false);
    }

    private void OnDisable()
    {
        demographicPanelNextButton.onClick.RemoveListener(DemographicNextPage);
        patientInfoPanelPreviousButton.onClick.RemoveListener(PatientInfoPreviousPage);
        saveButton.onClick.RemoveListener(SaveUserData);
    }

    void DemographicNextPage()
    {
        if (SetErrorIfEmpty(userName) && SetErrorIfEmpty(day) && SetErrorIfEmpty(month) &&
            SetErrorIfEmpty(year)&& SetErrorIfEmpty(employment))
        {
            demographicPanel.SetActive(false);
            deviceUsageView.gameObject.SetActive(true);
        }
        else
        {
            SetErrorIfEmpty(userName);
            SetErrorIfEmpty(day);
            SetErrorIfEmpty(month);
            SetErrorIfEmpty(year);
            SetErrorIfEmpty(employment);
        }
    }
    
    void PatientInfoPreviousPage()
    {
        deviceUsageView.gameObject.SetActive(true);
        patientInfoPanel.SetActive(false);
    }
    
    void DeviceUsagePreviousPage()
    {
        deviceUsageView.gameObject.SetActive(false);
        demographicPanel.SetActive(true);
    }
    
    void DeviceUsageNextPage()
    {
        deviceUsageView.gameObject.SetActive(false);
        patientInfoPanel.SetActive(true);
    }
    
    void SaveUserData()
    {
        MainManager.UserData = new UserData
        {
            Name = userName.text,
            Gender = gender.options[gender.value].text,
            Birthday = $"{day.text}/{month.text}/{year.text}",
            Education = education.options[education.value].text,
            Employment = employment.text,
            ScreenTime = deviceUsageView.GetScreenTime(),
            MobileUsageSkill = deviceUsageView.GetMobileUsageSkill(),
            ActiveDevices = deviceUsageView.GetActiveDevices(),
            UsagePurpose = deviceUsageView.GetUsagePurpose(),
            AfaziTuru = afaziTuru.options[afaziTuru.value].text,
            SeyDiyor = seyDiyor.options[seyDiyor.value].text,
            DuydugunuAnlamak = duydugunuAnlamak.options[duydugunuAnlamak.value].text,
            KonusmaktaZorluk = konusmaktaZorluk.options[konusmaktaZorluk.value].text,
            KonusmaktaTekrar = konusmaktaTekrar.options[konusmaktaTekrar.value].text,
            OkumaktaZorluk = okumaktaZorluk.options[okumaktaZorluk.value].text,
            YazmakdaZorluk = yazmakdaZorluk.options[yazmakdaZorluk.value].text,
        };
        
        SaveManager.SaveUserData();
        SceneManager.LoadScene(welcomeSceneIndex);
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