using BITCodeChallenge.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace BITCodeChallenge.ViewModels
{
    public class WebOrder
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public string Total { get; set; }
        public string PriceAvg { get; set; }
        public int Amount { get; set; }

        public WebOrder()
        {

        }

        public WebOrder(WebOrderModel webOrderModel)
        {
            double total, priceAvg;

            ID = webOrderModel.ID;
            Customer = webOrderModel.Customer;
            Date = webOrderModel.GetParsedDate();
            Amount = webOrderModel.Items.Sum(i => i.Quantity);
            total = webOrderModel.Items.Select(x => x.Price * x.Quantity).Sum();
            Total = string.Format("{0: #,000.000}", total).Trim();
            priceAvg = webOrderModel.Items.Average(i => i.Price);
            PriceAvg = string.Format("{0: #,000.000}", priceAvg).Trim();
        }

        public override string ToString()
        {
            return $"ID: {ID} {Environment.NewLine}" +
                $"Customer: {Customer} {Environment.NewLine}" +
                $"Date: {Date} {Environment.NewLine}" +
                $"Price average: {PriceAvg} {Environment.NewLine}" +
                $"Amount of items: {Amount} {Environment.NewLine}" +
                $"Total: {Total} {Environment.NewLine}";
        }

    }
}
