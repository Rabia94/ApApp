using TMPro;
using UnityEngine.UI;
using VInspector;

class ProgressSlider :Slider
{
    private TMP_Text _progressText;

    private TMP_Text progressText
    {
        get
        {
            if (_progressText == null)
            {
                _progressText=GetComponentInChildren<TMP_Text>();
            }
            return _progressText;
        }
    }
    

    [Button]
    public void SetValue(float newValue)
    {
        value = newValue;
        if (progressText != null)
        {
            progressText.SetText($"%{newValue}");
        }
    }
}