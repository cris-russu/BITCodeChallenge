using System.Collections.Generic;
using System.Xml.Serialization;

namespace BITCodeChallenge.Models
{
    [XmlRoot(ElementName = "WebOrder")]
    public class WebOrderModel
    {        
        [XmlAttribute("id")]
        public int ID { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }

        [XmlElement(ElementName = "Customer")]
        public string Customer { get; set; }

        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<ItemModel> Items = new List<ItemModel>();

        public decimal Total { get; set; }
        public decimal AvgUnitPrice { get; set; }
        public WebOrderModel()
        {

        }       

        // ToString() used early-on for some basic white-testing
        //public override string ToString()
        //{
        //    string returnString = $"WebOrder ID: {this.ID} " +
        //                          $"{Environment.NewLine} Customer: {Customer}" +
        //                          $"{Environment.NewLine} Date: {Date}" +
        //                          $"{Environment.NewLine}";

        //    foreach (var item in Items)
        //    {
        //        returnString = returnString + item.ToString();

        //    }

        //    return returnString;
        //}
    }


    [XmlType("Item")]
    public class ItemModel
    {

        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "Price")]
        public double Price { get; set; }

        public ItemModel()
        {

        }

        // ToString() used early-on for some basic white-testing

        //public override string ToString()
        //{
        //    return $"------------------------ {Environment.NewLine}" +
        //           $"Item ID: {ID} {Environment.NewLine}" +
        //           $"Description: {Description} {Environment.NewLine}" +
        //           $"Quantity: {Quantity} {Environment.NewLine}" +
        //           $"Price: {Price} {Environment.NewLine}";
        //}

    }


}
