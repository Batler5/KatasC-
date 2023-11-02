// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

Console.WriteLine(GetCharsCount("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'c', 'd', 'l', 'm' }, 1, 16, 7));
Console.ReadLine();

static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
{
    if (str == null)
    {
        throw new ArgumentNullException(nameof(str));
    }

    if (startIndex < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(startIndex));
    }

    if (startIndex > str.Length)
    {
        throw new ArgumentOutOfRangeException(nameof(startIndex));
    }

    if (endIndex < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(endIndex));
    }

    if (endIndex > str.Length)
    {
        throw new ArgumentOutOfRangeException(nameof(endIndex));
    }

    if (startIndex > endIndex)
    {
        throw new ArgumentOutOfRangeException(nameof(startIndex));
    }

    if (limit < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(limit));
    }

    if (chars == null)
    {
        throw new ArgumentNullException(nameof(chars));
    }

    int count = 0;
    int i = startIndex;
    int j = 0;
    do
    {
        j = 0;
        do
        {
            if (str[i] == chars[j])
            {
                count++;
                if (count == limit)
                {
                    return count;
                }
            }

            j++;
        }
        while (j < chars.Length);
        i++;
    }
    while (i <= endIndex);

    return count;
}


Console.WriteLine(StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples\n   \nasd", new string[] { "#", "!" }));
Console.ReadLine();
public class StripCommentsSolution
{
    public static string StripComments(string text, string[] commentSymbols)
    {
        string[] arrr = text.Split('\n');
        List<string> arr = new List<string>();
        for (int i = 0; i < arrr.Length; i++)
        {
            arr.Add(arrr[i]);
        }
        int index;
        for (int i = 0; i < commentSymbols.Length; i++)
        {
            for (int j = 0; j < arr.Count; j++)
            {
                index = arr[j].IndexOf(commentSymbols[i]);
                if (index != -1)
                {
                    if (index > 0)
                        arr[j] = arr[j].Substring(0, index);
                    else
                        arr[j] = string.Empty;
                }
            }
        }
        string req = "";
        for (int i = 0; i < arr.Count; i++)
        {
            arr[i] = arr[i].TrimEnd();
        }

        for (int i = arr.Count - 1; i >= 0; i--)
        {
            if (arr[i].Length == 0)
            {
                arr.RemoveAt(i);
            }
        }

        for (int i = 0; i < arr.Count; i++)
        {
            if (i != arr.Count - 1)
            {
                req += arr[i] + "\n";
            }
            else
            {
                req += arr[i];
            }
        }

        return req;
    }
}

