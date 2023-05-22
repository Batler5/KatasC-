
        public class MorseCodeDecoder
{
   public static string DecodeBits(string bits)
        {
     Console.WriteLine(bits);
          for (int i = 0; i < 1; i++)
            {
                if (bits[i].ToString() == "0")
                {
                    bits = bits.Substring(0, i) + bits.Substring(i + 1);
                    i--;
                }
            }
            string bits2 = "";
            for (int i = bits.Length-1; i >= 0; i--)
            {
                bits2 += bits[i];
            }
            
            for (int i = 0; i < 1; i++)
            {
                if (bits2[i].ToString() == "0")
                {
                    bits2 = bits2.Substring(0, i) + bits2.Substring(i + 1);
                    i--;
                }
            }
            bits = "";
            for (int i = bits2.Length - 1; i >= 0; i--)
            {
                bits += bits2[i];
            }
            int min = 9999;
            string[] NN = bits.Split(new[] { "0" }, StringSplitOptions.None);
            for (int i = 0; i < NN.Length; i++)
            {
                if (NN[i].Length<min && NN[i].Length!=0) { min = NN[i].Length; }
            }
            NN = bits.Split(new[] { "1" }, StringSplitOptions.None);
            for (int i = 0; i < NN.Length; i++)
            {
                if (NN[i].Length<min && NN[i].Length!=0) { min = NN[i].Length; }
            }
            string Space = "";
            for (int i = 0; i < min*7; i++)
            {
                Space += "0";
            }
            string newStr = "";
            string[] slowa = bits.Split(new[] { Space }, StringSplitOptions.None);
            List<string> lates = new List<string>();
            string[] laters = new string[] { };
            string word = "";
            for (int i = 0; i < min*3; i++)
            {
                word += "0";
            }
            for (int i = 0; i < slowa.Length; i++)
            {
                {
                    laters = slowa[i].Split(new[] { word }, StringSplitOptions.None);
                    for (int j = 0; j < laters.Length; j++)
                    {
                        lates.Add(laters[j]);
                    }
                    lates.Add("Space");
                }
            }
            lates.RemoveAt(lates.Count - 1);
            List<string> symbols = new List<string>();
            string elements = "";
            for (int i = 0; i < min; i++)
            {
                elements += "0";
            }
            foreach (string i in lates)
            {
                for (int j = 0; j < i.Split(new[] { elements }, StringSplitOptions.None).Length; j++)
                {
                    symbols.Add(i.Split(new[] { elements }, StringSplitOptions.None)[j].ToString());
                }
                symbols.Add(" ");
            }
            switch (min)
            {
                case 1:
                    foreach (string item in symbols)
                    {
                        switch (item)
                        {
                            case "111": newStr += "-"; break;
                            case "1": newStr += "."; break;
                            case " ": newStr += " "; break;
                            case "Space": newStr += "   "; break;
                           // default: newStr += "."; break;
                        }
                    } break;
                case 2:
                    foreach (string item in symbols)
                    {
                        switch (item)
                        {
                            case "111111": newStr += "-"; break;
                            case "11": newStr += "."; break;
                            case " ": newStr += " "; break;
                            case "Space": newStr += "   "; break;
                            default: newStr += "."; break;
                        }
                    }; break;
                case 3:
                    foreach (string item in symbols)
                    {
                        switch (item)
                        {
                            case "111111111": newStr += "-"; break;
                            case "111": newStr += "."; break;
                            case " ": newStr += " "; break;
                            case "Space": newStr += "   "; break;
                            default: newStr += "."; break;
                        }
                    }break;
                 case 4:
                    foreach (string item in symbols)
                    {
                        switch (item)
                        {
                            case "111111111111": newStr += "-"; break;
                            case "1111": newStr += "."; break;
                            case " ": newStr += " "; break;
                            case "Space": newStr += "   "; break;
                            default: newStr += "."; break;
                        }
                    }
                    break;
                case 5:
                    foreach (string item in symbols)
                    {
                        switch (item)
                        {
                            case "111111111111111": newStr += "-"; break;
                            case "11111": newStr += "."; break;
                            case " ": newStr += " "; break;
                            case "Space": newStr += "   "; break;
                            default: newStr += "."; break;
                        }
                    }
                    break;
                default: newStr += "."; break;
            }
            System.Console.WriteLine(DecodeMorse(newStr));
            return newStr;
        }

