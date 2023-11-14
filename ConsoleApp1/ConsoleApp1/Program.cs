// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


Console.WriteLine(InsertNumberIntoAnother(2728, 655, 3, 8));

static string InsertNumberIntoAnother(int destinationNumber, int sourceNumber, int i, int j)
{
    if (i == 32 || i == -1)
    {
        throw new ArgumentOutOfRangeException(nameof(i));
    }

    if (j == 32)
    {
        throw new ArgumentOutOfRangeException(nameof(j));
    }

    if (i > j)
    {
        throw new ArgumentException("i more than j.");
    }

    int ind = j - i + 1;
    string sourceNumBinary = NumOnBinary(sourceNumber);
    string destNumBinary = NumOnBinary(destinationNumber);
    StringBuilder bitsSource = new StringBuilder();
    StringBuilder bitsDest = new StringBuilder();
    for (int a = 0; a < ind; a++)
    {
        bitsSource.Insert(0, sourceNumBinary[sourceNumBinary.Length - a - 1]);
    }

    for (int a = 0; a < 32; a++)
    {
        bitsDest.Append(destNumBinary[a]);
    }

    return bitsDest.ToString();
}

static string NumOnBinary(int number)
{
    bool temp = number >= 0;
    StringBuilder rez = new StringBuilder();

    while (number != 0)
    {
        if (number % 2 == 0)
        {
            rez.Insert(0, "0");
            number /= 2;
        }
        else
        {
            rez.Insert(0, "1");
            number /= 2;
        }
    }

    return temp ? rez.ToString().PadLeft(32, '0') : rez.ToString().PadLeft(32, '1');
}

// Console.WriteLine(GetCharsCount("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'c', 'd', 'l', 'm' }, 1, 16, 7));
// Console.ReadLine();

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


// Console.WriteLine(StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples\n   \nasd", new string[] { "#", "!" }));
// Console.ReadLine();
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

