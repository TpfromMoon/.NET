using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework3
{
    [XmlRootAttribute("Order")]
    class Order
    {
        public string OrderNumber;
        public List<OrderDetails> OrderDetails;
        public Customer cus;
        public Order(string Number, Customer customer)
        {
            OrderNumber = Number;
            OrderDetails = new List<OrderDetails>();
            cus = customer;
        }
        public int Sum
        {
            get
            {
                int sum = 0;
                OrderDetails.ForEach(i => sum += i.goods.GoodsPrice * i.CountNumber);
                return sum;
            }
        }
        public int OrderItemCount
        {
            get
            {
                return OrderDetails.Count();
            }
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Order)obj);
        }
        public override int GetHashCode()
        {
            return (this.ToString() != null ? StringComparer.InvariantCulture.GetHashCode(this.ToString()) : 0);
        }
        public static bool operator ==(Order left, Order right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Order left, Order right)
        {
            return !Equals(left, right);
        }
        public override string ToString()
        {
            string information = "下单时间：" + DateTime.Now.ToString() + "客户信息：" + cus.ToString() + "\n";
            OrderDetails.ForEach(i => information += i.ToString() + "\n");
            return information;
        }
    }
    class OrderDetails
    {
        public Goods goods;
        private int Count;
        public int CountNumber
        {
            get
            {
                return Count;
            }
            set
            {
                if (value <= 0)
                    Count = 1;
                else
                    Count = value;
            }
        }
        public OrderDetails(Goods product, int count)
        {
            goods = product;
            CountNumber = count;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((OrderDetails)obj);
        }
        public override int GetHashCode()
        {
            return (this.ToString() != null ? StringComparer.InvariantCulture.GetHashCode(this.ToString()) : 0);
        }
        public static bool operator ==(OrderDetails left, OrderDetails right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(OrderDetails left, OrderDetails right)
        {
            return !Equals(left, right);
        }
        public override string ToString()
        {
            return "货物：" + goods + " 货物数量：" + CountNumber;
        }
    }
    class OrderService
    {
        public List<Order> OrderList;
        public int OrderNum;
        public int OrderCount
        {
            get
            {
                return OrderList.Count();
            }
        }
        public OrderService()
        {
            OrderNum = 0;
            OrderList = new List<Order>();
        }
        public bool AddOrder(Customer customer)
        {
            try
            {
                OrderNum += 1;
                OrderList.Add(new Order(OrderNum.ToString().PadLeft(8, '0'), customer));
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool AddOrderDetails(string ordernum, OrderDetails orderdetails)
        {
            int index = OrderList.FindIndex(o => o.OrderNumber == ordernum);
            if (index == -1)
            {
                return false;
            }
            OrderList[index].OrderDetails.Add(orderdetails);
            return true;
        }
        public bool DeleteOrder(string ordernum)
        {
            int index = OrderList.FindIndex(o => o.OrderNumber == ordernum);
            if (index == -1)
            {
                return false;
            }
            OrderList.RemoveAt(index);
            return true;
        }
        public IEnumerable<Order> QueryOrder(string query = "", string _type = "")
        {
            IEnumerable<Order> result = OrderList;
            switch (_type.ToLower())
            {
                case "orderno":
                    result = OrderList.Where(o => o.OrderNumber == query);
                    break;
                case "productname":
                    result = OrderList.Where(o => o.OrderDetails.Where(i => i.goods.GoodsName == query).Any());
                    break;
                case "custormername":
                    result = OrderList.Where(o => o.cus.CustomerName == query);
                    break;
            }
            return result.OrderByDescending(r => r.Sum);
        }
        public List<Order> SortOrder(string by = "ascending")
        {
            if (by == "ascending")
            {
                return SortOrder((o1, o2) =>
                {
                    if (int.Parse(o1.OrderNumber) < int.Parse(o2.OrderNumber)) return 1;
                    else if (int.Parse(o1.OrderNumber) == int.Parse(o2.OrderNumber)) return 0;
                    else return -1;
                });
            }
            else
            {
                return SortOrder((o1, o2) =>
                {
                    if (int.Parse(o1.OrderNumber) > int.Parse(o2.OrderNumber)) return 1;
                    else if (int.Parse(o1.OrderNumber) == int.Parse(o2.OrderNumber)) return 0;
                    else return -1;
                });
            }
        }
        public List<Order> SortOrder(Comparison<Order> comparison)
        {
            OrderList.Sort(comparison);
            return OrderList;
        }
        public void Export(string filename = "export.xml")
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrWhiteSpace(filename) ?
                    new System.Xml.Serialization.XmlSerializer(OrderList.GetType()) :
                    new System.Xml.Serialization.XmlSerializer(OrderList.GetType(), new XmlRootAttribute("Order"));
                    xmlSerializer.Serialize(writer, OrderList);
                }
                finally
                {
                    writer.Close();
                }
            }
        }
        public void Import(string filename = "export.xml")
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(OrderList.GetType(), new XmlRootAttribute("Order"));
                    OrderList = (List<Order>)xmlSerializer.Deserialize(reader);
                }
                finally
                {
                    reader.Close();
                }
            }

        }
    }
    class Customer
    {
        public string CustomerName;
        public string CustomerPhone;
        public Customer(string name, string phone)
        {
            CustomerName = name;
            CustomerPhone = phone;
        }
        public override string ToString()
        {
            return "客户姓名：" + CustomerName + " 客户电话：" + CustomerPhone;
        }
    }
    class Goods
    {
        public string GoodsName;
        public string GoodsType;
        public int GoodsPrice;
        public Goods(string name, string type, int price)
        {
            GoodsName = name;
            GoodsType = type;
            GoodsPrice = price;
        }
        public override string ToString()
        {
            return "货物名：" + GoodsName + " 货物类型：" + GoodsType + " 货物价格：" + GoodsPrice;
        }
    }
    class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string message) : base(message)
        {
            Console.WriteLine("找不到订单号：" + message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            Goods phone_xm = new Goods("xiaomi", "phone", 2000);
            Goods phone_hw = new Goods("huawei", "phone", 4000);
            Goods pc_dell = new Goods("dell", "pc", 6000);
            Customer cus1 = new Customer("Leijun", "13866666666");
            Customer cus2 = new Customer("lzt", "15666666666");
            OrderDetails item_phone_xm = new OrderDetails(phone_xm, 10);
            OrderDetails item_phone_hw = new OrderDetails(phone_hw, 5);
            OrderDetails item_pc_dell = new OrderDetails(pc_dell, 3);
            service.AddOrder(cus1);
            service.AddOrderDetails("00000001", item_phone_xm);
            service.AddOrderDetails("00000001", item_phone_hw);
            service.AddOrderDetails("00000001", item_pc_dell);
            service.AddOrder(cus2);
            OrderDetails item_phone_xm2 = new OrderDetails(phone_xm, 8);
            OrderDetails item_phone_hw2 = new OrderDetails(phone_hw, 1);
            service.AddOrderDetails("00000002", item_phone_xm2);
            service.AddOrderDetails("00000002", item_phone_hw2);
            foreach (var i in service.QueryOrder())
            {
                Console.WriteLine(i);
            }
        }
    }
}