   public static string DecodeMorse(string morseCode)
        {
            string newStr = "";
            string[] slowa = morseCode.Split(new string[] { "   " }, StringSplitOptions.None);

            for (int i = 0; i < slowa.Length; i++)
            {
                string[] bukva = slowa[i].Split(' ');

                for (int j = 0; j < bukva.Length; j++)
                {
                    switch (bukva[j])
                    {
                        case ".-": newStr += "A"; break;
                        case "-...": newStr += "B"; break;
                        case "-.-.": newStr += "C"; break;
                        case "-..": newStr += "D"; break;
                        case ".": newStr += "E"; break;
                        case "..-.": newStr += "F"; break;
                        case "--.": newStr += "G"; break;
                        case "....": newStr += "H"; break;
                        case "..": newStr += "I"; break;
                        case ".---": newStr += "J"; break;
                        case "-.-": newStr += "K"; break;
                        case ".-..": newStr += "L"; break;
                        case "--": newStr += "M"; break;
                        case "-.": newStr += "N"; break;
                        case "---": newStr += "O"; break;
                        case ".--.": newStr += "P"; break;
                        case "--.-": newStr += "Q"; break;
                        case ".-.": newStr += "R"; break;
                        case "...": newStr += "S"; break;
                        case "-": newStr += "T"; break;
                        case "..-": newStr += "U"; break;
                        case "...-": newStr += "V"; break;
                        case ".--": newStr += "W"; break;
                        case "-..-": newStr += "X"; break;
                        case "-.--": newStr += "Y"; break;
                        case "--..": newStr += "Z"; break;
                    }
                }
                if (newStr != "" && i != slowa.Length-1) { newStr += " "; }
            }
            if (slowa.Length >= 9) { newStr += "."; }
            return newStr;
        }
}
        class katas
        {
            //Console.WriteLine(GetReadableTime(0));
        public static string GetReadableTime(int seconds)
            {
                string time = "";
                int sec = seconds % 60; int min = (seconds / 60) % 60; int hours = seconds / 3600 ;
                if (hours < 10) { time += "0" + hours + ":"; } else { time += hours + ":"; }
                if (min < 10) { time += "0" + min + ":"; } else { time += min + ":"; }
                if (sec < 10) { time += "0" + sec ; } else { time += sec; }
                return time;
            }
        public static long IpsBetween(string start, string end)
   {
        long otv =0;
        string [] first = start.Split('.');
        string[] second = end.Split(".");
        for (int i = 0; i< 4; i++)
        {
            long diff = Convert.ToInt64(second[i]) - Convert.ToInt64(first[i]);
            switch(i)
            {
                case 0: otv += diff * (256 * 256 * 256); break;
                case 1: otv += diff * (256 * 256); break;
                case 2: otv += diff * 256; break;
                default: otv += diff; break;
            }
        }            
        return otv;
   }

                
        public static string Decode(string morseCode)
        {
            string newStr = "";
            string[] slowa = morseCode.Split(new string[] { "   " }, StringSplitOptions.None);

            for (int i = 0; i < slowa.Length; i++)
            {
                string bukva2 = "";
                string[] bukva = slowa[i].Split(' ');
                for (int j = 0; j < bukva.Length; j++)
                {
                    bukva2 = bukva[j];
                    switch (bukva2)
                    {
                        case ".-": newStr += "A"; break;
                        case "-...": newStr += "B"; break;
                        case "-.-.": newStr += "C"; break;
                        case "-..": newStr += "D"; break;
                        case ".": newStr += "E"; break;
                        case "..-.": newStr += "F"; break;
                        case "--.": newStr += "G"; break;
                        case "....": newStr += "H"; break;
                        case "..": newStr += "I"; break;
                        case ".---": newStr += "J"; break;
                        case "-.-": newStr += "K"; break;
                        case ".-..": newStr += "L"; break;
                        case "--": newStr += "M"; break;
                        case "-.": newStr += "N"; break;
                        case "---": newStr += "O"; break;
                        case ".--.": newStr += "P"; break;
                        case "--.-": newStr += "Q"; break;
                        case ".-.": newStr += "R"; break;
                        case "...": newStr += "S"; break;
                        case "-": newStr += "T"; break;
                        case "..-": newStr += "U"; break;
                        case "...-": newStr += "V"; break;
                        case ".--": newStr += "W"; break;
                        case "-..-": newStr += "X"; break;
                        case "-.--": newStr += "Y"; break;
                        case "--..": newStr += "Z"; break;
                        case "...---...":
                            if (i + 1 < slowa.Length) { newStr += "SOS!"; break; } else { newStr += "SOS"; break; }
                    }
                }
                if (newStr != "") { newStr += " "; }

            }
            newStr = newStr.Remove(newStr.Length - 1);
            if (slowa.Length > 9) { newStr += "."; }
            return newStr;
        }
        public static IEnumerable<string> FriendOrFoe(string[] names)
        {
            List<string> MyFriends = new List<string>();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Length == 4)
                {
                    MyFriends.Add(names[i]);
                }
            }
            return MyFriends;
        }
        public static bool Solution(string str, string ending)
        {
            if (ending.Length > str.Length) { return false; }
            for (int i = 1; i <= ending.Length; i++)
            {
                       if (str[str.Length-i] != ending[ending.Length-i])
                       {
                           return false;
                       } 
            }
            return true;
        }
        public static string ToCamelCase(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == "-" || str[i].ToString() == "_")
                {
                    str = str.Remove(i, 1).Insert(i, "");

                    char Symbol = char.ToUpper(Convert.ToChar(str[i]));
                    str = str.Remove(i, 1).Insert(i, Symbol.ToString());
                   // i++;
                }
            }
            return str;
        }
        //Console.WriteLine(Maskify("werwer"));
        public static string Maskify(string cc)
        {
            char[] newS = cc.ToCharArray();
            foreach (char c in newS)
            {
                Console.WriteLine(c);
            }
            for (int i = 0; i < newS.Length - 4; i++)
            {
                newS[i] = '#';
            }
            return String.Join("", newS);
        }    
        public static int[] ArrayDiff(int[] a, int[] b) 
        {
            int[] abc = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (b.Contains(a[i]))
                {
                    int j = i;
                    while (j < a.Length - 1)
                    {
                        a[j] = a[j + 1];
                        j++;
                    }
                    Array.Resize(ref a, a.Length - 1);
                    i--;
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            return a;
        }
        public static int[] ArrayDiff2(int[] a, int[] b)
        {
            List<int> result = new List<int>();
            bool alreadyIn;
            for (int i = 0; i < a.Length; i++)
            {
                alreadyIn = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                        alreadyIn = true;
                }

                if (!alreadyIn)
                    result.Add(a[i]);
            }

            return result.ToArray();
        }
        }
        