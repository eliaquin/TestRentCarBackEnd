using System;
using System.Text.RegularExpressions;

namespace WeRentCarBackEnd.Utils
{
    public static class TextManager
    {
        public static string ToAlphanumeric(this string input)
        {
            var rgx = new Regex("[^a-zA-Z0-9]");
            return rgx.Replace(input, "");
        }

        public static string ToAlphabetic(this string input)
        {
            var rgx = new Regex("[^a-zA-Z]");
            return rgx.Replace(input, "");
        }

        public static string ToNumeric(this string input)
        {
            var rgx = new Regex("[^0-9]");
            return rgx.Replace(input, "");
        }

        public static bool IsNullEmptyOrWhiteSpace(this string texto)
        {
            return String.IsNullOrWhiteSpace(texto) || String.IsNullOrEmpty(texto);
        }
    }
}
