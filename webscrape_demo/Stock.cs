using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace webscrape_demo
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Change { get; set; }

        public void AddToDb(List<string> names)
        {
            // Iterate over scraped DATA and apply to Stock object properties
            for (var i = 0; i < names.Count - 1; i++)
            {
                var newStock = new Stock();

                var reg = new Regex("[a-z]");

                var stockArr = names[i].Trim().Split(' ');

                if (reg.IsMatch(stockArr[1]))
                {
                    newStock.Name = stockArr[0] + stockArr[1];
                    newStock.Price = stockArr[2];
                    newStock.Change = stockArr[3];
                }
                else
                {
                    newStock.Name = stockArr[0];
                    newStock.Price = stockArr[1];
                    newStock.Change = stockArr[2];
                }

                //Use entity framework to store Stock objects in SQL db
                using (var dbContext = new StockEntity())
                {
                    dbContext.Stocks.Add(newStock);
                    dbContext.SaveChanges();
                }
                Console.WriteLine(names[i].Trim());
            }
        }
    }
}