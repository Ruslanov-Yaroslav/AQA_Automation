using System.Data.SqlClient;
using Dapper;
using NUnit.Framework;
using System.Linq;
using DBs.Models;
using System.Collections.Generic;

namespace DBs
{
     class Program
     {
        private readonly string _conectionString = @"Data Source=localhost\SQLEXPRESS;Database=master;Integrated Security=True";
        static void Main(string[] args)
        {
        }

        [Test]
        public void CarsNotFromMainCity()
        {
            string query = "select p.FirstName , p.LastName FROM Person as p " +
                             "INNER JOIN BuyersInfo b on b.CityID = p.CityID " +
                             "WHERE p.ID != b.PersonID";
            using (var conn = new SqlConnection(_conectionString))
            {
                var aff = conn.Query(query);
                Assert.IsNotNull(aff);
            }
        }


        [Test]
        public void AgeInBayersInfo()
        {
            using (var conn = new SqlConnection(_conectionString))
            {
                var affOldestFromBayersInfo = conn.Query<BuyersInfo>("SELECT * FROM BuyersInfo");
                var affYangestBayerInPerson = conn.Query<Person>("SELECT * FROM Person");

                List<int> yearsF = new List<int>();
                List<int> yearsS = new List<int>();

                foreach (var a in affOldestFromBayersInfo) yearsF.Add(a.Year);

                foreach (var a in affYangestBayerInPerson) yearsS.Add(a.Year);

                Assert.True(yearsF.Min() <= yearsS.Max());
            }
        }

        //Must be FALSE
        [Test]
        public void AreAllPersonsBoughtCar()
        {
            using (var conn = new SqlConnection(_conectionString))
            {
                var qver = conn.Query<BuyersInfo>("SELECT * FROM BuyersInfo");
                List<int> idis = new List<int>();
                List<int> f = new List<int> { 1, 2, 3, 4, 5 };

                foreach (var a in qver) idis.Add(a.PersonalID);

                Assert.IsTrue(f.All(x => idis.Contains(x)));
            }
        }
    }
}

