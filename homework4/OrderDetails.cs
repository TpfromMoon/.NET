﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordermanagewinform
{
    public class OrderDetails
    {

        public uint Index { get; set; } //序号

        public String GoodsName { get; set; }

        public uint Quantity { get; set; }

        public double Price { get; set; }

        public OrderDetails() { }

        public OrderDetails(uint index, String goodsName, double price, uint quantity)
        {
            this.Index = index;
            this.GoodsName = goodsName;
            this.Price = price;
            this.Quantity = quantity;
        }

        public double TotalPrice
        {
            get => Price * Quantity;
        }


        public override string ToString()
        {
            return $"[No.:{Index},goods:{GoodsName},quantity:{Quantity},totalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderDetails;
            return item != null &&
                   GoodsName == item.GoodsName;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}

