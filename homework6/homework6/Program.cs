﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    class Program
    {
        public static void Main()
        {
            try
            {

                using (var db = new OrderContext())
                {
                    var order = db.OrderItems.FirstOrDefault();

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            //Console.ReadKey();

        }
    }
}
