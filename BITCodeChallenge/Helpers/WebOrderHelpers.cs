using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace BITCodeChallenge.Logic
{
    public static class WebOrderHelpers
    {
        private readonly static string datePattern = "yyyyMMdd";

        public static T DeserializeToObject<T>(string filepath) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using StreamReader sr = new StreamReader(filepath);
            return (T)ser.Deserialize(sr);
        }

      
        public static DateTime GetParsedDate(string dateString)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(dateString, datePattern, null, DateTimeStyles.None, out parsedDate))
                return DateTime.ParseExact(dateString, datePattern, CultureInfo.InvariantCulture);
            else
                return parsedDate;

        }


    }
}
