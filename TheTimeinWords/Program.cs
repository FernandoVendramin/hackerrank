using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static string[] numberUnits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] number10 = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] numberTeens = new string[] { "twenty", "thirty", "forty" };

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int h = Convert.ToInt32(Console.ReadLine());

            int m = Convert.ToInt32(Console.ReadLine());

            string result = timeInWords(h, m);

            //Console.WriteLine(result);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }

        // Complete the timeInWords function below.
        static string timeInWords(int h, int m)
        {
            if (h > 12 || h < 1)
                return "Invalid hour";

            var hour = getNumberTextHour(h);

            if (m > 59 || m < 0)
                return "Invalid minute";

            if (m == 0)
                return $"{hour} o' clock";

            if (m == 45)
            {
                hour = getNumberTextHour(h + 1);
                return $"quarter to {hour}";
            }

            var minute = "";
            if (m > 30)
            {
                minute = getNumberText(60 - m);
                hour = getNumberTextHour(h + 1);
                return $"{minute} minutes to {hour}";
            }

            if (m == 15)
                return $"quarter past {hour}";

            if (m == 30)
                return $"half past {hour}";

            if (m < 30)
            {
                minute = getNumberText(m);
                return $"{minute} { (m < 10 ? "minute" : "minutes") } past {hour}";
            }

            minute = getNumberText(m);

            return $"{hour} {minute}";
        }


        static string getNumberTextHour(int intNumber)
        {
            var stringValue = getNumberText(intNumber); stringValue = (stringValue == "thirteen" ? "one" : stringValue);

            return stringValue;
        }

        static string getNumberText(int intNumber)
        {
            if (intNumber < 20)
                return getNumberTextFewerThan20(intNumber);

            if (intNumber == 45)
                return "quarter";

            var numberText = "";
            var intList = getIntList(intNumber);

            numberText = numberTeens[intList[0] - 2];
            if (intList[1] > 0)
                numberText += $" {getNumberTextFewerThan20(intList[1])}";

            return numberText.Trim();
        }

        static string getNumberTextFewerThan20(int intNumber)
        {
            if (intNumber < 10)
                return numberUnits[intNumber];

            if (intNumber >= 10 && intNumber < 20)
                return number10[intNumber - 10];

            return "invalid";
        }

        static List<int> getIntList(int intNumber)
        {
            List<int> intList = new List<int>();
            var stringValue = intNumber.ToString();
            for (int i = 0; i < stringValue.Length; i++)
            {
                intList.Add(Convert.ToInt32(stringValue.Substring(i, 1)));
            }

            return intList;
        }
    }
}
