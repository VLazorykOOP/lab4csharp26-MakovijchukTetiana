using System;
using System.Globalization;

namespace Lab_4
{
    // Створюємо власний клас Date
    class Date : IComparable<Date>
    {
        // Захищені поля
        protected int day;
        protected int month;
        protected int year;

        public override string ToString()
        {
            return $"{day:D2}.{month:D2}.{year:D4}";
        }
        // Властивості з базовою перевіркою
        public int Day
        {
            get { return day; }
            set 
            { 
                if (value >= 1 && value <= 31) day = value; 
                else Console.WriteLine("Помилка: День має бути від 1 до 31.");
            }
        }

        public int Month
        {
            get { return month; }
            set 
            { 
                if (value >= 1 && value <= 12) month = value; 
                else Console.WriteLine("Помилка: Місяць має бути від 1 до 12.");
            }
        }

        public int Year
        {
            get { return year; }
            set 
            { 
                if (value > 0) year = value; 
                else Console.WriteLine("Помилка: Рік має бути додатнім числом.");
            }
        }

        // Властивість для отримання століття (тільки для читання)
        public int Century
        {
            get { return (year - 1) / 100 + 1; }
        }

        // Конструктор
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        

        // 1. Індексатор: дозволяє визначити дату i-того дня щодо встановленої дати
        public Date this[int i]
        {
            get
            {
                // Використовуємо вбудований клас DateTime для точного розрахунку днів та високосних років
                DateTime dt = new DateTime(year, month, day).AddDays(i);
                return new Date(dt.Day, dt.Month, dt.Year);
            }
        }

        // 2. Перевантаження операції !: true, якщо дата НЕ є останнім днем місяця
        public static bool operator !(Date d)
        {
            int daysInMonth = DateTime.DaysInMonth(d.year, d.month);
            return d.day != daysInMonth;
        }

        // 3. Перевантаження сталих true і false: true, якщо дата є початком року (1 січня)
        public static bool operator true(Date d)
        {
            return d.day == 1 && d.month == 1;
        }

        public static bool operator false(Date d)
        {
            return d.day != 1 || d.month != 1;
        }

        // 4. Перевантаження операції &: true, якщо поля двох об'єктів рівні
        public static bool operator &(Date d1, Date d2)
        {
            if (ReferenceEquals(d1, null) || ReferenceEquals(d2, null)) return false;
            return d1.day == d2.day && d1.month == d2.month && d1.year == d2.year;
        }

        // 5. Перетворення типу Date у тип string (неявне перетворення)
        public static implicit operator string(Date d)
        {
            return $"{d.day:D2}.{d.month:D2}.{d.year:D4}";
        }

        // 6. Перетворення типу string у тип Date (явне перетворення)
        public static explicit operator Date(string s)
        {
            if (DateTime.TryParseExact(s, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                return new Date(dt.Day, dt.Month, dt.Year);
            }
            throw new ArgumentException("Помилка: Невірний формат рядка. Очікується 'ДД.ММ.РРРР'.");
        }

        

        public bool IsValidDate()
        {
            if (year < 1 || month < 1 || month > 12 || day < 1 || day > 31)
                return false;

            int[] daysInMonths = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            bool isLeap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
            if (isLeap) daysInMonths[2] = 29;

            return day <= daysInMonths[month];
        }

        public void PrintTextFormat()
        {
            string monthName = month switch
            {
                1 => "січня", 2 => "лютого", 3 => "березня", 4 => "квітня",
                5 => "травня", 6 => "червня", 7 => "липня", 8 => "серпня",
                9 => "вересня", 10 => "жовтня", 11 => "листопада", 12 => "грудня",
                _ => "невідомого місяця"
            };
            Console.WriteLine($"{day} {monthName} {year} року");
        }

        public void PrintNumberFormat()
        {
            Console.WriteLine((string)this); // Використовуємо нове перетворення у string
        }

        private int GetAbsoluteDays()
        {
            int totalDays = day;
            int[] daysInMonths = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            for (int y = 1; y < year; y++)
                totalDays += (y % 4 == 0 && (y % 100 != 0 || y % 400 == 0)) ? 366 : 365;

            bool isLeap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
            if (isLeap) daysInMonths[2] = 29;

            for (int m = 1; m < month; m++)
                totalDays += daysInMonths[m];

            return totalDays;
        }

        public int DaysBetween(Date otherDate)
        {
            return Math.Abs(this.GetAbsoluteDays() - otherDate.GetAbsoluteDays());
        }

        public int CompareTo(Date other)
        {
            if (other == null) return 1;
            return this.GetAbsoluteDays().CompareTo(other.GetAbsoluteDays());
        }
    }
}