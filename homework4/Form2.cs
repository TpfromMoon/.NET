using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordermanagewinform
{
    public partial class Form2 : Form
    {
        public Order order = new Order();
        public OrderDetails item = new OrderDetails();
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Order order, OrderDetails item)
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", order, "OrderId");
            textBox2.DataBindings.Add("Text", order, "Customer");
            textBox6.DataBindings.Add("Text", item, "index");
            textBox3.DataBindings.Add("Text", item, "GoodsName");
            textBox4.DataBindings.Add("Text", item, "Price");
            textBox5.DataBindings.Add("Text", item, "Quantity");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Owner;
            Order order1 = new Order(order.OrderId, order.Customer, new List<OrderDetails> { item });

            //如果包含id相同的订单，则对该订单里面的item进行更新,否则直接添加order
            if (form1.os.Orders.Contains(order1))
            {
                Order order2 = form1.os.GetOrder(order.OrderId);

                //如果包含货物名相同的订单项，则对该订单项进行修改，若不包含该订单项，则直接添加该订单项
                if (order2.Items.Contains(item))
                {
                    OrderDetails item2 = order2.GetItem(item.Index);
                    order2.RemoveItem(item2);
                    order2.Items.Add(item);
                }
                else
                {
                    order2.Items.Add(item);
                }
            }
            else
            {
                form1.os.AddOrder(order1);
            }

            form1.orderbindingSource.ResetBindings(false);
            this.Close();
        }
    }
}
