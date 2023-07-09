using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoodOrderingSystemTests
{
    [TestClass]
    class FoodTests
    {
        [TestMethod]
        public void CheckCapitalization()
        {
            List<string> inits = new List<string>() { "appetizer", "sAlAD", "Pizza" };
            List<string> results = new List<string>();
            List<string> corrects = new List<string>() { "Apptizer", "SAlAD", "Pizza" };
            foreach(string category in inits)
            {
                string copy = category[0].ToString();
                copy = copy.ToUpper();
                for (int i = 1; i < category.Length; i++)
                    copy += category[i];
                results.Add(copy);
            }

            CollectionAssert.AreEqual(corrects, results);
        }
    }
}
