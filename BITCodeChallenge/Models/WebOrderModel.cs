using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace BITCodeChallenge.Models
{
    [XmlRoot(ElementName = "WebOrder")]
    public class WebOrderModel
    {
        private string datePattern = "yyyyMMdd";
        
        [XmlAttribute("id")]
        public int ID { get; set; }
        
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
        
        [XmlElement(ElementName = "Customer")]
        public string Customer { get; set; }
        
        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<ItemModel> Items = new List<ItemModel>();

        public double Total { get; set; }
        public double AvgUnitPrice { get; set; }
        public WebOrderModel()        {
            
        }

        public DateTime GetParsedDate()
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(Date, datePattern, null, System.Globalization.DateTimeStyles.None, out parsedDate))
                return DateTime.ParseExact(Date, datePattern, CultureInfo.InvariantCulture );
            else
                return parsedDate; 
            
        }
        
        public T DeserializeToObject<T>(string filepath) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public override string ToString()
        {
            string returnString = $"WebOrder ID: {ID} " +
                                  $"{Environment.NewLine} Customer: {Customer}" +
                                  $"{Environment.NewLine} Date: {Date}" +
                                  $"{Environment.NewLine}";

            foreach (var item in Items)
            {
                returnString = returnString + item.ToString();

            }

            return returnString;
        }

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

        public override string ToString()
        {
            return $"------------------------ {Environment.NewLine}" +
                   $"Item ID: {ID} {Environment.NewLine}" +
                   $"Description: {Description} {Environment.NewLine}" +
                   $"Quantity: {Quantity} {Environment.NewLine}" +
                   $"Price: {Price} {Environment.NewLine}";
        }

    }


}
