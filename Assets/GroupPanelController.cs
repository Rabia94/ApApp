using System;
using System.Collections.Generic;
using System.Linq;
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
        for (int i = 1; i < categoryGroups.Count+1; i++)
        {
            Instantiate(_panelButtonPrefab, _parent).SetButton(i,_nextSceneIndex);
        }
    }
}