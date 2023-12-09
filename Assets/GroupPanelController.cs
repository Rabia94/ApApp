using System;
using System.Collections.Generic;
using System.Linq;
using NonMono;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GroupPanelController : MonoBehaviour
{
    [SerializeField] private GroupButton  _panelButtonPrefab;
    [SerializeField] private Transform  _parent;
    [SerializeField] private int _nextSceneIndex=4;
    public void SetPanel(QuestionModel questionModel,Category category)
    {
        var categoryGroups= questionModel.GetCategoryGroups(category);
        for (int i = 0; i < categoryGroups.Count; i++)
        {
            Instantiate(_panelButtonPrefab, _parent).SetButton(categoryGroups[i],SaveManager.GetCategoryResult(category,categoryGroups[i]),_nextSceneIndex);
        }
    }
}