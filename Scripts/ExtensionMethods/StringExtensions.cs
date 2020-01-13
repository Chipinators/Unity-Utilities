using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public static class StringExtensions
{
    public static string FirstCharsToUpper(this string input)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }

    public static string RemoveNumbers(this string input)
    {
        return new string(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
    }

    public static string RemoveSpaces(this string input)
    {
        return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }
}
