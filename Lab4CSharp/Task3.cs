using System;
using System.Collections.Generic;

namespace Lab_4
{
    // 1. СТРУКТУРА (Struct)
    
    public struct InfoStruct
    {
        public string Carrier;
        public double Size;
        public string Title;
        public string Author;

        public InfoStruct(string carrier, double size, string title, string author)
        {
            Carrier = carrier;
            Size = size;
            Title = title;
            Author = author;
        }

        public void Print()
        {
            Console.WriteLine($"[Структура] Носій: {Carrier,-10} | Обсяг: {Size,5} ГБ | Назва: {Title,-15} | Автор: {Author}");
        }
    }

    
    // 2. ЗАПИС (Record)
    
    public record InfoRecord(string Carrier, double Size, string Title, string Author)
    {
        public void Print()
        {
            Console.WriteLine($"[Запис]     Носій: {Carrier,-10} | Обсяг: {Size,5} ГБ | Назва: {Title,-15} | Автор: {Author}");
        }
    }

    public class Task3Runner
    {
        
        // ВАРІАНТ 1: Використання СТРУКТУР
        
        public static void RunStructVariant()
        {
            Console.WriteLine("\n РОБОТА ЗІ СТРУКТУРАМИ ");
            List<InfoStruct> list = new List<InfoStruct>
            {
                new InfoStruct("Флешка", 32.0, "Мої документи", "Іваненко"),
                new InfoStruct("HDD", 1024.0, "Архів фото", "Петренко"),
                new InfoStruct("SSD", 512.0, "Ігри", "Сидоренко")
            };

            PrintList(list);

            // 1. Видалити перший елемент із заданим обсягом
            Console.Write("\nВведіть обсяг (ГБ) для видалення першого збігу: ");
            if (double.TryParse(Console.ReadLine(), out double targetSize))
            {
                int indexToRemove = list.FindIndex(x => x.Size == targetSize);
                if (indexToRemove != -1)
                {
                    list.RemoveAt(indexToRemove);
                    Console.WriteLine("Елемент успішно видалено.");
                }
                else
                {
                    Console.WriteLine("Елемент з таким обсягом не знайдено.");
                }
            }

            // 2. Додати елемент перед елементом із зазначеним номером (індексом)
            Console.Write("Введіть номер (індекс від 0), перед яким додати новий елемент: ");
            if (int.TryParse(Console.ReadLine(), out int insertIndex) && insertIndex >= 0 && insertIndex <= list.Count)
            {
                InfoStruct newItem = new InfoStruct("CD-ROM", 0.7, "Музика", "Невідомий");
                list.Insert(insertIndex, newItem);
                Console.WriteLine("Новий елемент успішно додано.");
            }
            else
            {
                Console.WriteLine("Некоректний індекс.");
            }

            Console.WriteLine("\nОновлений масив:");
            PrintList(list);
        }

        
        // ВАРІАНТ 2: Використання КОРТЕЖІВ (Tuples)
        
        public static void RunTupleVariant()
        {
            Console.WriteLine("\n РОБОТА З КОРТЕЖАМИ ");
            // Кортеж: (string Carrier, double Size, string Title, string Author)
            List<(string Carrier, double Size, string Title, string Author)> list = new List<(string, double, string, string)>
            {
                ("Флешка", 32.0, "Мої документи", "Іваненко"),
                ("HDD", 1024.0, "Архів фото", "Петренко"),
                ("SSD", 512.0, "Ігри", "Сидоренко")
            };

            PrintTuples(list);

            // 1. Видалити перший елемент із заданим обсягом
            Console.Write("\nВведіть обсяг (ГБ) для видалення першого збігу: ");
            if (double.TryParse(Console.ReadLine(), out double targetSize))
            {
                int indexToRemove = list.FindIndex(x => x.Size == targetSize);
                if (indexToRemove != -1)
                {
                    list.RemoveAt(indexToRemove);
                    Console.WriteLine("Елемент успішно видалено.");
                }
                else
                {
                    Console.WriteLine("Елемент з таким обсягом не знайдено.");
                }
            }

            // 2. Додати елемент перед елементом із зазначеним номером
            Console.Write("Введіть номер (індекс від 0), перед яким додати новий елемент: ");
            if (int.TryParse(Console.ReadLine(), out int insertIndex) && insertIndex >= 0 && insertIndex <= list.Count)
            {
                var newItem = ("CD-ROM", 0.7, "Музика", "Невідомий");
                list.Insert(insertIndex, newItem);
                Console.WriteLine("Новий елемент успішно додано.");
            }
            else
            {
                Console.WriteLine("Некоректний індекс.");
            }

            Console.WriteLine("\nОновлений масив:");
            PrintTuples(list);
        }

        
        // ВАРІАНТ 3: Використання ЗАПИСІВ (Records)
        
        public static void RunRecordVariant()
        {
            Console.WriteLine("\nРОБОТА ІЗ ЗАПИСАМИ ");
            List<InfoRecord> list = new List<InfoRecord>
            {
                new InfoRecord("Флешка", 32.0, "Мої документи", "Іваненко"),
                new InfoRecord("HDD", 1024.0, "Архів фото", "Петренко"),
                new InfoRecord("SSD", 512.0, "Ігри", "Сидоренко")
            };

            PrintList(list);

            // 1. Видалити перший елемент із заданим обсягом
            Console.Write("\nВведіть обсяг (ГБ) для видалення першого збігу: ");
            if (double.TryParse(Console.ReadLine(), out double targetSize))
            {
                int indexToRemove = list.FindIndex(x => x.Size == targetSize);
                if (indexToRemove != -1)
                {
                    list.RemoveAt(indexToRemove);
                    Console.WriteLine("Елемент успішно видалено.");
                }
                else
                {
                    Console.WriteLine("Елемент з таким обсягом не знайдено.");
                }
            }

            // 2. Додати елемент перед елементом із зазначеним номером
            Console.Write("Введіть номер (індекс від 0), перед яким додати новий елемент: ");
            if (int.TryParse(Console.ReadLine(), out int insertIndex) && insertIndex >= 0 && insertIndex <= list.Count)
            {
                InfoRecord newItem = new InfoRecord("CD-ROM", 0.7, "Музика", "Невідомий");
                list.Insert(insertIndex, newItem);
                Console.WriteLine("Новий елемент успішно додано.");
            }
            else
            {
                Console.WriteLine("Некоректний індекс.");
            }

            Console.WriteLine("\nОновлений масив:");
            PrintList(list);
        }

        // --- Допоміжні методи для виводу списків ---
        private static void PrintList(List<InfoStruct> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"[{i}] ");
                list[i].Print();
            }
        }

        private static void PrintList(List<InfoRecord> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"[{i}] ");
                list[i].Print();
            }
        }

        private static void PrintTuples(List<(string Carrier, double Size, string Title, string Author)> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                Console.WriteLine($"[{i}] [Кортеж]  Носій: {item.Carrier,-10} | Обсяг: {item.Size,5} ГБ | Назва: {item.Title,-15} | Автор: {item.Author}");
            }
        }
    }
}