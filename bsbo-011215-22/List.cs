using System;

namespace bsbo_011215_22
{
	public class List
	{
		protected Element? top = null;

		// Проверка на пустоту списка
		public bool isEmpty()
		{
			return top == null;
		}

		// Добавление нового элемента в список
		public void Push(Element newElement)
		{
			if (!isEmpty())
			{
                newElement.next = top;
            }

			top = newElement;
        }

		// Извлечение верхнего элемента из списка
		public Element Pop()
		{
			if (isEmpty())
			{
				throw new Exception("List is empty");
			}

			Element result = top;
			top = top.next;

			result.next = null;

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

			for (int i = 0; i < index; i++) {
				current = current.next;

				if (current == null)
				{
					throw new Exception("Out of range in list!");
				}
            }

			return current.value;
        }

		// Обращение по индексу в списке на перезапись
        public void Set(int index, int newValue)
        {
            Element current = top;

            for (int i = 0; i < index; i++)
            {
                current = current.next;

                if (current == null)
                {
                    throw new Exception("Out of range in list!");
                }
            }

            current.value = newValue;
        }

		// Перегрузка оператора индексации [] 
        public int this[int index]
		{
			get => Get(index);
			set => Set(index, value);
        }
	}
}

