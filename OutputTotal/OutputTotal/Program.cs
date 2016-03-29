using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputTotal
{
    class Program
    {
        static float IsNumber(string data) //функции для проверки введенных данных на число
        {
            float number = default(float);

            if (float.TryParse(data, out number))         
            {
                return number;
            }

            Console.WriteLine("Некорректный ввод. Введите, пожалуйста, число:");

            string newData = Console.ReadLine();
            float repeat = IsNumber(newData);
            return repeat;
        }
        
        static void Main()
        {        
            Console.WriteLine("Введите сумму от 0 до 1000000 в формате XXXXXXX,XX:");

            string number = Console.ReadLine();

            float a = IsNumber(number); //вызов функции для проверки введенных данных на число

            double integer = Math.Floor(a);
            //double integer = Math.Truncate(a);
            double fraction = Math.Round((a - integer + 0.001) * 100); //представило 13 копеек, как 12.49 копеек
            int x = Convert.ToInt32(integer);     
            
            //int[] array_int = new int[4];
            //string[,] array_string = new string[4, 3]
            
            int[] array_int = new int[3];
            string[,] array_string = new string[3, 3]
            
            {
                //{"миллиард ", "миллиарда ", "миллиардов "},
                {"миллион ", "миллиона ", "миллионов "},
                {"тысяча ", "тысячи ", "тысяч "},
                {"", "", ""}
            };
                        
            array_int[0] = ((x % 1000000000) - (x % 1000000)) / 1000000;
            array_int[1] = ((x % 1000000) - (x % 1000)) / 1000;
            array_int[2] = x % 1000; 
            
            //array_int[0] = (x - (x % 1000000000)) / 1000000000;
            //array_int[1] = ((x % 1000000000) - (x % 1000000)) / 1000000;
            //array_int[2] = ((x % 1000000) - (x % 1000)) / 1000;
            //array_int[3] = x % 1000;
            
            string result = "";

            for (int i = 0; i < 3; i++)
            //for (int i = 0; i < 4; i++)
            {
                if (array_int[i] != 0)
                {
                    if (((array_int[i] - (array_int[i] % 100)) / 100) != 0)
                        switch (((array_int[i] - (array_int[i] % 100)) / 100))
                        {
                            case 1: result += "сто "; break;
                            case 2: result += "двести "; break;
                            case 3: result += "триста "; break;
                            case 4: result += "четыреста "; break;
                            case 5: result += "пятьсот "; break;
                            case 6: result += "шестьсот "; break;
                            case 7: result += "семьсот "; break;
                            case 8: result += "восемьсот "; break;
                            case 9: result += "девятьсот "; break;
                        }
                    if (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 != 1)
                    {
                        switch (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10)
                        {
                            case 2: result += "двадцать "; break;
                            case 3: result += "тридцать "; break;
                            case 4: result += "сорок "; break;
                            case 5: result += "пятьдесят "; break;
                            case 6: result += "шестьдесят "; break;
                            case 7: result += "семьдесят "; break;
                            case 8: result += "восемьдесят "; break;
                            case 9: result += "девяносто "; break;
                        }
                        switch (array_int[i] % 10)
                        {
                            case 1: result += "одна "; break;
                            case 2: result += "две "; break;
                            case 3: result += "три "; break;
                            case 4: result += "четыре "; break;
                            case 5: result += "пять "; break;
                            case 6: result += "шесть "; break;
                            case 7: result += "семь "; break;
                            case 8: result += "восемь "; break;
                            case 9: result += "девять "; break;
                        }
                    }
                    else switch (array_int[i] % 100)
                        {
                            case 10: result += "десять "; break;
                            case 11: result += "одинадцать "; break;
                            case 12: result += "двенадцать "; break;
                            case 13: result += "тринадцать "; break;
                            case 14: result += "четырнадцать "; break;
                            case 15: result += "пятнадцать "; break;
                            case 16: result += "шестнадцать "; break;
                            case 17: result += "семнадцать "; break;
                            case 18: result += "восемнадцать "; break;
                            case 19: result += "девятнадцать "; break;
                        }                       
                }

                if (array_int[i] % 100 >= 10 && array_int[i] % 100 <= 19) result += array_string[i, 2];
                else switch (array_int[i] % 10)
                    {
                        case 1: result += array_string[i, 0]; break;
                        case 2:
                        case 3:
                        case 4: result += array_string[i, 1]; break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9: result += array_string[i, 2]; break;
                    }
            }
            Console.WriteLine("{0}грн. {1} коп.", result, fraction);

            Console.ReadKey();
        }
    }
}
