using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\d{2}:+\d{2}:+\d{2},+\d{3}");

            Console.OutputEncoding = Encoding.Unicode;

            string filePath = @"C:\Users\dat64\Desktop\sample.txt";

            string text = System.IO.File.ReadAllText(filePath);

            foreach (Match item in regex.Matches(text))
            {
                text = text.Replace(item.ToString(), Loading(item.ToString()));
                System.IO.File.WriteAllText(filePath, text);
            }
            Console.WriteLine("Oke");
            Console.ReadLine();
        }
        static string Loading(string input)
        {
            //01:35:21,600 <=> @"\d{2}:+\d{2}:+\d{2},+\d{3}"
            int hour = int.Parse(input[0].ToString() + input[1]);
            int minute = int.Parse(input[3].ToString() + input[4]);
            int second = int.Parse(input[6].ToString() + input[7]);
            int milisecond = int.Parse(input[9].ToString() + input[10] + input[11]);

            if (second >= 49)
            {
                second -= 49;
            }
            else if (second < 49 && minute > 0)
            {
                int temp = 49 - second;
                minute -= 1;
                second = 60 - temp;
            }
            else if (second < 49 && minute == 0 && hour > 0)
            {
                hour -= 1;
                int temp = 49 - second;
                second = 60 - temp;
                minute = 59;
            }

            string hh = hour.ToString();
            if (hour < 10)
            {
                hh = "0" + hour;
            }
            string mm = minute.ToString();
            if (minute < 10)
            {
                mm = "0" + minute;
            }
            string ss = second.ToString();
            if (second < 10)
            {
                ss = "0" + second;
            }

            return hh + ":" + mm + ":" + ss + "," + milisecond;
        }
    }
}
