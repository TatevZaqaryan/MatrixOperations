using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixOperations
{
    struct Matrices
    {
        public static int InputNumber(string par = "")
        {
            Console.WriteLine($"Please input int {par}");
            string num = Console.ReadLine();

            while (isNum(num))
            {
                Console.Beep(1000, 400);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INPUT POSITIVE NUMBER");
                Console.ForegroundColor = ConsoleColor.White;
                num = Console.ReadLine();
            }

            return int.Parse(num);
        }
        public static int[,] MatriceInput(int n, int m)
        {
            Console.Write("\n\nRead a 2D array of size nxm and print the matrix :\n");
            Console.Write("------------------------------------------------------\n");


            Random random = new Random();
            int[,] arr = new int[n, m];


            Console.Write("Input elements in the matrix :\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = random.Next(1, 10);
                    Console.Write("{0}\t", arr[i, j]);

                }

                Console.WriteLine();
            }
            return arr;
        }

        public static void AddMatrices(int n, int m)
        {

            int[,] a = Matrices.MatriceInput(n, m);
            int[,] b = Matrices.MatriceInput(n, m);

            Console.WriteLine("After Addition\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", a[i, j] + b[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void MultiplyMatrices(int n, int m)
        {
            int[,] a = Matrices.MatriceInput(n, m);
            int[,] b = Matrices.MatriceInput(n, m);
            Console.WriteLine("Matrix Multiplication is :");
            int[,] c = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(c[i, j] + "\t");
                }
                Console.WriteLine();
            }


        }
        public static void TransposeOfMatrices(int n, int m)
        {

            int[,] a = Matrices.MatriceInput(n, m);

            Console.WriteLine("After Transpose of Both Matrices");
            Console.WriteLine("Original Matrice\n");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", a[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Transpose Matrice\n");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0}\t", a[j, i]);
                }
                Console.WriteLine();
            }


        }
        public static void ScalarProductMat(int n, int m)

        {
            int[,] a = Matrices.MatriceInput(n, m);
            int k = Matrices.InputNumber();


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}\t", a[i, j]);
                }
                Console.WriteLine();
            }

            int[,] arr = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = a[i, j] * k;
                }
            }

            Console.WriteLine("Scaliar Matrice\n");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine();
            }


        }


        public static bool IsOrthogonal(int m, int n)

        {
            int[,] a = Matrices.MatriceInput(n, m);



            if (m != n)
            {
                return false;
            }

            int[,] trans = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    trans[i, j] = a[j, i];
                }


            }


            int[,] prod = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    int sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum = sum + (a[i, k] * a[j, k]);
                    }

                    prod[i, j] = sum;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i != j && prod[i, j] != 0)
                        return false;
                    if (i == j && prod[i, j] != 1)
                        return false;
                }
            }

            return true;
        }

        public static void MinMax(int n, int m)
        {
            int[,] arr = Matrices.MatriceInput(n, m);

            int min = arr[0, 0];
            int max = arr[0, 0];


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }


                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }

                }

            }




            Console.WriteLine("Maximum element:" + max);
            Console.WriteLine("Minimum  element:" + min);
        }

        static bool isNum(string num)
        {

            if (int.TryParse(num, out int tmp) && tmp > 0)
            {
                return false;
            }
            return true;
        }

     }     
    
    struct Inverse
    {
        static int N = 4;

        public static void getCofactor(int[,] A, int[,] temp, int p, int q, int n)
        {

            int i = 0, j = 0;


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row != p && col != q)
                    {
                        temp[i, j++] = A[row, col];


                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }



        public static int determinant(int[,] A, int n)
        {
            int D = 0;
            if (n == 1)
                return A[0, 0];

            int[,] temp = new int[N, N];

            int sign = 1;


            for (int f = 0; f < n; f++)
            {

                getCofactor(A, temp, 0, f, n);
                D += sign * A[0, f] * determinant(temp, n - 1);


                sign = -sign;
            }
            return D;
        }


        public static void adjoint(int[,] A, int[,] adj)
        {
            if (N == 1)
            {
                adj[0, 0] = 1;
                return;
            }


            int sign = 1;
            int[,] temp = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    getCofactor(A, temp, i, j, N);


                    sign = ((i + j) % 2 == 0) ? 1 : -1;


                    adj[j, i] = (sign) * (determinant(temp, N - 1));
                }
            }
        }


       public static bool inverse(int[,] A, float[,] inverse)
        {

            int det = determinant(A, N);
            if (det == 0)
            {
                Console.Write("Singular matrix, can't find its inverse");
                return false;
            }


            int[,] adj = new int[N, N];
            adjoint(A, adj);

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    inverse[i, j] = adj[i, j] / (float)det;

            return true;
        }


        public static void display(int[,] A)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(A[i, j] + " ");
                Console.WriteLine();
            }
        }
       public  static void display(float[,] A)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write("{0:F6} ", A[i, j]);
                Console.WriteLine();
            }
        }


        public static void InverseMatrix(int n, int m)
        {

            int[,] A = Matrices.MatriceInput(n, m);

            int[,] adj = new int[N, N]; 

            float[,] inv = new float[N, N];

            Console.Write("\nThe Inverse is :\n");
            if (inverse(A, inv))
                display(inv);
        }
    }
     
    
    
   
    

        
        class Program
        {

            static bool isOperation(string num)
            {

                if (int.TryParse(num, out int tmp) && tmp > 0 && tmp < 8)
                {
                    return false;
                }
                return true;
            }

            public static void switchCase(int op)
            {
                int n = Matrices.InputNumber("(rows count)");
                int m = Matrices.InputNumber("(columns count)");
            switch (op)
            {
                case 1:
                    Matrices.AddMatrices(n, m);
                    break;
                case 2:
                    Matrices.MultiplyMatrices(n, m);
                    break;
                case 3:
                    Matrices.ScalarProductMat(n, m);
                    break;
                case 4:
                    while (n != 4 || m != 4)
                    {
                        Console.WriteLine("please input 4*4 matrice ");
                        n = Matrices.InputNumber("(rows count)");
                        m = Matrices.InputNumber("(columns count)");
                    }
                    Inverse.InverseMatrix(n,m);
                        break;
                    case 5:
                        Matrices.TransposeOfMatrices(m, n);
                        break;
                    case 6:
                        Matrices.IsOrthogonal(m, n);
                        if (Matrices.IsOrthogonal(m, n))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No");
                        }

                        break;
                    case 7:
                        Matrices.MinMax(m, n);
                        break;

                }
            }
            static void Main(string[] args)
            {

                Console.WriteLine(
@"what do you want to do  with matrix
1-Addition
2-Multiplication
3-Scaliar multiplication
4-Inverse matrix
5-Transponse matrix
6-Orthogonal or not
7-MinMax matrix
"
                );


                string op = Console.ReadLine();

                while (isOperation(op))

                {
                    Console.Beep(1000, 400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SELECT NUMBER OF OPTION");
                    Console.ForegroundColor = ConsoleColor.White;
                    op = Console.ReadLine();
                }

                int option = int.Parse(op);
                Program.switchCase(option);

                Console.Read();

            }
        }
    }

