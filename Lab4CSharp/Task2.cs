using System;
using System.Linq;

namespace Lab_4
{
    class VectorByte
    {
        //  ПОЛЯ 
        protected byte[] BArray;
        protected uint n;
        protected int codeError;
        protected static uint num_vec = 0;

        //  КОНСТРУКТОРИ 
        public VectorByte()
        {
            n = 1;
            BArray = new byte[1];
            BArray[0] = 0;
            num_vec++;
        }

        public VectorByte(uint size)
        {
            n = size;
            BArray = new byte[n];
            num_vec++;
        }

        public VectorByte(uint size, byte initValue)
        {
            n = size;
            BArray = new byte[n];
            for (int i = 0; i < n; i++)
            {
                BArray[i] = initValue;
            }
            num_vec++;
        }

        // ДЕСТРУКТОР 
        ~VectorByte()
        {
            Console.WriteLine("Вектор VectorByte було знищено.");
        }

        //  МЕТОДИ 
        public void Input()
        {
            for (uint i = 0; i < n; i++)
            {
                Console.Write($"Введіть елемент [{i}]: ");
                if (byte.TryParse(Console.ReadLine(), out byte val))
                {
                    BArray[i] = val;
                }
                else
                {
                    Console.WriteLine("Помилка вводу. Встановлено 0.");
                    BArray[i] = 0;
                }
            }
        }

        public void Output()
        {
            Console.WriteLine($"Вектор (розмір {n}): [ {string.Join(", ", BArray)} ]");
        }

        public void AssignValue(byte val)
        {
            for (uint i = 0; i < n; i++)
            {
                BArray[i] = val;
            }
        }

        public static uint GetNumVec()
        {
            return num_vec;
        }

        // ВЛАСТИВОСТІ 
        public uint Size
        {
            get { return n; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        //  ІНДЕКСАТОР 
        public byte this[uint index]
        {
            get
            {
                if (index >= n)
                {
                    codeError = -1;
                    return 0;
                }
                codeError = 0;
                return BArray[index];
            }
            set
            {
                if (index >= n)
                {
                    codeError = -1;
                }
                else
                {
                    BArray[index] = value;
                    codeError = 0;
                }
            }
        }

        //  ПЕРЕВАНТАЖЕННЯ: УНАРНІ 
        public static VectorByte operator ++(VectorByte v)
        {
            VectorByte res = new VectorByte(v.n);
            for (uint i = 0; i < v.n; i++)
            {
                res.BArray[i] = (byte)(v.BArray[i] + 1);
            }
            return res;
        }

        public static VectorByte operator --(VectorByte v)
        {
            VectorByte res = new VectorByte(v.n);
            for (uint i = 0; i < v.n; i++)
            {
                res.BArray[i] = (byte)(v.BArray[i] - 1);
            }
            return res;
        }

        public static bool operator true(VectorByte v)
        {
            return v.n != 0 || v.BArray.Any(x => x != 0);
        }

        public static bool operator false(VectorByte v)
        {
            return v.n == 0 && v.BArray.All(x => x == 0);
        }

        public static bool operator !(VectorByte v)
        {
            return v.n != 0;
        }

        public static VectorByte operator ~(VectorByte v)
        {
            VectorByte res = new VectorByte(v.n);
            for (uint i = 0; i < v.n; i++)
            {
                res.BArray[i] = (byte)~v.BArray[i];
            }
            return res;
        }

        //  ДОПОМІЖНІ МЕТОДИ 
        // Ці методи дозволяють не дублювати код у кожному операторі
        private static VectorByte PerformBinaryOperation(VectorByte a, VectorByte b, Func<byte, byte, byte> op)
        {
            uint minSize = Math.Min(a.n, b.n);
            uint maxSize = Math.Max(a.n, b.n);
            VectorByte res = new VectorByte(maxSize);

            // Виконуємо операцію для спільних індексів
            for (uint i = 0; i < minSize; i++)
            {
                res[i] = op(a[i], b[i]);
            }

            // Копіюємо хвіст більшого вектора
            for (uint i = minSize; i < maxSize; i++)
            {
                res[i] = i < a.n ? a[i] : b[i];
            }

            return res;
        }

        private static VectorByte PerformScalarOperation(VectorByte a, byte scalar, Func<byte, byte, byte> op)
        {
            VectorByte res = new VectorByte(a.n);
            for (uint i = 0; i < a.n; i++)
            {
                res[i] = op(a[i], scalar);
            }
            return res;
        }

        //  ПЕРЕВАНТАЖЕННЯ: БІНАРНІ АРИФМЕТИЧНІ 
        
        // Додавання
        public static VectorByte operator +(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x + y));
        }

