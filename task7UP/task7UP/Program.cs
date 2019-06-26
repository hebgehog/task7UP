using System;
using System.Collections.Generic;

namespace task7UP
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                List<List<int>> answer = new List<List<int>>();
                int exponent;
                string vec = InputNumber("Введите вектор:");
                int amount = vec.Length;
                do
                {
                    exponent = Exponenta(amount, true, 0);
                    amount++;
                } while (exponent == 0);
                int dob = Convert.ToInt32(Math.Pow(2, exponent)) - vec.Length;
                List<int> vector = new List<int>();
                for (int i = 0; i < vec.Length; i++)
                    vector.Add((int)Char.GetNumericValue(vec[i]));
                List<int> vector2 = new List<int>();
                for (int i = 0; i < vector.Count; i++)
                    vector2.Add(vector[i]);
                string[,] symbvek = InSymb(vector, exponent);
                PrintArray(symbvek);
                bool sam = Sam(symbvek);
                if (sam)
                {
                    vector.Add(vector[0]);//1
                    answer.Add(vector);
                }
                else
                {
                    vector.Add(0);
                    answer.Add(vector);
                    vector2.Add(1);
                    answer.Add(vector2);
                }
                Show(answer);
                Console.ReadKey();
            } while (true);
        }
        static string[,] InSymb(List<int> vector, int exp)
        {
            char[] symbol = { 'A', 'B', 'C', 'D', 'X', 'Y', 'Z', 'E', 'K', 'L', 'M', 'N', 'P', 'S', 'T', 'W' };
            char[] per = new char[exp];
            for (int count = 0; count < exp; count++)
                per[count] = symbol[count];
            string[,] symbvek = new string[vector.Count + 1, exp + 1];
            for (int count2 = 0; count2 < exp; count2++)
                symbvek[0, count2] = Convert.ToString(per[count2]);
            symbvek[0, exp] = "F";
            for (int count = 1; count < vector.Count + 1; count++)
                symbvek[count, exp] = Convert.ToString(vector[count - 1]);
            for (int count = 1; count < vector.Count + 1; count++)
            {
                string binary = ToBinary(count - 1, exp);
                for (int count2 = 0; count2 < exp; count2++)
                    symbvek[count, count2] = Convert.ToString(binary[count2]);
            }
            return symbvek;
        }
        static bool Sam(string[,] vec)
        {
            bool samodv = true;
            for (int stroka = 1; stroka < vec.GetLength(0) - 1; stroka++)
            {
                bool kofprot = true, fprot = true;
                for (int stroka2 = stroka + 1; stroka2 < vec.GetLength(0); stroka2++)
                {
                    for (int stolb = 0; stolb < vec.GetLength(1) - 1; stolb++)
                        if (vec[stroka, stolb] == vec[stroka2, stolb]) kofprot = false;

                    if (kofprot == true)
                    {
                        if (vec[stroka, vec.GetLength(1) - 1] == vec[stroka2, vec.GetLength(1) - 1])
                        {
                            fprot = false;
                            Console.WriteLine("Функция не самодвойственная");
                            return samodv = false;
                        }
                    }
                }
            }
            Console.WriteLine("Функция самодвойственная");
            return samodv = true;
        }
        static string ToBinary(int Decimal, int exp)
        {
            int BinaryHolder;
            char[] BinaryArray;
            string BinaryResult = "";

            while (Decimal > 0)
            {
                BinaryHolder = Decimal % 2;
                BinaryResult += BinaryHolder;
                Decimal = Decimal / 2;
            }
            while (BinaryResult.Length < exp)
                BinaryResult += "0";
            BinaryArray = BinaryResult.ToCharArray();
            Array.Reverse(BinaryArray);
            BinaryResult = new string(BinaryArray);
            return BinaryResult;
        }
        static void Show(List<List<int>> vector) // 
        {
            Console.WriteLine("Ответ: ");
            foreach (var count in vector)
            {
                foreach (var i in count)
                    Console.Write(i);
                Console.WriteLine();
            }
        }
        static string InputNumber(string name) // проверка введенного числа
        {
            bool ok = true;
            string userInput;
            do
            {
                Console.Write($"{name} ");
                userInput = Console.ReadLine();
                for (int i = 0; i < userInput.Length; i++)
                {
                    if ((userInput[i].ToString() != "0") && (userInput[i].ToString() != "1"))
                    {
                        Console.WriteLine($"Ошибка ввода");
                        ok = false;
                    }
                }
            } while (!ok);
            return userInput;
        }
        static int Exponenta(int a, bool ok, int exponent) //
        {
            for (int count = a; (count > 1) && (ok); count = count / 2)
            {
                if (count % 2 == 0) exponent++;
                else
                {
                    exponent = 0;
                    ok = false;
                }
            }
            return exponent;
        }
        static void PrintArray(string[,] arr) // печать 2 массива 
        {
            if (arr.Length == 0) return;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
