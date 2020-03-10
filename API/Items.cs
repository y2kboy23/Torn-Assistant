using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Torn_Assistant.API
{
    public class Items
    {
        public List<JToken> totalItemsList { get; set; }

        //Constructor
        public Items(List<JToken> items) => 
            (this.totalItemsList) = (items);

        //default constructor
        public Items() { }

        /// <summary>
        /// Returns List if List - (True) Vendor Profit, (False) Market Profit
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemDetails>> createItemsList(bool vendorList)
        {
            List<ItemDetails> totalItemDetails = new List<ItemDetails>();
            JProperty jProperty;

            foreach (JToken jToken in totalItemsList)
            {
                jProperty = (JProperty)jToken.Parent;

                totalItemDetails.Add(new ItemDetails
                {
                    itemNumber = jProperty.Name,
                    name = jToken.Value<string>("name"),
                    description = jToken.Value<string>("description"),
                    effect = jToken.Value<string>("effect"),
                    requirement = jToken.Value<string>("requirement"),
                    type = jToken.Value<string>("type"),
                    weapon_type = jToken.Value<string>("weapon_type"),
                    buy_price = jToken.Value<double>("buy_price"),
                    sell_price = jToken.Value<double>("sell_price"),
                    market_valuation = jToken.Value<double>("market_value"),
                    circulation = jToken.Value<double>("circulation"),
                    image = jToken.Value<string>("image"),
                    //Vendor profit - money made selling to vendor
                    vendorProfit = (jToken.Value<double>("sell_price") - jToken.Value<double>("market_value")),
                    //Market profit - money made selling to market
                    marketProfit = (jToken.Value<double>("market_value") - jToken.Value<double>("buy_price"))
                });

            }//end foreach

            if (vendorList) { return totalItemDetails.OrderByDescending(o => o.vendorProfit).ToList(); }
            else { return totalItemDetails.OrderByDescending(o => o.marketProfit).ToList(); }
        }
        public ItemDetails GetItemDetails(string name)
        {
            JToken item = totalItemsList.Find(x => x.Value<string>("name") == name);
            JProperty itemProperty = (JProperty)item.Parent;

            return new ItemDetails 
            {
                itemNumber = itemProperty.Name,
                name = item.Value<string>("name"),
                description = item.Value<string>("description"),
                effect = item.Value<string>("effect"),
                requirement = item.Value<string>("requirement"),
                type = item.Value<string>("type"),
                weapon_type = item.Value<string>("weapon_type"),
                buy_price = item.Value<double>("buy_price"),
                sell_price = item.Value<double>("sell_price"),
                market_valuation = item.Value<double>("market_value"),
                circulation = item.Value<double>("circulation"),
                image = item.Value<string>("image"),
                vendorProfit = item.Value<double>("sell_price") - item.Value<double>("market_valuation"),
                marketProfit = item.Value<double>("market_valuation") - item.Value<double>("buy_price")
            };
        }

    }

    public class ItemDetails
    {
        public string itemNumber { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string effect { get; set; }
        public string requirement { get; set; }
        public string type { get; set; }
        public string weapon_type { get; set; }
        public double buy_price { get; set; }
        public double sell_price { get; set; }
        public double market_valuation { get; set; }
        public double circulation { get; set; }
        public string image { get; set; }
        public double vendorProfit { get; set; }
        public double marketProfit { get; set; }

        //default constructor
        public ItemDetails() { }

    }

    public class BazaarDetails : IMarketDetails
    {
        public double itemID { get; set; }
        public string itemName { get; set; }
        public double vendorProfit { get; set; }
        public double bazaarID { get; set; }
        public double cost { get; set; }
        public double quantity { get; set; }

        //constructor
        public BazaarDetails(string _itemID, string _itemName, double _vendorProfit, string jtokenBazarrID, string jtokenCost, string jtokenQuantity)
        => (this.itemID, this.itemName, this.vendorProfit, this.bazaarID, this.cost, this.quantity) 
            = (Convert.ToDouble(_itemID), _itemName, _vendorProfit, Convert.ToDouble(jtokenBazarrID), Convert.ToDouble(jtokenCost), Convert.ToDouble(jtokenQuantity));

        //default constructor
        public BazaarDetails() { }

    }

    public class ItemMarketDetails : IMarketDetails
    {
        public double itemID { get; set; }
        public string itemName { get; set; }
        public double vendorProfit { get; set; }
        public double itemMarketID { get; set; }
        public double cost { get; set; }
        public double quantity { get; set; }

        //default constructor
        public ItemMarketDetails(string _itemID, string _itemName, double _vendorProfit, string jtokenMarketID, string jtokenCost, string jtokenQuantity)
            => (this.itemID, this.itemName, this.vendorProfit, this.itemMarketID, this.cost, this.quantity)
            = (Convert.ToDouble(_itemID), _itemName, _vendorProfit, Convert.ToDouble(jtokenMarketID), Convert.ToDouble(jtokenCost), Convert.ToDouble(jtokenQuantity));

        //default constructor
        public ItemMarketDetails() { }
    }

    public interface IMarketDetails
    {
        double itemID { get; set; }
        string itemName { get; set; }
        double vendorProfit { get; set; }
        double cost { get; set; }
        double quantity { get; set; }
    }
}
