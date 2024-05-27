using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTests.Tests.Tests
{
    public class CSFeaturesTests
    {
        [Test]
        public void CollectionCanBeInitialized()
        {
            var list = new List<string>() { "India", "USA", "France" };
            Assert.That(list.Count, Is.EqualTo(3));
        }

        [Test]
        public void CanCreateAnonymousObject()
        {
            var p = new { X = 20, Y = 30 };

            Assert.That(p.X, Is.EqualTo(20));
            Assert.That(p.Y, Is.EqualTo(30));
        }


        [Test]
        public void WeGetSameTypeIfWePassSamePropertyInSameOrder()
        {
            var p1 = new { X = 20, Y = 30 };
            var p2 = new { X = 10, Y = 20 };

            Assert.AreEqual(p1.GetType(), p2.GetType());
        }

        [Test]
        public void WeGetDifferentTypeIfWeChangePropertyOrder()
        {
            var p1 = new { X = 20, Y = 30 };
            var p2 = new { Y = 10, X = 20 };
            Assert.AreNotEqual(p1.GetType(), p2.GetType());
        }
    }
}
