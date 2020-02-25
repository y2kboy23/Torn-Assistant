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
            List<ItemDetails> profit = new List<ItemDetails>();

            foreach (JToken jToken in totalItemsList)
            {
                string itemNumber;
                string itemName;
                string itemDescription;
                string itemEffect;
                string itemRequirement;
                string itemType;
                string itemWeaponType;
                double itemBuyPrice;
                double itemSellPrice;
                double itemMarketValue;
                double itemCirculation;
                string itemImage;
                double vendorProfit;
                double marketProfit;
                JProperty jProperty;

                jProperty = (JProperty)jToken.Parent;
                itemNumber = jProperty.Name;

                itemName = jToken.Value<string>("name");
                itemDescription = jToken.Value<string>("description");
                itemEffect = jToken.Value<string>("effect");
                itemRequirement = jToken.Value<string>("requirement");
                itemType = jToken.Value<string>("type");
                itemWeaponType = jToken.Value<string>("weapon_type");
                itemBuyPrice = jToken.Value<double>("buy_price");
                itemSellPrice = jToken.Value<double>("sell_price");
                itemMarketValue = jToken.Value<double>("market_value");
                itemCirculation = jToken.Value<double>("circulation");
                itemImage = jToken.Value<string>("image");
                //Vendor profit - money made selling to vendor
                vendorProfit = itemSellPrice - itemMarketValue;
                //Market profit - money made selling to market
                marketProfit = itemMarketValue - itemBuyPrice;


                ItemDetails itemDeatils = new ItemDetails(itemNumber, itemName, itemDescription, itemEffect, itemRequirement, itemType, itemWeaponType, itemBuyPrice, itemSellPrice, itemMarketValue,
                    itemCirculation, itemImage, vendorProfit, marketProfit);
                totalItemDetails.Add(itemDeatils);

            }//end foreach

            if (vendorList) { profit = totalItemDetails.OrderByDescending(o => o.vendorProfit).ToList(); totalItemDetails.Clear(); }
            else { profit = totalItemDetails.OrderByDescending(o => o.marketProfit).ToList(); totalItemDetails.Clear(); }

            return profit;
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

        //constructor
        public ItemDetails(string idNumber, string idName, string idDesctription, string idEffect, string idRequirement, string idType, string idWeaponType, double idBuyPrice, double idSellPrice, double idMarketValue,
            double idCirculation, string idImage, double idVendorProfit, double idMarketProfit)
        {
            itemNumber = idNumber;
            name = idName;
            description = idDesctription;
            effect = idEffect;
            requirement = idRequirement;
            type = idType;
            weapon_type = idWeaponType;
            buy_price = idBuyPrice;
            sell_price = idSellPrice;
            market_valuation = idMarketValue;
            circulation = idCirculation;
            image = idImage;
            vendorProfit = idVendorProfit;
            marketProfit = idMarketProfit;
        }

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
        {
            itemID = Convert.ToDouble(_itemID);
            itemName = _itemName;
            vendorProfit = _vendorProfit;
            bazaarID = Convert.ToDouble(jtokenBazarrID);
            cost = Convert.ToDouble(jtokenCost);
            quantity = Convert.ToDouble(jtokenQuantity);

        }

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
        {
            itemID = Convert.ToDouble(_itemID);
            itemName = _itemName;
            vendorProfit = _vendorProfit;
            itemMarketID = Convert.ToDouble(jtokenMarketID);
            cost = Convert.ToDouble(jtokenCost);
            quantity = Convert.ToDouble(jtokenQuantity);

        }

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
