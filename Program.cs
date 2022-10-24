/*
 * Задание№1
Создайте класс MyMatrix, представляющий матрицу m на n.
Создайте конструктор, принимающий число строк и столбцов, заполняющий матрицу случайными числами в диапазоне, 
который пользователь вводит при запуске программы.
Создайте метод Fill, перезаполняющий матрицу случайными значениями.
Создайте метод ChangeSize, изменяющий число строк и/или столбцов с копированием значений существующей матрицы. 
Если новая матрица больше существующий, то метод должен дозаполнить новую матрицу случайными числами.
Создайте метод ShowPartialy, принимающий в качестве параметров начальные и конечные значения строк и столбцов,
значения матрицы внутри которых нужно вывести на консоль.
Создайте метод Show, выводящий все значения матрицы на консоль.
Создайте индексатор для матрицы вида this[int index1, int index2] с аксессором и мутатором.
 */

using System;
using System.Security.Permissions;

namespace task_1
{
    class Program
    {
        public class MyMatr
        {
            public double[,] matr;
            public int n;
            public int m;

            public void Show()
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        System.Console.Write($"{matr[i, j]}\t");
                    }
                    System.Console.WriteLine();
                }
            }

            public MyMatr(int rows, int columns)
            {
                matr = new double[rows, columns];
                n = rows;
                m = columns;
                for(int i = 0; i < n; ++i)
                {
                    for(int j = 0; j < m; ++j)
                    {
                        matr[i, j] = 0;
                    }
                }
            }
            public void Fill()
            {   

                var rand = new System.Random();
                for(int i = 0; i < n; ++i)
                {
                    for(int j = 0; j < m; ++j)
                    {
                        matr[i, j] = rand.Next(-100, 100);
                    }
                }
            }

            public void ChangeSize(int new_rows, int new_columns)
            {
                int rows = new_rows;
                int columns = new_columns;
                bool logic_rows = false;
                bool logic_columns = false;
                var rand = new System.Random();
                double[,] new_matr = new double[new_rows,new_columns];
                for(int i = 0; i < n; ++i)
                {
                    for(int j = 0; j < m; ++j)
                    {
                        new_matr[i, j] = matr[i, j];
                    }
                }
                if(new_rows > n )
                {
                    rows = n;
                    logic_rows = true;
                }
                if(new_columns > m)
                {
                    columns = m;
                    logic_columns = true;
                }
                for(int i = 0; i < rows; ++i)
                {
                    for(int j=0; j<columns; ++j)
                    {
                        new_matr[i, j] = matr[i, j];
                    }
                }
                if (logic_columns && logic_rows)
                {
                    for (int i = rows; i < new_rows; ++i)
                    {
                        for (int j = 0; j < new_columns; ++j)
                        {
                            new_matr[i, j] = rand.Next(-100, 100);
                        }
                    }
                    for (int i = 0; i < rows; ++i)
                    {
                        for (int j = columns; j < new_columns; ++j)
                        {
                            new_matr[i, j] = rand.Next(-100, 100);
                        }
                    }
                } else
                {
                    if (logic_rows)
                    {
                        for (int i = rows; i < new_rows; ++i)
                        {
                            for (int j = 0; j < columns; ++j)
                            {
                                new_matr[i, j] = rand.Next(-100, 100);
                            }
                        }
                    }
                    if (logic_columns)
                    {
                        for (int i = 0; i < rows; ++i)
                        {
                            for (int j = columns; j < new_columns; ++j)
                            {
                                new_matr[i, j] = rand.Next(-100, 100);
                            }
                        }
                    }
                }
                matr = new double[new_rows, new_columns];
                matr = new_matr;
                n = new_rows;
                m = new_columns;
            }
            public MyMatr(int _n, int _m, int from, int to)
            {
                this.n = _n;
                this.m = _m;
                matr = new double[n, m];
                var rand = new System.Random();
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        matr[i, j] = rand.Next(from, to);
                    }
                }
            }
            public double this[int i, int j]
            {
                get
                {
                    return matr[i, j];
                }
                set
                {
                    matr[i, j] = value;
                }
            }
            public void ShowPartialy(int[] d_1, int[] d_2)
            {
                for (int i = d_1[0]; i <= d_2[0]; ++i)
                {
                    if (i == d_1[0] && d_1[0] == d_2[0])
                    {
                        for (int j = d_1[1]; j <= d_2[1]; ++j)
                        {
                            Console.Write($"{matr[i, j]} ");

                        }
                        break;
                    }
                    else if (i == d_1[0])
                    {
                        for (int j = d_1[1]; j < m; ++j)
                        {
                            Console.Write($"{matr[i, j]} ");
                        }
                    }
                    else if (i < d_2[0])
                    {
                        for (int j = 0; j < m; ++j)
                        {
                            Console.Write($"{matr[i, j]} ");
                        }
                    }
                    else if (i == d_2[0])
                    {
                        for (int j = 0; j <= d_2[1]; ++j)
                        {
                            Console.Write($"{matr[i, j]} ");
                        }
                    }
                    Console.WriteLine();
                }
                
            }
        }
            static void Main(string[] args)
        {
            int n_1;
            int m_1;
            int new_row;
            int new_columns;
            int from;
            int to;

            System.Console.WriteLine("Enter deaposone from:");
            from = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Enter deaposone to:");
            to = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Enter numbers of rows for first matrix:");
            n_1 = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Enter numbers of columns for first matrix:");
            m_1 = System.Convert.ToInt32(System.Console.ReadLine());

            MyMatr matr_1 = new MyMatr(n_1, m_1, from, to);

            System.Console.WriteLine("\nFirst matrix:");
            matr_1.Show();

            System.Console.WriteLine("\nRefill matrix");

            matr_1.Fill();
            matr_1.Show();

            System.Console.WriteLine("Enter numbers of rows for new matrix:");
            new_row = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Enter numbers of columns for new matrix:");

            new_columns = System.Convert.ToInt32(System.Console.ReadLine());

            matr_1.ChangeSize(new_row, new_columns);
            matr_1.Show();

            System.Console.WriteLine("Enter deaposone from:");

            int[] a = new int[] { 1, 2 };
            int[] b = new int[] { 3, 4 };

            System.Console.WriteLine("Output matrix by deaposone:");

            matr_1.ShowPartialy(a,b);
            System.Console.ReadLine();

        }
    }
}
