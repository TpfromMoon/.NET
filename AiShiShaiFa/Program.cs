using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiShiShaiFa
{
    class Program
    {
        static bool first(int n)
        {
            int a;
            bool flag = true;
            for (a = 2; a < n; a++)
                if (n % a == 0)
                {
                    flag = false;
                    return flag;
                }
            return flag;
        }
        static void Main(string[] args)
        {
            int[] array = new int[100];
            for (int a = 2; a < array.Length; a++)
            {
                array[a] = a;
            }
            int i = 2;
            while (i < 100)
            {
                if ((array[i] % i == 0) && first(i))
                {
                    Console.WriteLine(array[i]);

                }
                i++;
            }
        }
    }
}
