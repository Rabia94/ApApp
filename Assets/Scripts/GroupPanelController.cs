using NonMono;
using TMPro;
using UnityEngine;

public class GroupPanelController : MonoBehaviour
{
    [SerializeField] private GroupButton  _panelButtonPrefab;
    [SerializeField] private Transform  _parent;
    [SerializeField] private int nextSceneIndex;
    [SerializeField] private TMP_Text categoryHeader;
    public void SetPanel(QuestionModel questionModel, Category category, string categoryName)
    {
        categoryHeader.SetText(categoryName);
        for (int i = 0; i < _parent.childCount; i++)
        {
            Destroy(_parent.GetChild(i).gameObject);
        }
        var categoryGroups= questionModel.GetCategoryGroups(category);
        for (int i = 0; i < categoryGroups.Count; i++)
        {
            Instantiate(_panelButtonPrefab, _parent).SetButton(categoryGroups[i],SaveManager.GetCategoryResult(category,categoryGroups[i]),nextSceneIndex);
        }
    }
}