using EnumComposiExe.Entities.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EnumComposiExe.Entities
{
    class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime date, OrderStatus status, Client clients)
        {
            Date = date;
            Status = status;
            Client = clients;
        }
        public void AddItem(OrderItem items)
        {
            Items.Add(items);
        }
        public void RemoveItems(OrderItem items)
        {
            Items.Remove(items); 
        }
        public double TotalPrice()
        {
            double sum = 0.0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Date.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("total price: " + TotalPrice().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
