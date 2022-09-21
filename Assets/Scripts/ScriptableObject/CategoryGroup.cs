using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ApApp/CategoryGroup")]
public class CategoryGroup : ScriptableObject
{
    [SerializeField] List<Category> categories;
    public List<Category> Categories => categories.Distinct().ToList();


}