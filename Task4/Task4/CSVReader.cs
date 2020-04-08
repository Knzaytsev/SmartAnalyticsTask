using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class CSVReader : IReader
    {
        private string connectionString = @"..\..\data\SalesData.csv";

        public CSVReader() { }

        public CSVReader(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Country> ReadCountriesByYear(int year)
        {
            var countries = new List<Country>();
            using (var reader = new StreamReader(connectionString))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var data = line.Split(',');
                    if (data[0] != year.ToString())
                        continue;
                    var country = new Country()
                    {
                        Name = data[2],
                        CountOrders = int.Parse(data[5])
                    };
                    countries.Add(country);
                }
            }

            var query = from c in countries
                        group c by c.Name into g
                        select new Country()
                        {
                            Name = g.Key,
                            CountOrders = g.Sum(x => x.CountOrders)
                        };

            return query.OrderByDescending(x => x.CountOrders).Take(10).ToList();
        }

        public List<int> ReadYear()
        {
            var years = new List<int>();
            using (var reader = new StreamReader(connectionString))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var year = line.Split(',')[0];
                    years.Add(int.Parse(year));
                }
            }
            return years.Distinct().ToList();
        }
    }
}
