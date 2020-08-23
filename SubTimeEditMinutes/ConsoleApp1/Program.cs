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
            Regex regex = new Regex(@"\d{1}:+\d{2}:+\d{2}\.+\d{2}");

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
            //1:11 - 26 = 43 0:00:27.42
            int hour = int.Parse(input[0].ToString());
            int minute = int.Parse(input[2].ToString() + input[3]);
            int second = int.Parse(input[5].ToString() + input[6]);
            int milisecond = int.Parse(input[8].ToString() + input[9]);

            for (int i = 1; i <= 43; i++)
            {
                if (second < 60)
                {
                    second += 1;
                }
                else
                {
                    second = 0;
                }

                if (second == 60)
                {
                    second = 0;
                    if (minute < 60)
                    {
                        minute += 1;
                    }

                    if (minute == 60)
                    {
                        minute = 0;
                        hour++;
                    }
                }
            }

            string hh = "0" + hour;

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
            string mlss = milisecond.ToString();
            if (milisecond < 10)
            {
                mlss = "0" + milisecond;
            }

            return hh + ":" + mm + ":" + ss + "." + mlss;
        }
    }
}
