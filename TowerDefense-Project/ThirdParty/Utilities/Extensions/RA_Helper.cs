using UnityEngine;

namespace RedAxeGames.Extensions
{
    public static class RAHelper
    {
        public static Quaternion RandomQuaternion(this Quaternion quaternion)
        {
            quaternion = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            return quaternion;
        }
    
        public static float GetPercentage(this float v, float value) => v - v / 100 * value;
        public static string GetHexByColor(this Color color) => ColorUtility.ToHtmlStringRGB(color);
        public static bool GetBoolByRandom01(this float v) => Random.Range(0f, 1f) < v;
        public static void SetUIBar(this Transform bar, float ratio) => bar.transform.localScale = new Vector3(ratio, 1, 1);
    }   
}