using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program10
{
    /// <summary>
    /// Собственная обобщенная коллекция по заданию №3
    /// </summary>
    /// <typeparam name="T">Какой-нибудь класс</typeparam>
    class MyList<T> 
    {
        /// <summary>
        /// Буфер в котором будем хранить элементы
        /// </summary>
        private T[] buffer = new T[5];

        /// <summary>
        /// Количество элементов в заданной коллекции
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Доступ к заданному элементу коллекции по его индексу
        /// </summary>
        /// <param name="i">ИНдекс требуемого элемента коллекции</param>
        /// <returns></returns>
        public T this[int i]
        {
            get
            {
                // если индекс за пределами массива, то вызываем ошибку
                if (i < 0 || i >= Count)
                    throw new IndexOutOfRangeException();
                return buffer[i];
            }
            set
            {
                // если индекс за пределами массива, то вызываем ошибку
                if (i < 0 || i >= Count)
                    throw new IndexOutOfRangeException();
                buffer[i] = value;
            }
        }

        /// <summary>
        /// Пустой конструктор, начальная емкость 5 элементов, Count = 0;
        /// </summary>
        public MyList()
        {
            //Начальное значение индексов элементов пустое, т.к. создается пустой массив
            Count = 0;
        }

        /// <summary>
        /// Конструктор с заранее заданным размером массива
        /// </summary>
        /// <param name="Count"></param>
        public MyList(int Count)
        {
            // задаем значения индексам элементов
            this.Count = 0;
            // переопределяем buffer
            T[] buffer = new T[Count];
        }
        /// <summary>
        /// Конструктор по существующему элементу
        /// </summary>
        /// <param name="obj"></param>
        public MyList(MyList<T> obj)
        {
            buffer = new T[obj.buffer.Length];
            Count = 0;
        }

        /// <summary>
        /// Отображает текущую возможную ёмкость массива
        /// </summary>
        public int Capacity
        {
            get
            {
                return buffer.Count();
            }
        }

        /// <summary>
        /// Реализация текущего элемента IEnumerable
        /// </summary>
        public object Current
        {
            get
            {
                // если индекс за пределами массива, то вызываем ошибку
                if (position == -1 || position >= Count)
                    throw new InvalidOperationException();
                return buffer[position];
            }
        }

        /// <summary>
        /// Получить или установить значение элемента по заданному индексу
        /// </summary>
        //public T Item(int Index)
        //{
        //    return buffer[Index];
        //}
        /// <summary>
        /// Добавляет элемент в список
        /// </summary>
        /// <param name="value">элемент</param>
        public void Add(T value)
        {
            // проверяем текущую емкость массива
            // по выделенной памяти
            if (Count >= buffer.Length)
                // если буфера не хватает, то размер буфера удваиваем, как в Queue
                Array.Resize<T>(ref buffer, buffer.Length * 2);
            // присваиваем значение
            buffer[Count] = value;
            // увеличиваем индекс значений
            Count++;
            position = 0;
        }

        /// <summary>
        /// Очистка значений массива
        /// </summary>
        public void Clear()
        {
            Count = 0;
            T[] buffer = new T[5];
        }

        /// <summary>
        /// позиция IEnumerator
        /// </summary>
        private int position = -1;
       

        /// <summary>
        /// Реализация IEnumerator
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (position < Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Реализация IEnumerator
        /// </summary>
        /// <returns></returns>
        public void Reset()
        {
            position = -1;
        }

        /// <summary>
        /// Возвращает индекс первого найденного элемента, если не найден. то -1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T item, EqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;

            for (int i = 0; i < Count; i++)
            {
                var Item = buffer[i];
                if (comparer.Equals(item, Item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Возвращает последний найденный индекс элемента, если не найден, то -1
        /// </summary>
        /// <param name="item"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public int LastIndexOf(T item, EqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            int retIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                var Item = buffer[i];
                if (comparer.Equals(item, Item))
                {
                    retIndex = i;
                }
            }
            return retIndex;
        }

        /// <summary>
        /// Удалаяет элемент из массива по значению, если найден, если не найден, то возвращает false
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public bool Remove(T value, EqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            for (int i = 0; i < Count; i++)
            {
                var Item = buffer[i];
                if (comparer.Equals(value, Item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Удалает элемент по заданному индексу
        /// </summary>
        /// <param name="index">индекс</param>
        public void RemoveAt(int index)
        {
            // если индекс за пределами массива, то вызываем ошибку
            if (index <= 0 || index >= Count)
                throw new IndexOutOfRangeException();
            // создаем новый массив
            var nArray = new T[Count];
            // добавляем в него элементы до заданного индекса
            for (int i = 0; i < index; i++)
            {
                nArray[i] = buffer[i];
            }
            // добавляем в него элементы после заданного индекса
            for (int i = index + 1; i < Count; i++)
            {
                nArray[i - 1] = buffer[i];
            }
            // присваиваем буферу новый массив
            buffer = nArray;
            Count--;
        }

        /// <summary>
        /// Вставка элемента в заданную позицию
        /// </summary>
        /// <param name="Index">Номер позиции</param>
        /// <param name="value">значение</param>
        public void Insert(int index, T value)
        {
            // если индекс за пределами массива, то вызываем ошибку
            if (index <= 0 || index > Count)
                throw new IndexOutOfRangeException();
            // создаем новый массив
            var nArray = new T[Count + 1];
            // добавляем в него элементы до заданного индекса
            for (int i = 0; i < index; i++)
            {
                nArray[i] = buffer[i];
            }
            nArray[index] = value;
            for (int i = index + 1; i < Count + 1; i++)
            {
                nArray[i] = buffer[i - 1];
            }
            // присваиваем буферу новый массив
            buffer = nArray;
        }

        /// <summary>
        /// Переворачивает список
        /// </summary>
        public void Reverse()
        {
            Array.Reverse(buffer, 0, Count);
        }

        /// <summary>
        /// Не глубокое клонирование массива
        /// </summary>
        /// <returns></returns>
        public MyList<T> Clone()
        {
            MyList<T> result = new MyList<T>();
            for (int i = 0; i < Count; i++)
            {
                result.Add(buffer[i]);
            }
            return result;
        }

        /// <summary>
        /// Сортировка массива
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(System.Collections.IComparer comparer)
        {
            Array.Sort(buffer, 0, Count - 1, comparer);
        }

    }
}
