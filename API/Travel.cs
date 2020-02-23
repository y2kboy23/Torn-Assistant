using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torn_Assistant.API;

namespace Torn_Assistant.API
{
    public class Travel
    {

        List<Destination> destinations = new List<Destination>
        {
            new Destination
            {
                name = "UK",
                flightTime = TimeSpan.Parse("02:39:00"),
                oneWayTicketCost = 18000,
                marketStock = new List<string>
                {
                    "Heather",
                    "Nessie Plushie",
                    "Red Fox Plushie"
                }
            },
            new Destination
            {
                name = "Mexico",
                flightTime = TimeSpan.Parse("00:26:00"),
                oneWayTicketCost = 6500,
                marketStock = new List<string>
                {
                    "Dahlia",
                    "Jaguar Plushie"
                }
            },
            new Destination
            {
                name = "Cayman Islands",
                flightTime = TimeSpan.Parse("00:35:00"),
                oneWayTicketCost = 10000,
                marketStock = new List<string>
                {
                    "Banana Orchid",
                    "Stingray Plushie"
                }
            },
            new Destination
            {
                name = "Canada",
                flightTime = TimeSpan.Parse("00:41:00"),
                oneWayTicketCost = 9000,
                marketStock = new List<string>
                {
                    "Crocus",
                    "Wolverine Plushie"
                }
            },
            new Destination
            {
                name = "Hawaii",
                flightTime = TimeSpan.Parse("02:14:00"),
                oneWayTicketCost = 11000,
                marketStock = new List<string>
                {
                    "Orchid"
                }
            },
            new Destination
            {
                name = "Argentina",
                flightTime = TimeSpan.Parse("02:47:00"),
                oneWayTicketCost = 21000,
                marketStock = new List<string>
                {
                    "Monkey Plushie",
                    "Ceibo Flower"
                }
            },
            new Destination
            {
                name = "Switzerland",
                flightTime = TimeSpan.Parse("02:55:00"),
                oneWayTicketCost = 27000,
                marketStock = new List<string>
                {
                    "Chamois Plushie",
                    "Edelweiss"
                }
            },
            new Destination
            {
                name = "Japan",
                flightTime = TimeSpan.Parse("03:45:00"),
                oneWayTicketCost = 32000,
                marketStock = new List<string>
                {
                    "Cherry Blossom"
                }
            },
            new Destination
            {
                name = "China",
                flightTime = TimeSpan.Parse("04:02:00"),
                oneWayTicketCost = 35000,
                marketStock = new List<string>
                {
                    "Peony",
                    "Panda Plushie"
                }
            },
            new Destination
            {
                name = "UAE",
                flightTime = TimeSpan.Parse("04:31:00"),
                oneWayTicketCost = 32000,
                marketStock = new List<string>
                {
                    "Tribulus Omanense",
                    "Camel Plushie"
                }
            },
            new Destination
            {
                name = "South Africa",
                flightTime = TimeSpan.Parse("04:57:00"),
                oneWayTicketCost = 40000,
                marketStock = new List<string>
                {
                    "African Violet",
                    "Lion Plushie"
                }
            }
        };

        public List<itemProfit> CalculateProfitPerMinute(List<ItemDetails> imports, int bonusTravelItems)
        {
            List<itemProfit> profitPerMin = new List<itemProfit>();

            foreach (Destination location in destinations)
            {
                foreach (string item in location.marketStock)
                {
                    ItemDetails data = imports.Find(x => x.name == item);
                    profitPerMin.Add(new itemProfit
                    {
                        name = data.name,
                        county = location.name,
                        profitMin = Convert.ToDecimal(((data.marketProfit * (5 + bonusTravelItems)) - (2 * location.oneWayTicketCost)) / location.flightTime.TotalMinutes)
                    });
                }
            }
            return new List<itemProfit>(profitPerMin.OrderByDescending(x => x.profitMin).ToList<itemProfit>());
        }
    }

    public class Destination
    {
        public string name { get; set; }
        public TimeSpan flightTime { get; set; }
        public int oneWayTicketCost { get; set; }
        public List<string> marketStock { get; set; }
    }

    public class itemProfit
    {
        public string name { get; set;}
        public string county { get; set; }
        public decimal profitMin { get; set; }
    }
}
