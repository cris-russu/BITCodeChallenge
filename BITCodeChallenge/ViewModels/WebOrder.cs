using BITCodeChallenge.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BITCodeChallenge.ViewModels
{
    public class WebOrder
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public double PriceAvg { get; set; }
        public int Amount { get; set; }

        public WebOrder()
        {

        }

        public WebOrder(WebOrderModel webOrderModel)
        {
            ID = webOrderModel.ID;
            Customer = webOrderModel.Customer;
            Date = webOrderModel.GetParsedDate();
            Amount = webOrderModel.Items.Sum(i => i.Quantity);
            Total = webOrderModel.Items.Select(x => x.Price * x.Quantity).Sum();
            PriceAvg = webOrderModel.Items.Average(i => i.Price);             
        }

        public override string ToString()
        {
            return $"ID: {ID} {Environment.NewLine}" +
                $"Customer: {Customer} {Environment.NewLine}" +
                $"Date: {Date} {Environment.NewLine}" +
                $"Price average: {PriceAvg} {Environment.NewLine}" +
                $"Amount of items: {Amount} {Environment.NewLine}"+
                $"Total: {Total} {Environment.NewLine}";
        }

    }
}
