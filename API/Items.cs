using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Torn_Assistant.API
{
    public class Items
    {
        List<JToken> totalItems;
        List<ItemDetails> totalItemDetails = new List<ItemDetails>();
        List<ItemDetails> profit = new List<ItemDetails>();

        //Constructor
        public Items(List<JToken> items)
        {
            totalItems = items;
        }

        /// <summary>
        /// Returns List if List - (True) Vendor Profit, (False) Market Profit
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemDetails>> createItemsList(bool vendorList)
        {
            foreach (JToken jToken in totalItems)
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

    }

    public class BazaarDetails : IMarketDetails
    {
        public double itemID { get; }
        public string itemName { get; }
        public double vendorProfit { get; }
        public double bazaarID { get; }
        public double cost { get; }
        public double quantity { get; }

        //default constructor
        public BazaarDetails(string _itemID, string _itemName, double _vendorProfit, string jtokenBazarrID, string jtokenCost, string jtokenQuantity)
        {
            itemID = Convert.ToDouble(_itemID);
            itemName = _itemName;
            vendorProfit = _vendorProfit;
            bazaarID = Convert.ToDouble(jtokenBazarrID);
            cost = Convert.ToDouble(jtokenCost);
            quantity = Convert.ToDouble(jtokenQuantity);

        }

    }

    public class ItemMarketDetails : IMarketDetails
    {
        public double itemID { get; }
        public string itemName { get; }
        public double vendorProfit { get; }
        public double itemMarketID { get; }
        public double cost { get; }
        public double quantity { get; }

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

    }

    public interface IMarketDetails
    {
        double itemID { get; }
        string itemName { get; }
        double vendorProfit { get; }
        double cost { get; }
        double quantity { get; }

    }
}
