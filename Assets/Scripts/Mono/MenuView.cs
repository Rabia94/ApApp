using System;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    [SerializeField]GameObject modePanel;
    [SerializeField]GameObject questionSettingsPanel;
    public void OpenQuestionSettingsMenu()
    {
        modePanel.SetActive(false);
        questionSettingsPanel.SetActive(true);
    }
}