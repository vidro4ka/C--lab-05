/*
 * Задание№3
Создайте коллекцию MyDictionary<TKey,TValue>.
Реализуйте в простейшем приближении возможность использования ее экземпляра аналогично 
экземпляру класса Dictionary<TKey,TValue>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод 
добавления элемента, индексатор для получения значения элемента по указанному индексу и 
свойство только для чтения для получения общего количества элементов.
Реализуйте возможность перебора элементов коллекции в цикле foreach. 
 */

namespace task_3
{
    internal class Program
    {
        public class MyDictionary<Tkey, TValue>
        {
            public Tkey[] keys = new Tkey[0];
            public TValue[] values = new TValue[0];
            int size = 1;
            int index = 0;
             
            public MyDictionary(Tkey[] _keys, TValue[] _values)
            {
                keys = new Tkey[_keys.Count()];
                values = new TValue[_values.Count()];
                int index = 0;

                foreach (Tkey element in _keys)
                {
                    keys[index++] = element;
                }
                index = 0;
                foreach (TValue element in _values)
                {
                    values[index++] = element;
                }
                size = _keys.Count();
            }

            public void Add(Tkey[] _keys, TValue[] _values)
            {
                Tkey[] temp_keys = new Tkey[_keys.Count() + size];
                TValue[] temp_values = new TValue[_values.Count() + size];

                for(int i = 0; i < size; ++i)
                {
                    temp_keys[i] = keys[i];
                    temp_values[i] = values[i]; 
                }

                for(int j = size; j < _keys.Count() + size; ++j)
                {
                    temp_keys[j] = _keys[j - size];
                    temp_values[j] = _values[j - size];
                }

                keys = new Tkey[_keys.Count() + size];
                values = new TValue[_values.Count() + size];
                keys = temp_keys;
                values = temp_values;
                size = size + _keys.Count();
            }

            public IEnumerator<TValue> GetEnumerator()
            {
                for (int i = 0; i < size; ++i)
                {
                    yield return values[i];
                }
            }

            public TValue this[Tkey element]
            {
                get
                {
                    int el_inx = -1;
                    for(int i = 0; i<size;++i)
                    {
                        if (keys[i].Equals(element))
                        {
                            el_inx = i;
                            break;
                        }
                    }
                    return values[el_inx];
                }
                set
                {
                    int el_inx = -1;
                    for (int i = 0; i < size; ++i)
                    {
                        if (keys[i].Equals(element))
                        {
                            el_inx = i;
                            break;
                        }
                    }
                    values[el_inx] = value;
                }
            }

        public int Size
            {
                get
                {
                    Console.Write(" Size-");
                    return size;
                }
            }

        public void printer()
            {
                for(int i = 0; i < size; ++i)
                {
                    Console.Write($" {keys[i]}-{values[i]} ");
                }
            }
        }

        static void Main(string[] args)
        {
            int[] keys = new int[] { 1, 44, 5, 6, 8, 7 };
            string[] values = new string[] { "one", "two", "three", "four", "five", "six" };
            MyDictionary<int, string> ob_1 = new MyDictionary<int, string>(keys, values);

            Console.WriteLine(ob_1.Size);
            ob_1.printer();

            Console.WriteLine("\nNEXT STEPP IS ADDING:");

            int[] keys_add = new int[] { 3, 33, 4, 2, 99, 77 };
            string[] values_add = new string[] { "seven", "eight", "nine", "ten", "eleven", "twelve" };

            ob_1.Add(keys_add, values_add);
            Console.WriteLine(ob_1.Size);
            ob_1.printer();

            Console.WriteLine();

            foreach(string elem in ob_1)
            {
                Console.Write($"{elem}  ");
            }

            Console.WriteLine(ob_1[44]);
            Console.ReadLine();
        }
    }
}