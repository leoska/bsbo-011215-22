using System;
using System.Collections.Generic;

namespace bsbo_011215_22
{
	public class Stack : List
	{
        // Обращение по индексу в стэке на чтение
        public int Get(int index, Stack tmp) {
			if (isEmpty())
				throw new Exception("Stack is empty");

			for (int i = 0; i < index; i++) {
				tmp.Push(Pop());
				if (isEmpty())
				{
					while (!tmp.isEmpty())
						Push(tmp.Pop());
					throw new Exception("Out of range");
                }
            }
			int result = top.value;

            while (!tmp.isEmpty())
                Push(tmp.Pop());

			return result;
        }

        // Обращение по индексу в списке на перезапись
        public void Set(int index, int value, Stack tmp)
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

            top.value = value;
            while (!tmp.isEmpty())
                Push(tmp.Pop());
        }

        // Перегрузка оператора индексации [] 
        public int this[int index] {
            get => Get(index, Application.tmp);
            set => Set(index, value, Application.tmp);
        }
    }
}

