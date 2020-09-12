using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组长度：");
            string length = Console.ReadLine();
            int len = Convert.ToInt32(length);
            int[] num = new int[len];
            Console.WriteLine("请输入数组元素：");
            for (int i = 0; i < len; i++)
            {
                string number = Console.ReadLine();
                num[i] = Convert.ToInt32(number);
            }
            int sum = 0;
            int max = num[0];
            int min = num[0];
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
                if (max < num[i])
                    max = num[i];
                if (min > num[i])
                    min = num[i];
            }
            Console.WriteLine("最大值为：" + max);
            Console.WriteLine("最小值为：" + min);
            Console.WriteLine("元素和为：" + sum);
            Console.WriteLine("平均值为：" + sum / num.Length);
        }
    }
}
