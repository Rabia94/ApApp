using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListHelper 
{
    public static T GetRandomElement<T>(this List<T> list)
    {
            return list[Random.Range(0, list.Count)];
    }


    public static List<T> RandomizeList<T>(this List<T> list)
    {
        List<T> newList=new List<T>();

        while (list.Count > 0)
        {
            var element = list.GetRandomElement();
            list.Remove(element);
            newList.Add(element);
        }
        return newList;
    }
}
