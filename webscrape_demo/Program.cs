using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ScrapySharp.Network;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html.Forms;

namespace webscrape_demo
{

    class Program
    {
        static void Main(string[] args)
        {
            var browser = new ScrapingBrowser()
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true
            };

            //Variable to store the site to scrape
            var pageResult = browser.NavigateToPage(new Uri("http://money.cnn.com/data/markets/"));
            //Store title based on CSS class
            var titleNode = pageResult.Html.CssSelect(".module-header").First();
            var pageTitle = titleNode.InnerText;



            //Console display for testing and demonstration
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("Scraping most popular stocks from CNN Money...");
            Console.WriteLine();
            

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(pageTitle);
            Console.ResetColor();

            Console.WriteLine();

            //Store scraped items in specified CSS class
            List<String> names = new List<string>();
            var table = pageResult.Html.CssSelect(".most-popular-stocks").First();

            //Loop through Table element and store selections based on specified element 
                foreach (var row in table.SelectNodes("li"))
            {
                if (row.InnerText != "")
                {
                    names.Add(row.InnerText);
                }
            }

            var stocks = new Stock();
            stocks.AddToDb(names);



        }
    }
}
