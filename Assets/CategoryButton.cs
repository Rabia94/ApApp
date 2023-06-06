using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    public void SetButton(CategoryButtonData categoryButtonData, UnityAction<CategoryButtonData> onButtonClick)
    {
        _button.onClick.AddListener(()=>onButtonClick(categoryButtonData));
    }
    
}