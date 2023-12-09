using NonMono;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider finishedPercentageSlider;
    [SerializeField] private TMP_Text finishedPercentageText;
    public void SetButton(CategoryButtonData categoryButtonData, int result,  UnityAction<CategoryButtonData> onButtonClick)
    {
        _button.onClick.AddListener(()=>onButtonClick(categoryButtonData));
        _image.sprite = categoryButtonData.CategoryImage;
        _text.text = categoryButtonData.CategoryName;
        finishedPercentageSlider.value = result;
        finishedPercentageText.SetText($"%{result}");
    }
    
}