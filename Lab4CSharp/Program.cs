using System;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо правильне кодування для коректного відображення української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("  Оберіть завдання ");
                Console.WriteLine("1 - Завдання 1 (Клас Date)");
                Console.WriteLine("2 - Завдання 2 (Клас VectorByte)");
                Console.WriteLine("3 - Завдання 3 (Структури, Кортежі, Записи)");
                Console.WriteLine("0 - Вийти з програми");
                Console.Write("Ваш вибір: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunTask1Tests();
                        break;
                    case "2":
                        RunTask2Tests();
                        break;
                    case "3":
                        RunTask3Menu();
                        break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("\nРоботу завершено. До побачення!");
                        break;
                    default:
                        Console.WriteLine("Невірне введення. Спробуйте ще раз.");
                        break;
                }
            }
        }
        
        // ТЕСТИ ДЛЯ ЗАВДАННЯ 1
        static void RunTask1Tests()
        {
            Console.WriteLine("\n ЗАВДАННЯ 1 (Date) ");
            
            Date currentDate = new Date(15, 8, 2023);
            Console.WriteLine($"Встановлена дата: {(string)currentDate}");
            
            Date dateIn5Days = currentDate[5];
            Console.WriteLine($"Дата через 5 днів : {(string)dateIn5Days}");
            
            Date date10DaysAgo = currentDate[-10];
            Console.WriteLine($"Дата 10 днів тому : {(string)date10DaysAgo}");

            Date lastDay = new Date(31, 10, 2023);
            Console.WriteLine($"\nДата {lastDay}: чи є НЕ останнім днем? -> {(!lastDay)}");

            Date startOfYear = new Date(1, 1, 2024);
            if (startOfYear) Console.WriteLine($"Дата {startOfYear} є початком року (true).");

            Date d1 = new Date(10, 12, 2025);
            Date d2 = new Date(10, 12, 202
            5);
            Console.WriteLine($"\nЧи рівні {d1} та {d2}? -> {(d1 & d2)}");

            string inputStr = "24.08.1991";
            Date parsedDate = (Date)inputStr;
            Console.WriteLine($"string -> Date (явне перетворення): {parsedDate.Day:D2}.{parsedDate.Month:D2}.{parsedDate.Year:D4}");
            
            Console.WriteLine("\nНатисніть Enter, щоб повернутися до головного меню...");
            Console.ReadLine();
        }

        
        // ТЕСТИ ДЛЯ ЗАВДАННЯ 2
        
        static void RunTask2Tests()
        {
            Console.WriteLine("\n  ЗАВДАННЯ 2 (VectorByte) ");
            
            VectorByte v1 = new VectorByte(3, 5); 
            VectorByte v2 = new VectorByte(4, 10); 

            Console.Write("v1: "); v1.Output();
            Console.Write("v2: "); v2.Output();

            Console.WriteLine($"\nЧитаємо v1[1]: {v1[1]}");
            v1[1] = 20;
            Console.WriteLine($"Після зміни v1[1] = 20:");
            v1.Output();
            
            VectorByte vSum = v1 + v2;
            Console.WriteLine("\nСума v1 + v2 (вектор більшого розміру):");
            vSum.Output();

            VectorByte vScalar = v1 * 2;
            Console.WriteLine("\nМноження v1 на скаляр 2:");
            vScalar.Output();

            v1++;
            Console.WriteLine("\nПісля інкременту v1++:");
            v1.Output();

            VectorByte vShift = v1 >> 1;
            Console.WriteLine("\nЗсув v1 вправо на 1 біт (v1 >> 1):");
            vShift.Output();

            VectorByte v3 = new VectorByte(3, 10);
            VectorByte v4 = new VectorByte(3, 10);
            Console.WriteLine($"\nЧи v3 == v4? -> {v3 == v4}");

            Console.WriteLine($"\nЗагалом створено векторів: {VectorByte.GetNumVec()}");
            
            Console.WriteLine("\nНатисніть Enter, щоб повернутися до головного меню...");
            Console.ReadLine();
        }

        
        // ПІДМЕНЮ ДЛЯ ЗАВДАННЯ 3
        
        static void RunTask3Menu()
        {
            bool isTask3Running = true;
            while (isTask3Running)
            {
                Console.WriteLine("\n ПІДМЕНЮ ЗАВДАННЯ 3 ");
                Console.WriteLine("1 - Розв'язок через Структури (struct)");
                Console.WriteLine("2 - Розв'язок через Кортежі (tuple)");
                Console.WriteLine("3 - Розв'язок через Записи (record)");
                Console.WriteLine("0 - Повернутися до головного меню");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task3Runner.RunStructVariant();
                        break;
                    case "2":
                        Task3Runner.RunTupleVariant();
                        break;
                    case "3":
                        Task3Runner.RunRecordVariant();
                        break;
                    case "0":
                        isTask3Running = false;
                        break;
                    default:
                        Console.WriteLine("Невірне введення. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}