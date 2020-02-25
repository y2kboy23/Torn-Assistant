using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torn_Assistant.API
{
    public class Museum
    {
        private MuseumSets plushies = new MuseumSets
        {
            items = new List<string>{
                "Jaguar Plushie",
                "Lion Plushie",
                "Panda Plushie",
                "Monkey Plushie",
                "Chamois Plushie",
                "Wolverine Plushie",
                "Nessie Plushie",
                "Red Fox Plushie",
                "Camel Plushie",
                "Kitten Plushie",
                "Teddy Bear Plushie",
                "Sheep Plushie",
                "Stingray Plushie" },
            pointsReceived = 10
        };

        private MuseumSets exoticFlowers = new MuseumSets
        {
            items = new List<string>
            {
                "Dahlia",
                "Orchid",
                "African Violet",
                "Cherry Blossom",
                "Peony",
                "Ceibo Flower",
                "Edelweiss",
                "Crocus",
                "Heather",
                "Tribulus Omanense",
                "Banana Orchid"
            },
            pointsReceived = 10
        };

        private MuseumSets medievalCoins = new MuseumSets
        {
            items = new List<string>{
                "Leopard Coin",
                "Florin Coin",
                "Gold Noble Coin" },
            pointsReceived = 100
        };

        private MuseumSets vairocanaBuddha = new MuseumSets { items = new List<string> { "Vairocana Buddha Sculpture" }, pointsReceived = 100 };
        private MuseumSets ganeshaSculpture = new MuseumSets { items = new List<string> { "Ganesha Sculpture" }, pointsReceived = 250 };
        private MuseumSets shabtiSculpture = new MuseumSets { items = new List<string> { "Shabti Sculpture" }, pointsReceived = 500 };
        private MuseumSets scriptsFromTheQuran = new MuseumSets
        {
            items = new List<string> 
            {
                "Quran Script : Ibn Masud",
                "Quran Script : Ubay Ibn Kab",
                "Quran Script : Ali"
            },
            pointsReceived = 1000
        };
        private MuseumSets senetGame = new MuseumSets
        {
            items = new List<string>
            {
                "Senet Board",
                "White Senet Pawn",
                "Black Senet Pawn"
            },
            pointsReceived = 2000
        };
        private MuseumSets egyptianAmulet = new MuseumSets
        {
            items = new List<string> { "Egyptian Amulet" },
            pointsReceived = 10000
        };

        public Items totalItems { get; set; }
        public Points pointsValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="set">Valid Options: plushies, flowers, medievalcoins, vairocanabuddha,
        /// ganeshasculpture, shabtisculpture, scriptsfromthequran, senetgame, egyptianamulet</param>
        /// <returns></returns>
        public int CalculateSetProfit(string set)
        {
            List<ItemDetails> items = new List<ItemDetails>();
            int cost = 0;
            int profit = 0;

            switch (set)
            {
                case "plushies":
                    foreach (string name in plushies.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * plushies.pointsReceived) - cost;
                    break;
                case "flowers":
                    foreach (string name in exoticFlowers.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * exoticFlowers.pointsReceived) - cost;
                    break;
                case "medievalcoins":
                    foreach (string name in medievalCoins.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * medievalCoins.pointsReceived) - cost;
                    break;
                case "vairocanabuddha":
                    foreach (string name in vairocanaBuddha.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * vairocanaBuddha.pointsReceived) - cost;
                    break;
                case "ganeshasculpture":
                    foreach (string name in ganeshaSculpture.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * ganeshaSculpture.pointsReceived) - cost;
                    break;
                case "shabtisculpture":
                    foreach (string name in shabtiSculpture.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * shabtiSculpture.pointsReceived) - cost;
                    break;
                case "scriptsfromthequran":
                    foreach (string name in scriptsFromTheQuran.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * scriptsFromTheQuran.pointsReceived) - cost;
                    break;
                case "senetgame":
                    foreach (string name in senetGame.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * senetGame.pointsReceived) - cost;
                    break;
                case "egyptianamulet":
                    foreach (string name in egyptianAmulet.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    foreach (ItemDetails item in items)
                    {
                        cost += Convert.ToInt32(item.market_valuation);
                    }
                    profit = (pointsValue.pointsPrice * egyptianAmulet.pointsReceived) - cost;
                    break;
            }
            return profit;
        }

        public List<ItemDetails> CreateSetItemList(string set)
        {
            List<ItemDetails> items = new List<ItemDetails>();

            switch (set)
            {
                case "plushies":
                    foreach (string name in plushies.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "flowers":
                    foreach (string name in exoticFlowers.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "medievalcoins":
                    foreach (string name in medievalCoins.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "vairocanabuddha":
                    foreach (string name in vairocanaBuddha.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "ganeshasculpture":
                    foreach (string name in ganeshaSculpture.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "shabtisculpture":
                    foreach (string name in shabtiSculpture.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "scriptsfromthequran":
                    foreach (string name in scriptsFromTheQuran.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "senetgame":
                    foreach (string name in senetGame.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
                case "egyptianamulet":
                    foreach (string name in egyptianAmulet.items)
                    {
                        items.Add(totalItems.GetItemDetails(name));
                    }
                    break;
            }
            return items;
        }
    }

    public class MuseumSets
    {
        public List<string> items { get; set; }
        public int pointsReceived { get; set; }
    }
    public class Points
    {
        public int pointsPrice { get; set; }
    }

    public class PointsData : IEnumerable<Points>
    {
        List<Points> pointsData { get; set; }

        public IEnumerator<Points> GetEnumerator()
        {
            foreach (Points data in pointsData)
            {
                yield return data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return pointsData.GetEnumerator();
        }
    }
}
