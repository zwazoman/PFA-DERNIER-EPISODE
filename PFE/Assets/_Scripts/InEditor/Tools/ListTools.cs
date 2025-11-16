using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ListTools
{
    public static T PickRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
