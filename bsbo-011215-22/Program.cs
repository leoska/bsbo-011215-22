using System;
using bsbo_011215_22;

internal class Application
{
    // Размер массива
    static int N = 5;
    static public int N_OP = 0;

    // Вывод содержимого массива в консоль
    static void PrintArr(int[] arr)
    {
        for (int i = 0; i < N; i++)
        {
            Console.Write($"{arr[i].ToString()} ");
        }
        Console.WriteLine();
    }

    // Сортировка массива пузырьком
    static void SortArr()
    {
        int[] arr = new int[] { 35, -12, 0, 532, 2 };

        PrintArr(arr);

        bool swapFlag = false;
        for (int i = 0; i < N; i++)
        {
            swapFlag = false;
            for (int j = 0; j < N - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Способ #1 (с доп памятью)
                    // O(9), M(1)
                    //int tmp = arr[j];
                    //arr[j] = arr[j + 1];
                    //arr[j + 1] = tmp;

                    // Способ #2 (без доп памяти)
                    // [4, 1]
                    // 1) [4, 5]
                    // 2) [1, 5]
                    // 3) [1, 4]
                    // O(20), M(0)
                    //arr[j + 1] = arr[j + 1] + arr[j];
                    //arr[j] = arr[j + 1] - arr[j];
                    //arr[j + 1] = arr[j + 1] - arr[j];

                    // Способ #3 (TupleValue swap)
                    // O(6 + k), M(2k)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }

        PrintArr(arr);
    }

    // class Element как RefType. (Struct -> ValueType)
    static void RefTypes()
    {
        Element a = new Element(15);
        Console.WriteLine($"a: {a.value.ToString()}");

        Element b = a;
        Console.WriteLine($"a: {a.value.ToString()}");
        Console.WriteLine($"b: {b.value.ToString()}");

        b.value = 24;
        Console.WriteLine($"a: {a.value.ToString()}"); // a == 15?
        Console.WriteLine($"b: {b.value.ToString()}"); // b == 15?
    }

    // Сортировка линейно-связанного списка
    static void ListSort() {
        int n = 300;
        List list = new List();
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            list.Push(new Element(rnd.Next(0, 100)));
        }

        list.Print();

        bool swapFlag = false;
        for (int i = 0; i < n; i++)
        {
            swapFlag = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }

        list.Print();
        Console.WriteLine($"N_OP: {Application.N_OP}");
    }

    // Сортировка стэка
    static void StackSort()
    {
        int n = 5;
        Stack stack = new Stack();
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            stack.Push(new Element(rnd.Next(0, 100)));
        }

        stack.Print();

        bool swapFlag = false;
        for (int i = 0; i < n; i++)
        {
            swapFlag = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (stack[j] > stack[j + 1])
                {
                    (stack[j], stack[j + 1]) = (stack[j + 1], stack[j]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }

        stack.Print();
    }

    // Сортировка Стэка на массивах
    static void StackArraySort()
    {
        int n = 5;
        StackArray stack = new StackArray();
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            stack.Push(rnd.Next(0, 100));
        }

        stack.Print();

        bool swapFlag = false;
        for (int i = 0; i < n; i++)
        {
            swapFlag = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (stack[j] > stack[j + 1])
                {
                    (stack[j], stack[j + 1]) = (stack[j + 1], stack[j]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }

        stack.Print();
    }

    public static Stack tmp = new Stack();
    public static StackArray tmpArray = new StackArray();

    static void Main(string[] args)
    {
        //SortArr();
        //RefTypes();

        ListSort();
        //StackSort();
        //StackArraySort();
    }
}

