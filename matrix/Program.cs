using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class Program
    {
        static bool fit(int[,] martix)
        {
            int row = martix.GetLength(0);
            int col = martix.GetLength(1);
            for (int i = 0; i < row - 1; i++)
                for (int j = 0; j < col - 1; j++)
                {
                    if (martix[i, j] != martix[i + 1, j + 1])
                        return false;
                }
            return true;
        }
        static void printMartix(int[,] martix)
        {
            int M = martix.GetLength(0);
            int N = martix.GetLength(1);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0} ", martix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入矩阵的行数：");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入矩阵的列数：");
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] martix = new int[M, N];
            Console.WriteLine("请输入矩阵的元素（从第一行开始）：");
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    martix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            printMartix(martix);
            if (fit(martix))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
}
