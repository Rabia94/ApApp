

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeviceUsageView : MonoBehaviour
{
    public Button PreviousButton;
    public Button NextButton;

    [SerializeField] private TMP_Dropdown screenTime;
    [SerializeField] private TMP_Dropdown mobileUsageSkill;
    [SerializeField] private Toggle[] activeDevices;
    [SerializeField] private Toggle[] usagePurpose;


    public string GetScreenTime()
    {
        return screenTime.options[screenTime.value].text;
    }

    public string GetMobileUsageSkill()
    {
        return mobileUsageSkill.options[mobileUsageSkill.value].text;
    }

    public string GetActiveDevices()
    {
        var devices = "";
        for (int i = 0; i < activeDevices.Length; i++)
        {
            if (activeDevices[i].isOn)
            {
                if (!string.IsNullOrWhiteSpace(devices))
                {
                    devices += ", ";
                }
                devices += activeDevices[i].name;
            }
        }
        Debug.Log(devices);

        return devices;
    }
    
    public string GetUsagePurpose()
    {
        var purpose = "";
        for (int i = 0; i < usagePurpose.Length; i++)
        {
            if (usagePurpose[i].isOn)
            {
                if (!string.IsNullOrWhiteSpace(purpose))
                {
                    purpose += ", ";
                }
                purpose += usagePurpose[i].name;
            }
        }
        Debug.Log(purpose);
        return purpose;
    }
}