        public static VectorByte operator +(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => (byte)(x + y));
        }

        // Віднімання
        public static VectorByte operator -(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x - y));
        }

        public static VectorByte operator -(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => (byte)(x - y));
        }

        // Множення
        public static VectorByte operator *(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x * y));
        }

        public static VectorByte operator *(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => (byte)(x * y));
        }

        // Ділення
        public static VectorByte operator /(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => y == 0 ? (byte)0 : (byte)(x / y));
        }

        public static VectorByte operator /(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => y == 0 ? (byte)0 : (byte)(x / y));
        }

        // Остача від ділення
        public static VectorByte operator %(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => y == 0 ? (byte)0 : (byte)(x % y));
        }

        public static VectorByte operator %(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => y == 0 ? (byte)0 : (byte)(x % y));
        }

        //  ПЕРЕВАНТАЖЕННЯ: ПОБІТОВІ 
        
        // АБО (|)
        public static VectorByte operator |(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x | y));
        }

        public static VectorByte operator |(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => (byte)(x | y));
        }

        // XOR (^)
        public static VectorByte operator ^(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x ^ y));
        }

        public static VectorByte operator ^(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => (byte)(x ^ y));
        }

        // І (&)
        public static VectorByte operator &(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x & y));
        }

        public static VectorByte operator &(VectorByte a, byte b)
        {
            return PerformScalarOperation(a, b, (x, y) => (byte)(x & y));
        }

        // Зсув вправо (>>)
        public static VectorByte operator >>(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x >> y));
        }

        public static VectorByte operator >>(VectorByte a, int b)
        {
            return PerformScalarOperation(a, (byte)b, (x, y) => (byte)(x >> y));
        }

        // Зсув вліво (<<)
        public static VectorByte operator <<(VectorByte a, VectorByte b)
        {
            return PerformBinaryOperation(a, b, (x, y) => (byte)(x << y));
        }

        public static VectorByte operator <<(VectorByte a, int b)
        {
            return PerformScalarOperation(a, (byte)b, (x, y) => (byte)(x << y));
        }

        //  ПЕРЕВАНТАЖЕННЯ: ПОРІВНЯННЯ 
        
        public static bool operator ==(VectorByte a, VectorByte b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null || a.n != b.n) return false;
            
            for (uint i = 0; i < a.n; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        public static bool operator !=(VectorByte a, VectorByte b)
        {
            return !(a == b);
        }

        public static bool operator >(VectorByte a, VectorByte b)
        {
            if (a.n != b.n) return false;
            for (uint i = 0; i < a.n; i++)
            {
                if (a[i] <= b[i]) return false;
            }
            return true;
        }

        public static bool operator <(VectorByte a, VectorByte b)
        {
            if (a.n != b.n) return false;
            for (uint i = 0; i < a.n; i++)
            {
                if (a[i] >= b[i]) return false;
            }
            return true;
        }

        public static bool operator >=(VectorByte a, VectorByte b)
        {
            if (a.n != b.n) return false;
            for (uint i = 0; i < a.n; i++)
            {
                if (a[i] < b[i]) return false;
            }
            return true;
        }

        public static bool operator <=(VectorByte a, VectorByte b)
        {
            if (a.n != b.n) return false;
            for (uint i = 0; i < a.n; i++)
            {
                if (a[i] > b[i]) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is VectorByte v && this == v;
        }

        public override int GetHashCode()
        {
            return BArray.GetHashCode();
        }
    }
}