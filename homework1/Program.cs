using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
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
        static void getSu(int n)
        {
            int i = 2;
            while (i <= n)
            {
                if ((n % i == 0) && first(i))
                {
                    Console.WriteLine(i);
                    n = n / i;
                }
                i++;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数字：");
            string number = Console.ReadLine();
            int num = Convert.ToInt32(number);
            Console.WriteLine("该数的所有素数因子有：");
            getSu(num);
        }
    }
}
