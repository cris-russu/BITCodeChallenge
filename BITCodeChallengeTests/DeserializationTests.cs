using BITCodeChallenge.Logic;
using BITCodeChallenge.Models;
using NUnit.Framework;

namespace BITCodeChallengeTests
{
    public class DeserializationTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]        
        public void DeserializationTest1()
        {
            var inputXMLPath = GetPathToResource("InputFile.xml");
            WebOrderModel WOModel = WebOrderHelpers.DeserializeToObject<WebOrderModel>(inputXMLPath);
            
            var expected = 42;
            var actual = WOModel.ID;

            Assert.AreEqual(expected, actual);


        }

        //Utility method. Was too lazy to look into proper System.Reflection-docs 
        private static string GetPathToResource(string nameOfFile)
        {
            var pathArray = System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\');
            string newPath = string.Empty;

            foreach (var item in pathArray)
            {
                if (!item.Equals("bin"))
                {
                    newPath = newPath + item + "\\";
                }
                else break;
            }
            return newPath + "Resources\\" + nameOfFile;
        }
    }

    
}