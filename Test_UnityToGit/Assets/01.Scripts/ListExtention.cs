using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public static class ListExtention
{
    public static T RandomItem<T>(this List<T> list)
    {
        if (list.Count == 0)
            throw new IndexOutOfRangeException("List is Empty");

            var randomIndex = Random.Range(0, list.Count);

            return list[randomIndex];
    }
}
