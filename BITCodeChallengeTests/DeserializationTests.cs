using BITCodeChallenge.Logic;
using BITCodeChallenge.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BITCodeChallengeTests
{
    public class DeserializationTests
    {
        private static IEnumerable<string> ValidInputFiles()
        {
            yield return GetPathToResource("InputFile.xml");
            yield return GetPathToResource("InputFile_largeNumbers.xml");
            yield return GetPathToResource("InputFile_AliceZoltan.xml");
            yield return GetPathToResource("InputFile_JoanHarper.xml");
        }

        private static IEnumerable<string> DeserializingFailInputFiles()
        {
            yield return GetPathToResource("InputFile_emptyId.xml");
            yield return GetPathToResource("InputFile_wrongTypeQuantity.xml");
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test, TestCaseSource("ValidInputFiles")]
        public void DeserializationTest1(string inputXMLPath)
        {
            WebOrderModel WOModel = WebOrderHelpers.DeserializeToObject<WebOrderModel>(inputXMLPath);

            if ((WOModel.ID.GetType().Equals(typeof(int)))
                & (WOModel.Customer.GetType().Equals(typeof(string)))
                & (WOModel.Date.GetType().Equals(typeof(string)))
                & (WOModel.AvgUnitPrice.GetType().Equals(typeof(decimal)))
                & (WOModel.Total.GetType().Equals(typeof(decimal))))
                Assert.Pass();
            else Assert.Fail();
        }

        [Test, TestCaseSource("DeserializingFailInputFiles")]
        public void DeserializationTest2(string inputXMLPath)
        {
            Assert.That(() => WebOrderHelpers.DeserializeToObject<WebOrderModel>(inputXMLPath), Throws.Exception);
        }


        // Utility method. Was too lazy to look into proper System.Reflection-docs 
        private static string GetPathToResource(string nameOfFile)
        {
            var pathArray = System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\');
            string newPath = string.Empty;

            foreach (var item in pathArray)
            {
                if (!item.ToLower().Equals("bin"))
                {
                    newPath = newPath + item + "\\";
                }
                else break;
            }
            return newPath + "Resources\\" + nameOfFile;
        }



    }


}