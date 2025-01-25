using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace RedAxeGames.Extensions
{
    public static class RA_ListExtension 
    {
        private static readonly Random Rand = new Random();
        public static T GetRandomItemToList<T>(this List<T> someList)
        {
            return someList[UnityEngine.Random.Range(0, someList.Count)];
        }

        public static int GetRandomIndexFromList<T>(this List<T> someList)
        {
            return UnityEngine.Random.Range(0, someList.Count);
        }
    
        public static void RemoveRandomItemToList<T>(this List<T> someList)
        {
            someList.RemoveAt(UnityEngine.Random.Range(0, someList.Count));
        }

        public static void SetActiveList(this List<GameObject> someList, bool value)
        {
            foreach (var item in someList)
            {
                item.SetActive(value);
            }
        }

        public static void RemoveNullToList<T>(this List<T> someList)
        {
            for (int i = someList.Count - 1; i > -1; i--)
            {
                if (someList[i] == null)
                {
                    someList.RemoveAt(i);
                }
            }
        }
        public static T RandomElement<T>(this T[] items)
        {
            return items[Rand.Next(0, items.Length)];
        }


        public static T RandomElement<T>(this List<T> items)
        {
            if (items.Count == 0)
            {
                return default;
            }
            return items[Rand.Next(0, items.Count)];
        }
    }
}