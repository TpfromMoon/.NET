using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericlist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入用空格分隔的整数列表：");
            string[] array = Console.ReadLine().Split();
            List<int> list = new List<int>();
            int len = array.Length;
            foreach (string s in array)
            {
                list.Add(int.Parse(s));
            }
            int sum = 0, max = list[0], min = list[0];
            double avg = 0;
            Action<int> print = delegate (int i) {
                Console.Write(i + " ");
            };
            list.ForEach(print);
            Console.WriteLine();
            list.ForEach(i => { sum += i; max = max < i ? i : max; min = min > i ? i : min; });
            avg = sum * 1.0 / len;
            Console.Write($"求和：{sum} 最大值：{max} 最小值: {min} 平均值：{avg}");
        }
    }
}
