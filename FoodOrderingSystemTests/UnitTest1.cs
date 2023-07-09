using System;
using FoodOrderingSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderingSystemTests
{
    [TestClass]
    public class UnitTestUsers
    {
        //[TestMethod]
        //public void TestCheckNamePatternValidity()
        //{
        //    string fullNamePattern = @"^([A-Za-z]+)$";
        //    List<string> fullNames = new List<string>() { "ali amiri", "ali ", " ali", "ali", "ali21" };
        //    List<bool> checks = new List<bool>();
        //    foreach(string fullName in fullNames)
        //    {
        //        checks.Add(UsersManager.CheckPatternValidity(fullName, fullNamePattern));
        //    }
        //    List<bool> expecteds = new List<bool> { false, false, false, true, false };
        //    CollectionAssert.AreEqual(expecteds, checks);
        //}

        //[TestMethod]
        //public void TestCheckEmailPatternValidity()
        //{
        //    string emailPattern =
        //    @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //    List<string> emails = new List<string>()
        //    {
        //        "2000amir1379@gmail.com", "a_roudgar@comp.iust.ac.it", "a_roodgar@yahoo.com", "a.roodgar@outlook.com", "asldad", "alsdasd@ljad@.com",
        //        "asdasd@asds.sdaskldnlasd", "askld@jad.;;s;d;s;d;s;d", "asdasd@awds"
        //    };
        //    List<bool> checks = new List<bool>();
        //    List<bool> expecteds = new List<bool>() { true, true, true, true, false, false, false, false, false };
        //    foreach(string email in emails)
        //    {
        //        checks.Add(UsersManager.CheckPatternValidity(email, emailPattern));
        //    }
        //    CollectionAssert.AreEqual(expecteds, checks);
        //}

        //[TestMethod]
        //public void TestCheckPhoneNumberPatternValidity()
        //{
        //    string phoneNumberPattern = @"^(09|989|\+989|00989)[0-9]{9}$";
        //    List<string> phones = new List<string>()
        //    {
        //        "09199145913", "989199145913", "00989199145913", "+989199145913", "0919914591", "1098232311", "091991459a3", "091991459%3"
        //    };
        //    List<bool> checks = new List<bool>();
        //    List<bool> expecteds = new List<bool>() { true, true, true, true, false, false, false, false };
        //    foreach(string phone in phones)
        //    {
        //        checks.Add(UsersManager.CheckPatternValidity(phone, phoneNumberPattern));
        //    }
        //    CollectionAssert.AreEqual(expecteds, checks);
        //}

        [TestMethod]
        public void TestCheckNationalID()
        {
            List<string> ids = new List<string>() { "0023630000", "6599927531", "0058731199", "10923uedal", "00236300000", "5699927531", "0058731198" };
            List<bool> checks = new List<bool>();
            List<bool> expecteds = new List<bool>() { true, true, true, false, false, false, false };
            foreach(string id in ids)
            {
                try
                {
                    id.CheckNationalID();
                    checks.Add(id.CheckNationalID());
                }
                catch
                {
                    checks.Add(false);
                }
            }
            CollectionAssert.AreEqual(expecteds, checks);
        }

        //[TestMethod]
        //public void TestCheckPassword()
        //{
        //    AdminDataManager adminDataManager = new AdminDataManager();
        //    List<string> passwords = new List<string>() { "0000", "110000", "11100000", "00000", "1111110000" };
        //    List<string> users = new List<string>() { "admintester", "admintester", "adminroudgar", "adminroudgar", "admintester"};
        //    List<int> counts = new List<int>() { 0, 2, 3, 0, 6 };
        //    List<string> checks = new List<string>();
        //    for(int i = 0; i < 5; i++)
        //    {
        //        checks.Add(adminDataManager.CheckPassword(counts[i], users[i]));
        //    }
        //    CollectionAssert.AreEqual(passwords, checks);
        //    
        //}

        [TestMethod]
        public void CheckCapitalization()
        {
            List<string> inits = new List<string>() { "appetizer", "sAlAD", "Pizza" };
            List<string> results = new List<string>();
            List<string> corrects = new List<string>() { "Appetizer", "SAlAD", "Pizza" };
            foreach (string category in inits)
            {
                string copy = category[0].ToString();
                copy = copy.ToUpper();
                for (int i = 1; i < category.Length; i++)
                    copy += category[i];
                results.Add(copy);
            }

            CollectionAssert.AreEqual(corrects, results);
        }

        [TestMethod]
        public void CheckToDateTime()
        {
            string dateString = "7/20/2020 11:00:00 PM";
            bool check = (DateTime)dateString.ToDateTime() > DateTime.Now;
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckToDateOnly()
        {
            string datestring = "7/20/2020 11:00:00 PM";
            string notimeString = "7/20/2020";
            DateTime? date1 = datestring.ToDateOnly();
            DateTime? date2 = notimeString.ToDateOnly();
            CollectionAssert.AreEqual(new List<bool> { true, true }, new List<bool> { ((DateTime)date1).Hour == 0, ((DateTime)date2).Hour == 0 });
        }

        [TestMethod]
        public void CheckToDateTimeOnly()
        {
            string date = "7/20/2020";
            DateTime? d = date.ToDateOnly();
            Assert.AreEqual(0, ((DateTime)d).Hour);
        }

        [TestMethod]
        public void CheckRoll()
        {
            Drawings drawings = new Drawings();
            List<string> idList = drawings.Select().Select(z => z[0]).ToList();
            List<Order> orders = new OrdersDataManager().Select();

            int x = 2;
            List<string> winnerIDs = new List<string>();

            foreach (Order order in orders)
            {
                string priceString = order.totalPrice.ToString();
                int lastFigure = int.Parse(priceString[priceString.Length - 1].ToString());
                if (lastFigure == x && idList.Contains(order.personID))
                {
                    if(!winnerIDs.Contains(order.personID))
                        winnerIDs.Add(order.personID);
                }
            }

            CollectionAssert.AreEqual(new List<string> { "0023630000" }, winnerIDs);
        }
    }
}
