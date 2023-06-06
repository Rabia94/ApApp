using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GroupPanelController : MonoBehaviour
{
    [SerializeField] private GroupButton  _panelButtonPrefab;
    [SerializeField] private Transform  _parent;
    [SerializeField] private CategoryButtonData[] _categoryButtonDatas;
    [SerializeField] private int _nextSceneIndex=4;
    public void SetPanel(List<int> categoryGroups)
    {
        foreach (int group in categoryGroups)
        {
            Instantiate(_panelButtonPrefab, _parent).SetButton(group,_nextSceneIndex);
        }
    }
}