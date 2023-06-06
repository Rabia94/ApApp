using UnityEngine;

public class CategoryController : MonoBehaviour
{
    [SerializeField]
    private QuestionModel _questionModel;
    [SerializeField] private CategoryButton  _categoryButtonPrefab;
    [SerializeField] private Transform  _parent;
    [SerializeField] private GroupPanelController  _groupPanelController;
    [SerializeField] private CategoryButtonData[] _categoryButtonDatas;

    private void Awake()
    {
        SetButtons();
    }

    void SetButtons()
    {
        foreach (CategoryButtonData categoryButtonData in _categoryButtonDatas)
        {
            Instantiate(_categoryButtonPrefab, _parent).SetButton(categoryButtonData,SetGroupPanel);
        }
    }

    void SetGroupPanel(CategoryButtonData categoryButtonData)
    {
        _groupPanelController.SetPanel(_questionModel.GetCategoryGroups(categoryButtonData.Category));
    }
}