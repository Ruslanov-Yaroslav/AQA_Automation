using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DBs.Entyty
{
    public class Test
    {
        [Test]
        public void CityContains()
        {
            using(var context = new masterEntities())
            {
                var person = context.Person
                    .Where(p => p.City.CityName == "Paradise")
                    .Select(p => new
                    {
                        p.FirstName,
                        p.City.CityName
                    })
                    .ToList();
                Assert.AreEqual(2, person.Count());
            }
        }

        [Test]
        public void SecondTestFromDupper()
        {
            using(var context = new masterEntities())
            {
                var bayer = context.BuyersInfo.Select(b => b.Year);
                var pers = context.Person.Select(p => p.Year);
                Assert.True(bayer.Min() <= pers.Max());
            }
        }

        //Must be FALSE
        [Test]
        public void ThirdTestFromDapper()
        {
            using (var context = new masterEntities())
            {
                var bayer = context.BuyersInfo.Select(b => b.PersonID);
                List<int> f = new List<int> { 1, 2, 3, 4, 5 };
                Assert.True(f.All(x => bayer.Contains(x)));
            }
        }
    }
}
