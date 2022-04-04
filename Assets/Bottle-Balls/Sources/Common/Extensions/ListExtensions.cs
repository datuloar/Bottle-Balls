using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var temp = list[i];
            var random = Random.Range(0, list.Count);

            list[i] = list[random];
            list[random] = temp;
        }
    }
}
