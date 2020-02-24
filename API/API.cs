using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torn_Assistant.API
{
    public class API
    {
        private readonly string BaseApiUri;
        private protected string ApiKey;
        string userID;
        private DateTimeOffset lastUpdatedTime;
        private protected MyNetwork myNetwork = new MyNetwork();

        //Torn data
        private protected TornAPISection populationTornData = new TornAPISection();

        //User data
        private protected TornAPISection playerUserData = new TornAPISection();

        //Properties data
        private protected TornAPISection populationPropertiesData = new TornAPISection();

        //Faction data
        private protected TornAPISection populationFactionData = new TornAPISection();

        //Company data
        private protected TornAPISection populationCompanyData = new TornAPISection();

        //Item Market data
        private protected TornAPISection populationItemMarketData = new TornAPISection();

        public API(string uri, string key) =>
            (this.BaseApiUri, this.ApiKey) = (uri, key);

        public async Task UpdateID(string id) => 
            (this.userID) = (id);

        /// <summary>
        /// Valid Selection: torn, user, property, faction, company, itemmarket
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        public async Task UpdateFromAPI(string selection)
        {
            if (myNetwork == null) { myNetwork = new MyNetwork(); }
            try
            {
                switch (selection)
                {
                    case "torn":
                        if (populationTornData.uri == null || DateTimeOffset.UtcNow - populationTornData.uriTimestamp > TimeSpan.FromDays(1))
                        {
                            populationTornData.uri = await CreateUriRequest(selection);
                            populationTornData.uriTimestamp = DateTimeOffset.Now;
                        }
                        populationTornData.apiData = JObject.Parse(await myNetwork.DownloadString(populationTornData.uri));
                        break;
                    case "user":
                        if (playerUserData.uri == null || DateTimeOffset.UtcNow - playerUserData.uriTimestamp > TimeSpan.FromDays(1))
                        {
                            playerUserData.uri = await CreateUriRequest(selection);
                            playerUserData.uriTimestamp = DateTimeOffset.Now;
                        }
                        playerUserData.apiData = JObject.Parse(await myNetwork.DownloadString(playerUserData.uri));
                        if (playerUserData.apiData.Value<string>("player_id") != userID) { userID = playerUserData.apiData.Value<string>("player_id"); }
                        else { }
                        break;
                    case "property":
                        if (populationPropertiesData.uri == null || DateTimeOffset.UtcNow - populationPropertiesData.uriTimestamp > TimeSpan.FromDays(1))
                        {
                            populationPropertiesData.uri = await CreateUriRequest(selection);
                            populationPropertiesData.uriTimestamp = DateTimeOffset.Now;
                        }
                        populationPropertiesData.apiData = JObject.Parse(await myNetwork.DownloadString(populationPropertiesData.uri));
                        break;
                    case "faction":
                        if (populationFactionData.uri == null || DateTimeOffset.UtcNow - populationFactionData.uriTimestamp > TimeSpan.FromDays(1))
                        {
                            populationFactionData.uri = await CreateUriRequest(selection);
                            populationFactionData.uriTimestamp = DateTimeOffset.Now;
                        }
                        populationFactionData.apiData = JObject.Parse(await myNetwork.DownloadString(populationFactionData.uri));
                        break;
                    case "company":
                        if (populationCompanyData.uri == null || DateTimeOffset.UtcNow - populationCompanyData.uriTimestamp > TimeSpan.FromDays(1))
                        {
                            populationCompanyData.uri = await CreateUriRequest(selection);
                            populationCompanyData.uriTimestamp = DateTimeOffset.Now;
                        }
                        populationCompanyData.apiData = JObject.Parse(await myNetwork.DownloadString(populationCompanyData.uri));
                        break;
                    case "itemmarket":
                        if (populationItemMarketData.uri == null || DateTimeOffset.UtcNow - populationItemMarketData.uriTimestamp > TimeSpan.FromDays(1))
                        {
                            populationItemMarketData.uri = await CreateUriRequest(selection);
                            populationItemMarketData.uriTimestamp = DateTimeOffset.Now;
                        }
                        populationItemMarketData.apiData = JObject.Parse(await myNetwork.DownloadString(populationItemMarketData.uri));
                        break;
                }
            }
            catch { return; }
            lastUpdatedTime = DateTimeOffset.Now;
            return;
        }

        private async Task<string> GetSelections(string section)
        {
            string selectionsString = "";

            try
            {
                JToken selections = JObject.Parse(
                    await myNetwork.DownloadString(
                        new Uri(String.Format("{0}{1}/?selections=lookup&key={2}", BaseApiUri, section, ApiKey)
                            )
                        )
                    ).SelectToken("selections");

                foreach (string value in selections.ToList())
                {
                    if (value != selections.Last.ToString()) { selectionsString += String.Format("{0},", value); }
                    else { selectionsString += String.Format("{0}", value); }
                }
            }
            catch { selectionsString = String.Empty; }

            return selectionsString;
        }

        public async Task GetBestGyms()
        {
            List<JToken> totalGyms = populationTornData.apiData.SelectToken("gyms").Children().Children().ToList<JToken>();

            Gyms gyms = new Gyms(totalGyms);
            await gyms.getMinMaxGyms(11);

            //Free up memory
            totalGyms.Clear();

            return;
        }

        /// <summary>
        /// Returns List if List - Vendor Profit, Market Profit
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemDetails>> GetItemsList(bool vendorList)
        {

            List<JToken> totalItems = populationTornData.apiData.SelectToken("items").Children().Children().ToList<JToken>();
            Items items = new Items(totalItems);

            return await items.createItemsList(vendorList); 
        }

        public DateTimeOffset LastUpdated()
        {
            return lastUpdatedTime;
        }

        public User UpdateUserData()
        {
            return new User
            {
                name = playerUserData.apiData.Value<string>("name"),
                age = playerUserData.apiData.Value<string>("age"),
                money = playerUserData.apiData.Value<decimal>("money_onhand"),
                networth = playerUserData.apiData.Value<decimal>("networth"),
                level = playerUserData.apiData.Value<string>("level"),
                gender = playerUserData.apiData.Value<string>("gender"),
                points = playerUserData.apiData.Value<string>("points"),
                energy = playerUserData.apiData.SelectToken("energy").Value<decimal>("current"),
                energyMax = playerUserData.apiData.SelectToken("energy").Value<decimal>("maximum"),
                nerve = playerUserData.apiData.SelectToken("nerve").Value<decimal>("current"),
                nerveMax = playerUserData.apiData.SelectToken("nerve").Value<decimal>("maximum"),
                happy = playerUserData.apiData.SelectToken("happy").Value<decimal>("current"),
                happyMax = playerUserData.apiData.SelectToken("happy").Value<decimal>("maximum"),
                life = playerUserData.apiData.SelectToken("life").Value<decimal>("current"),
                lifeMax = playerUserData.apiData.SelectToken("life").Value<decimal>("maximum"),
                Strength = playerUserData.apiData.Value<decimal>("strength"),
                Defense = playerUserData.apiData.Value<decimal>("defense"),
                Speed = playerUserData.apiData.Value<decimal>("speed"),
                Dexterity = playerUserData.apiData.Value<decimal>("dexterity"),
                ManualLabor = playerUserData.apiData.Value<int>("manual_labor"),
                Intelligence = playerUserData.apiData.Value<int>("intelligence"),
                Endurance = playerUserData.apiData.Value<int>("endurance")
            };
        }

        public async Task<List<IMarketDetails>> ScanBazaarItemMarket()
        {
            List<IMarketDetails> sellToVendorProfit = new List<IMarketDetails>();
            JObject parseData = new JObject();

            foreach (ItemDetails items in await GetItemsList(true))
            {
                if (items.sell_price > items.market_valuation && items.sell_price > 0 && items.market_valuation > 0)
                {
                    double cost;

                    try
                    {
                        parseData = JObject.Parse(await myNetwork.DownloadString(new Uri(
                            String.Format("{0}market/{1}?selections=bazaar,itemmarket&key={2}", BaseApiUri, items.itemNumber, ApiKey)
                            )));

                        foreach (JToken jToken in parseData.SelectToken("bazaar"))
                        {
                            cost = jToken.Value<double>("cost");

                            if (items.sell_price > cost)
                            {
                                sellToVendorProfit.Add(new BazaarDetails(
                                 items.itemNumber, items.name, (items.sell_price - cost), jToken.Value<string>("ID"), cost.ToString(), jToken.Value<string>("quantity")
                                 ));
                            }
                        }

                        foreach (JToken jToken1 in parseData.SelectToken("itemmarket"))
                        {
                            cost = jToken1.Value<double>("cost");

                            if (items.sell_price > cost)
                            {
                                sellToVendorProfit.Add(new ItemMarketDetails(
                                 items.itemNumber, items.name, (items.sell_price - cost), jToken1.Value<string>("ID"), cost.ToString(), jToken1.Value<string>("quantity")
                                 ));
                            }
                        }
                    }
                    catch { }
                }

            }
            parseData.RemoveAll();
            return sellToVendorProfit;
        }

        public void ClearMemory()
        {
            myNetwork.Dispose();
        }

        private async Task<Uri> CreateUriRequest(string selection)
        {
            string switchData;

            if (selection != null)
            {
                switch (selection)
                {
                    case "torn":
                        switchData = String.Format("torn/?selections={0}", await GetSelections("torn"));
                        break;
                    case "user":
                        switchData = String.Format("user/?selections={0}", await GetSelections("user"));
                        break;
                    case "property":
                        switchData = String.Format("property/?selections={0}", await GetSelections("property"));
                        break;
                    case "faction":
                        switchData = String.Format("faction/?selections={0}", await GetSelections("faction"));
                        break;
                    case "company":
                        switchData = String.Format("company/?selections={0}", await GetSelections("company"));
                        break;
                    case "itemmarket":
                        switchData = String.Format("itemmarket/?selections={0}", await GetSelections("itemmarket"));
                        break;
                    default:
                        switchData = String.Empty;
                        break;
                }
                return new Uri(String.Format("{0}{1}&key={2}", BaseApiUri, switchData, ApiKey));
            }
            else { return new Uri(String.Empty); }
        }

        /// <summary>
        /// Returns list of attacks made to and from the user
        /// </summary>
        /// <returns></returns>
        public async Task<List<Attacks>> GetAttacksList()
        {
            List<Attacks> attacks = new List<Attacks>();

            try
            {
                foreach (JToken cycleAttacks in playerUserData.apiData.SelectToken("attacks").Children().Children())
                {

                    if (cycleAttacks.Value<decimal>("respect_gain") > 0 &&
                        (DateTimeOffset.UtcNow - DateTimeOffset.FromUnixTimeSeconds(cycleAttacks.Value<Int64>("timestamp_started")) < TimeSpan.FromDays(31)))
                    {
                        await Task.Run(() =>
                            attacks.Add(
                                new Attacks
                                {
                                    timestamp_started = DateTimeOffset.FromUnixTimeSeconds(cycleAttacks.Value<Int64>("timestamp_started")).LocalDateTime,
                                    timestamp_ended = DateTimeOffset.FromUnixTimeSeconds(cycleAttacks.Value<Int64>("timestamp_ended")).LocalDateTime,
                                    attacker_id = cycleAttacks.Value<string>("attacker_id"),
                                    attacker_faction = cycleAttacks.Value<string>("attacker_faction"),
                                    defender_id = cycleAttacks.Value<string>("defender_id"),
                                    defender_faction = cycleAttacks.Value<string>("defender_faction"),
                                    result = cycleAttacks.Value<string>("result"),
                                    stealthed = cycleAttacks.Value<bool>("stealthed"),
                                    respect_gain = cycleAttacks.Value<double>("respect_gain")
                                }));
                    }
                }
            }
            catch { return new List<Attacks>(); }
            return attacks;
        }

        public async Task<Company> GetCompanyInfo()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                List<Position> positions = new List<Position>();
                string company_type = populationCompanyData.apiData.SelectToken("company").Value<string>("company_type");

                foreach (JToken jtEmployees in populationCompanyData.apiData.SelectToken("company_employees").Children().Children())
                {
                    employees.Add(new Employee
                    {
                        name = jtEmployees.Value<string>("name"),
                        position = jtEmployees.Value<string>("position"),
                        days_in_company = jtEmployees.Value<string>("days_in_company"),
                        wage = jtEmployees.Value<int>("wage"),
                        effectiveness = jtEmployees.Value<int>("effectiveness"),
                        manual_labor = jtEmployees.Value<int>("manual_labor"),
                        intelligence = jtEmployees.Value<int>("intelligence"),
                        endurance = jtEmployees.Value<int>("endurance"),
                        last_action = jtEmployees.SelectToken("last_action").Value<string>("relative")
                    });
                }

                foreach (JToken jtPositions in populationTornData.apiData.SelectToken("companies").SelectToken(company_type).SelectToken("positions").Children().Children())
                {
                    JProperty name = (JProperty)jtPositions.Parent;

                    positions.Add(new Position
                    {
                        name = name.Name,
                        man_required = jtPositions.Value<int>("man_required"),
                        int_required = jtPositions.Value<int>("int_required"),
                        end_required = jtPositions.Value<int>("end_required"),
                        man_gain = jtPositions.Value<int>("man_gain"),
                        int_gain = jtPositions.Value<int>("int_gain"),
                        end_gain = jtPositions.Value<int>("end_gain"),
                        special_ability = jtPositions.Value<string>("special_ability"),
                        description = jtPositions.Value<string>("description")
                    }); ;
                }

                return new Company
                {
                    name = populationCompanyData.apiData.SelectToken("company").Value<string>("name"),
                    rating = populationCompanyData.apiData.SelectToken("company").Value<string>("rating"),
                    daily_profit = populationCompanyData.apiData.SelectToken("company").Value<int>("daily_profit"),
                    daily_customers = populationCompanyData.apiData.SelectToken("company").Value<int>("daily_customers"),
                    weekly_profit = populationCompanyData.apiData.SelectToken("company").Value<int>("weekly_profit"),
                    weekly_customers = populationCompanyData.apiData.SelectToken("company").Value<int>("weekly_customers"),
                    days_old = populationCompanyData.apiData.SelectToken("company").Value<int>("days_old"),
                    popularity = populationCompanyData.apiData.SelectToken("company_detailed").Value<int>("popularity"),
                    efficiency = populationCompanyData.apiData.SelectToken("company_detailed").Value<int>("efficiency"),
                    environment = populationCompanyData.apiData.SelectToken("company_detailed").Value<int>("environment"),
                    trains_available = populationCompanyData.apiData.SelectToken("company_detailed").Value<int>("trains_available"),
                    advertising_budget = populationCompanyData.apiData.SelectToken("company_detailed").Value<int>("advertising_budget"),
                    employees = employees,
                    positions = positions
                };

            }
            catch { return new Company(); }
        }

        public async Task<Faction> GetFactionInfo()
        {
            try
            {
                return new Faction
                {
                    name = populationFactionData.apiData.Value<string>("name"),
                    leader = populationFactionData.apiData.Value<string>("leader"),
                    co_leader = populationFactionData.apiData.Value<string>("co-leader"),
                    members = populationFactionData.apiData.SelectToken("members").Children().Count(),
                    respect = populationFactionData.apiData.Value<uint>("respect"),
                    money = populationFactionData.apiData.Value<uint>("money"),
                    points = populationFactionData.apiData.Value<uint>("points"),
                    best_chain = populationFactionData.apiData.Value<uint>("best_chain"),
                    territories = populationFactionData.apiData.SelectToken("territory").Children().Count()
                };
            }
            catch { return new Faction(); }
        }

        public async Task<List<ItemDetails>> CreatePlushieFlowerLists(List<ItemDetails> totalItems)
        {
            List<ItemDetails> plushieFlowers = new List<ItemDetails>();
            
            foreach (ItemDetails items in totalItems)
            {
                if(items.type == "Plushie" || items.type == "Flower") 
                { 
                    if (items.buy_price > 0) { plushieFlowers.Add(items); }
                }
            }
            return plushieFlowers;
        }

        public int CheckForBonusTravelCapacity()
        {
            int bonusTravelItems = 0;

            //check for faction travel perks
            foreach (JToken token in populationFactionData.apiData.SelectToken("upgrades").Children().Values())
            {
                if (token.Value<string>("name").Contains("Travel capacity") == true)
                {
                    JToken jToken = token;
                    bonusTravelItems += jToken.Value<int>("level");
                }
            }

            //check for player travel perks
            List<string> strings = playerUserData.apiData.SelectToken("enhancer_perks").Values<string>().ToList();
            if (strings.IndexOf("Travel items") < 0)
            {
                StringBuilder parser = new StringBuilder();

                parser.Append(strings.Find(x => x.Contains("Travel items")));
                parser.Remove(3, parser.Length - 3).Remove(0, 1);

                bonusTravelItems += Convert.ToInt16(parser.ToString());
            }
            return bonusTravelItems;
        }
    }
}
