using NonMono;
using UnityEngine;
using UnityEngine.UI;

public class CategoryController : MonoBehaviour
{
    [SerializeField]
    private QuestionModel _questionModel;
    [SerializeField] private CategoryButton  _categoryButtonPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private ScrollRect  scrollRect;

    [SerializeField] private GroupPanelController  _groupPanelController;
    [SerializeField] private CategoryButtonData[] _categoryButtonDatas;

    private void Awake()
    {
        _parent.gameObject.SetActive(true);
        _groupPanelController.gameObject.SetActive(false);
        SetButtons();
    }

    void SetButtons()
    {
        foreach (CategoryButtonData categoryButtonData in _categoryButtonDatas)
        {
            var groupIDs = _questionModel.GetCategoryGroups(categoryButtonData.Category);
            float result = 0;
            for (int i = 0; i < groupIDs.Count; i++)
            {
                result += SaveManager.GetCategoryResult(categoryButtonData.Category, groupIDs[i]);
            }
            result /= groupIDs.Count;
            CategoryButton categoryButton =Instantiate(_categoryButtonPrefab, _parent);
            categoryButton.SetButton(categoryButtonData,(int)result,SetGroupPanel);
        }
    }

    void SetGroupPanel(CategoryButtonData categoryButtonData)
    {
        _groupPanelController.SetPanel(_questionModel,categoryButtonData.Category);
        QuestionSettings.Category = categoryButtonData.Category;
        _parent.gameObject.SetActive(false);
        _groupPanelController.gameObject.SetActive(true);
    }
}