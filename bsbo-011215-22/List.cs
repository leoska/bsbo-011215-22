using System;

namespace bsbo_011215_22
{
	public class List
	{
		protected Element? top = null;

		// Проверка на пустоту списка
		public bool isEmpty()
		{
			Application.N_OP += 1;
			return top == null; // 1
		}

		// Добавление нового элемента в список
		public void Push(Element newElement)
		{
            Application.N_OP += 3;
            if (!isEmpty()) // 3
			{
                newElement.next = top; // 2
                Application.N_OP += 2;
            }

			top = newElement; // 1
            Application.N_OP += 1;
        }

		// Извлечение верхнего элемента из списка
		public Element Pop()
		{
            Application.N_OP += 2;
            if (isEmpty()) // 2
			{
				throw new Exception("List is empty");
			}

			Element result = top; // 1
			top = top.next; // 2

			result.next = null; // 2
            Application.N_OP += 5;

            return result;
        }

		// Вывод списка в консоль
		public void Print()
		{
			Element current = top;
			while(current != null)
			{
				Console.Write($"{current.value.ToString()} ");
				current = current.next;
			}
			Console.WriteLine();
		}

		// Обращение по индексу в списке на чтение
		public int Get(int index)
		{
			Element current = top;
            Application.N_OP += 1;

            Application.N_OP += 2;
            for (int i = 0; i < index; i++) {
				current = current.next; // 2

				if (current == null) // 1
				{
					throw new Exception("Out of range in list!");
				}

                Application.N_OP += 5;
            }

            Application.N_OP += 1;
            return current.value;
        }

		// Обращение по индексу в списке на перезапись
        public void Set(int index, int newValue)
        {
            Element current = top;
            Application.N_OP += 1;

            Application.N_OP += 2;
            for (int i = 0; i < index; i++)
            {
                current = current.next;

                if (current == null)
                {
                    throw new Exception("Out of range in list!");
                }
                Application.N_OP += 5;
            }

            Application.N_OP += 2;
            current.value = newValue;
        }

		// Перегрузка оператора индексации [] 
        public int this[int index]
		{
			get {
                Application.N_OP += 2;
                return Get(index);
			}
			set
			{
                Application.N_OP += 3;
                Set(index, value);
			}
        }
	}
}

