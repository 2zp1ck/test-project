using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundomNumber
{
    class Program
    {
        static float IsNumber(string data) //функции для проверки корректности введенных данных (число и попадание в диапазон)
        {        
            float number = default(float);

            if (float.TryParse(data, out number)/*&& number > 0 && number < 101*/) //преобразование строки в число и проверка на заданный диапазон
            {                
                return number;
            }

            Console.WriteLine("Некорректный ввод. Введите, пожалуйста, число от 1 до 100:");

            string newData = Console.ReadLine();
            float repeat = IsNumber(newData);
            return repeat;
        }        
        
        static float Guess (float data, int rundom, int attempt) //функция сравнения введенного числа со значением Random
        {
            attempt++; //счетчик попыток
                        
            if (data == rundom)          
            {                
                Console.Write("Правильно! Поздравляю! Вы угадали с {0} раза.", attempt);                         
                return rundom;
            }
            else if (data > rundom)
            {
                Console.WriteLine("Не угадали! Я загадал число поменьше! Попробуйте еще раз:");
                string newData = Console.ReadLine();
                float repeatNumber = IsNumber(newData);
                float repeatGuess = Guess(repeatNumber, rundom, attempt);
                return repeatGuess;
            }
            else
            {
                Console.WriteLine("Не угадали! Я загадал число побольше! Попробуйте еще раз:");
                string newData = Console.ReadLine();
                float repeatNumber = IsNumber(newData);
                float repeatGuess = Guess(repeatNumber, rundom, attempt);
                return repeatGuess;                
            }            
        }
        
        static void Main()
        {
            Random rand = new Random();
            int x = rand.Next(1, 101);
            Console.WriteLine(x);
            
            int call = 0;

            Console.WriteLine("Угадайте число от 1 до 100, которое я загадал:");            

            string number = Console.ReadLine();
            float a = IsNumber(number);
                        
            float b = Guess(a, x, call);                      

            Console.ReadKey();
        }
    }
}
