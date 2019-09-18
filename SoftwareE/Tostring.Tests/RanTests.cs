using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Tests
{
    [TestClass()]
    public class RanTests
    {
        [TestMethod()]
        public void getOperatorTest()
        {
            Ran rt1 = new Ran();
            Random rand = new Random();
            int d = rand.Next(4);
            char c = Ran.getOperator();
            char f;
            switch (d)
            {
                case 0:
                    d = '+';
                    break;
                case 1:
                    d = '-';
                    break;
                case 2:
                    d = '*';
                    break;
                case 3:
                    d = '/';
                    break;
            }
            Assert.AreEqual(c, d);
        }
    }
}