using UnityEngine;
namespace Hasan.Extensions
{
    public static class ObjectExtensions
    {
        public static void Log(this object obj)
        {
            Debug.Log(obj);
        }

        public static void Log(this object obj, string message)
        {
            Debug.Log(obj + " " + message);
        }

        public static void Log(this object obj, string message, Object target)
        {
            Debug.Log(obj + " " + message, target);
        }
        
        public static void LogError(this object obj)
        {
            Debug.LogError(obj);
        }

        public static void LogError(this object obj, string message)
        {
            Debug.Log(obj + " " + message);
        }

        public static void LogError(this object obj, string message, Object target)
        {
            Debug.Log(obj + " " + message, target);
        }
    }
}