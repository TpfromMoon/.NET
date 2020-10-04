using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework3;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        OrderService service = new OrderService();
        Goods phone_xm = new Goods("xiaomi", "phone", 2000);
        Goods phone_hw = new Goods("huawei", "phone", 4000);
        Goods pc_dell = new Goods("dell", "pc", 6000);
        Customer cus1 = new Customer("Leijun", "13866666666");
        Customer cus2 = new Customer("lzt", "15666666666");

        OrderDetails item_phone_xm, item_phone_hw, item_pc_dell, item_phone_xm2, item_phone_hw2;

        [TestInitialize()]
        public void init()
        {
            item_phone_xm = new OrderDetails(phone_xm, 10);
            item_phone_hw = new OrderDetails(phone_hw, 5);
            item_pc_dell = new OrderDetails(pc_dell, 3);
            item_phone_xm2 = new OrderDetails(phone_xm, 8);
            item_phone_hw2 = new OrderDetails(phone_hw, 1);
        }
        [TestMethod]
        public void TestMethod1()
        {
            service.AddOrder(cus1);
            service.AddOrderDetails("00000001", item_phone_xm);
            service.AddOrderDetails("00000001", item_phone_hw);
            service.AddOrderDetails("00000001", item_pc_dell);
            service.AddOrder(cus2);
            service.AddOrderDetails("00000002", item_phone_xm2);
            service.AddOrderDetails("00000002", item_phone_hw2);
            Assert.AreEqual(2, service.OrderCount);
        }
    }
}
