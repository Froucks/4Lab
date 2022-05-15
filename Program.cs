using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace fourLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers;
            Console.WriteLine("Введите число элементов в массиве: "); 
            countNumbers = Convert.ToInt32(Console.ReadLine()); 

            int[] mainArray = new int[countNumbers];

            Random rand = new Random(); //Заполняем массив случайными числами
            for (int i = 0; i < countNumbers; i++)
            {
                mainArray[i] = rand.Next(100000);

            }
            if (countNumbers <= 1000) // Не выводим в консоль больше 1000 элементов
            {
                for (int i = 0; i < countNumbers; i++)
                {
                    Console.WriteLine(mainArray[i]);
                }
            }

            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;

            int typeOfOperation = -1;

            while (typeOfOperation != 0)
            {
                Console.WriteLine("Введите номер операции:\n" +
                                  "1 - LINQ | Найти все четные числа\n" +
                                  "2 - PLINQ | Найти все четные числа\n" +
                                  "3 - LINQ | Найти все НЕ четные числа\n" +
                                  "4 - PLINQ | Найти все НЕ четные числа\n" +
                                  "5 - LINQ | Найти все числа, сумма первой и последней цифры которых равна 6\n" +
                                  "6 - PLINQ | Найти все числа, сумма первой и последней цифры которых равна 6\n" +
                                  "7 - LINQ| Найти все числа, содержащие комбинацию цифр: 666\n" +
                                  "8 - PLINQ| Найти все числа, содержащие комбинацию цифр: 666\n" +
                                  "0 - завершить программу");

                typeOfOperation = Convert.ToInt32(Console.ReadLine());
                int[] resultArray;
                double time;
                Func<int, int, bool> checkTrueSum = (arr, equalsNumber) =>
                {
                    string msg = arr.ToString();
                    if (msg.Length < 3)
                    {
                        return false;
                    }
                    int firstNumber = int.Parse(msg[0].ToString()),
                        lastNumber = int.Parse(msg[^1].ToString());
                    if (firstNumber + lastNumber == equalsNumber)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };

                switch (typeOfOperation) //Операции
                {
                    case 1:
                        stopwatch.Start();
                        resultArray = mainArray.Where(i => i % 2 == 0).OrderBy(i => i).ToArray(); //Отбирает четные - по возрастанию - преобразует в массив
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;                       
                        for (int i = 0; i < 10; i++)
                        {
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;
                    case 2:
                        stopwatch.Start();
                        resultArray = mainArray.AsParallel().Where(i => i % 2 == 0).OrderBy(i => i).ToArray();
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;                       
                        for (int i = 0; i < 10; i++)
                        {
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;

                    case 3:
                        stopwatch.Start();
                        resultArray = mainArray.Where(i => i % 2 == 1).OrderBy(i => i).ToArray();
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;                        
                        for (int i = 0; i < 10; i++)
                        {
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;

                    case 4:
                        stopwatch.Start();
                        resultArray = mainArray.AsParallel().Where(i => i % 2 == 1).OrderBy(i => i).ToArray();
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;
                        
                        for (int i = 0; i < 10; i++)
                        {
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;

                    case 5:
                        stopwatch.Start();
                        resultArray = mainArray.Where(i => checkTrueSum(i, 6)).OrderBy(i => i).ToArray();
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == resultArray.Count()) break;
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;
                    case 6:
                        stopwatch.Start();
                        resultArray = mainArray.AsParallel().Where(i => checkTrueSum(i, 6)).OrderBy(i => i).ToArray();
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == resultArray.Count()) break;
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;

                    case 7:
                        stopwatch.Start();
                        resultArray = mainArray.Select(i => Convert.ToString(i)).Where(i => i.Contains("666")).Select(i => Convert.ToInt32(i)).OrderBy(i => i).ToArray();
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == resultArray.Count()) break;
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;

                    case 8:
                        stopwatch.Start();
                        resultArray = mainArray.AsParallel().Select(i => Convert.ToString(i)).Where(i => i.Contains("666")).Select(i => Convert.ToInt32(i)).OrderBy(i => i).ToArray();
                        stopwatch.Stop();
                        timeSpan = stopwatch.Elapsed;
                        time = timeSpan.TotalMilliseconds;
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == resultArray.Count()) break;
                            System.Console.WriteLine("{0} ", resultArray[i]);
                        }
                        System.Console.WriteLine("=============================================================");
                        System.Console.WriteLine("Времени потрачено - {0} мс", time);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
