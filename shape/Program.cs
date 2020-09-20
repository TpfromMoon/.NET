using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shape
{
    class Program
    {
        abstract class shape
        {
            public abstract double Area();
            public abstract void initial();
        }
        class Square : shape
        {
            double length;
            public Square()
            {
                initial();
            }
            public override double Area()
            {
                double s = length * length;
                return s;
            }
            public override void initial()
            {
                while (true)
                {
                    Console.WriteLine("请输入正方形的边长：");
                    length = Convert.ToDouble(Console.ReadLine());
                    if (!(length > 0))
                    {
                        Console.WriteLine("输入的边长不能构成正方形，请重新输入。");
                        continue;
                    }
                    break;
                }
            }
        }
        class Oblong : shape
        {
            double length;
            double width;
            public Oblong()
            {
                initial();
            }
            public override double Area()
            {
                double s = length * width;
                return s;
            }
            public override void initial()
            {
                while (true)
                {
                    Console.WriteLine("请输入长方形的长：");
                    length = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("请输入长方形的宽：");
                    width = Convert.ToDouble(Console.ReadLine());
                    if (!(length != width || length > 0 || width > 0))
                    {
                        Console.WriteLine("输入的长和宽不能构成长方形，请重新输入。");
                        continue;
                    }
                    break;
                }
            }
        }
        class Triangle : shape
        {

            double a, b, c;
            public Triangle()
            {
                initial();
            }
            public override double Area()
            {
                double l = (a + b + c) / 2;   //周长的1/2
                double s = Math.Sqrt(l * (l - a) * (l - b) * (l - c));   //面积
                return s;
            }
            public override void initial()
            {
                while (true)
                {
                    Console.WriteLine("请输入三角形的第一边长：");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("请输入三角形的第二边长：");
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("请输入三角形的第三边长：");
                    c = Convert.ToDouble(Console.ReadLine());
                    if (!(a + b > c || a + c > b || b + c > a))
                    {
                        Console.WriteLine("输入的三边不能构成三角形，请重新输入。");
                        continue;
                    }
                    break;
                }
            }
        }
        class Factory
        {
            public static shape getSgape(string flag)
            {
                shape area;
                switch (flag)
                {
                    case "1": area = new Square(); return area;
                    case "2": area = new Oblong(); return area;
                    case "3": area = new Triangle(); return area;
                    default: Console.WriteLine("没有所选的形状。"); return null;
                }
            }
        }

        static void Main(string[] args)
        {
            double[] array = new double[10];
            double sum = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("请输入你选择的形状:1.正方形 2.长方形 3.三角形");
                string flag = Console.ReadLine();
                shape area = Factory.getSgape(flag);
                if (area != null)
                {
                    Console.WriteLine("该形状的面积为" + area.Area());
                    array[i] = area.Area();
                }
                sum += array[i];
            }
            Console.WriteLine("面积和为：" + sum);
        }
    }
}
