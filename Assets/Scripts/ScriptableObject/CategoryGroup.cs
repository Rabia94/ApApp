using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ApApp/CategoryGroup")]
public class CategoryGroup : ScriptableObject
{
    [SerializeField] List<SubCategory> categories;
    public List<SubCategory> Categories => categories.Distinct().ToList();
}