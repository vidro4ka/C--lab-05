/*
 * Задание№2
Создайте класс MyList<T>.
Реализуйте в простейшем приближении возможность использования его экземпляра аналогично экземпляру класса List<T>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод
добавления элемента, индексатор для получения значения элемента по указанному индексу и свойство
только для чтения для получения общего количества элементов.
При выполнении нельзя использовать коллекции, только массивы.
 */
namespace task_2
{
    class Program
    {
        class MyList<T>
        {
            public T[] newList = new T[5];
            int size = 5;
            int index = 0;
            public MyList(params T[] tmpList)
            {
                newList = new T[tmpList.Count()];
                size = tmpList.Count();
                foreach (T elem in tmpList)
                {
                    newList[index] = elem;
                    index++;
                }
            }

            public void Add(params T[] tmpList)
            {
                if (tmpList.Count() >= size - newList.Count())
                {
                    T[] temp = new T[newList.Count()];
                    for (int i = 0; i < index; i++)
                    {
                        temp[i] = newList[i];
                    }
                    newList = new T[tmpList.Count() + size];
                    size = tmpList.Count() + size;
                    for (int i = 0; i < index; i++)
                    {
                        newList[i] = temp[i];
                    }
                }
                foreach (T elem in tmpList)
                {
                    newList[index] = elem;
                    index++;
                }
            }
            public T this[int elem]
            {
                get
                {
                    return newList[elem];
                }
                set
                {
                    newList[elem] = value;
                }
            }

            public int Size
            {
                get
                {
                    Console.Write("MyList size: ");
                    return newList.Count();
                }
            }
            public void Print()
            {
                for (int i = 0; i < index; i++)
                {
                    Console.Write(newList[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>(4, 6, 3, 6, 5, 2, 7, 54);
            list.Print();
            Console.WriteLine(list.Size);

            list.Add(5, 9, 1, 31, 6, 32, 5, 4, 9, 10, 6343, 843);
            list.Print();
            Console.WriteLine(list.Size);

            list.Add(1984);
            list.Print();
            Console.WriteLine(list.Size);

            Console.WriteLine(list[10]);
        }
    }
}
