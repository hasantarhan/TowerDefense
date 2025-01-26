using System;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hasan.Extensions
{
    public static class StringExtensions
    {
        public static string Bold(this string str) => "<b>" + str + "</b>";
        public static string Color(this string str, string clr) => string.Format("<color={0}>{1}</color>", clr, str);
        public static string Italic(this string str) => "<i>" + str + "</i>";
        public static string Size(this string str, int size) => string.Format("<size={0}>{1}</size>", size, str);
        public static string GetFormat(this float v) => string.Format("{0:#,0}", v);
        public static string GetCashWithoutSymbol(this float v) => string.Format("{0:#,0} ",  v);
        public static string GetCashWithoutSymbol(this int v) => string.Format("{0:#,0} ",  v);
        
        public static Color GetColorByHex(this string hex)
        {
            Color newColor;

            if (ColorUtility.TryParseHtmlString("#" + hex, out newColor))
                newColor = newColor;

            return newColor;
        }

        public static Color GetColorByLevelHex(this string hex)
        {
            Color newColor;

            if (ColorUtility.TryParseHtmlString(hex, out newColor))
                newColor = newColor;

            return newColor;
        }
        
         public static string RemoveEmptyLines(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return string.Join(Environment.NewLine,
                str.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                    .Where(line => !string.IsNullOrWhiteSpace(line)));
        }

        public static string RemovePrefixAndAfter(this string text, string prefix)
        {
            int index = text.IndexOf(prefix);
            if (index >= 0)
            {
                return text.Substring(0, index);
            }
            return text;
        }

        public static string AddLineBreaks(this string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input) || maxLength <= 0)
            {
                return input;
            }

            StringBuilder result = new StringBuilder();
            int currentLength = 0;

            foreach (char c in input)
            {
                if (currentLength >= maxLength)
                {
                    result.Append('\n');
                    currentLength = 0;
                }

                result.Append(c);
                currentLength++;
            }

            return result.ToString();
        }

        public static string AddLineBreaksWithoutCut(this string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input) || maxLength <= 0)
            {
                return input;
            }

            StringBuilder result = new StringBuilder();
            string[] words = input.Split(' ');
            int currentLength = 0;

            foreach (string word in words)
            {
                if (currentLength + word.Length + 1 > maxLength)
                {
                    result.Append('\n');
                    currentLength = 0;
                }
                else if (currentLength > 0) 
                {
                    result.Append(' ');
                    currentLength++;
                }

                result.Append(word);
                currentLength += word.Length;
            }

            return result.ToString();
        }
    }
}