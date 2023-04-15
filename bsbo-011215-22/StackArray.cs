using System;
using System.Collections.Generic;

namespace bsbo_011215_22
{
	public class StackArray
	{
        // Внутренний массив для заданий с "массивом"
		private List<int> _list = new List<int>();

        // Проверка на пустоту списка
        public bool isEmpty()
		{
			return _list.Count == 0;
		}

        // Извлечение верхнего элемента из стэка
        public int Pop()
		{
			if (isEmpty())
			{
				throw new Exception("Stack is empty");
			}

			int result = _list[_list.Count - 1];
			_list.RemoveAt(_list.Count - 1);
			return result;
		}

        // Добавление нового элемента в стэк
        public void Push(int value)
		{
			_list.Add(value);
		}

        // Обращение по индексу в стэке на чтение
        public int Get(int index, StackArray tmp)
        {
            if (isEmpty())
                throw new Exception("Stack is empty");

            for (int i = 0; i < index; i++)
            {
                tmp.Push(Pop());
                if (isEmpty())
                {
                    while (!tmp.isEmpty())
                        Push(tmp.Pop());
                    throw new Exception("Out of range");
                }
            }
            int result = _list[_list.Count - 1]; 

            while (!tmp.isEmpty())
                Push(tmp.Pop());

            return result;
        }

        // Обращение по индексу в стэке на перезапись
        public void Set(int index, int value, StackArray tmp)
        {
            if (isEmpty())
                throw new Exception("Stack is empty");

            for (int i = 0; i < index; i++)
            {
                tmp.Push(Pop());
                if (isEmpty())
                {
                    while (!tmp.isEmpty())
                        Push(tmp.Pop());
                    throw new Exception("Out of range");
                }
            }

            _list[_list.Count - 1] = value;

            while (!tmp.isEmpty())
                Push(tmp.Pop());
        }

        // Перегрузка оператора индексации [] 
        public int this[int index]
        {
            get => Get(index, Application.tmpArray);
            set => Set(index, value, Application.tmpArray);
        }

        // Вывод списка в консоль
        public void Print()
        {
            foreach(int item in _list)
            {
                Console.Write($"{item.ToString()} ");
            }
            Console.WriteLine();
        }
    }
}

