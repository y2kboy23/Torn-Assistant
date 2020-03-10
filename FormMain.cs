using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Torn_Assistant.API;

namespace Torn_Assistant
{
    public partial class FormMain : Form
    {
        private protected API.API myAPI;
        private protected List<Label> myCompany = new List<Label>();
        private protected List<Label> myFaction = new List<Label>();

        public FormMain()
        {
            InitializeComponent();
            myAPI = new API.API("https://api.torn.com/", File.ReadAllText("apikey.txt"));
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                await myAPI.UpdateFromAPI("user");
                await myAPI.UpdateFromAPI("torn");
                await myAPI.UpdateFromAPI("property");
                await myAPI.UpdateFromAPI("itemmarket");
                await myAPI.UpdateFromAPI("company");
                await myAPI.UpdateFromAPI("faction");
            }
            catch { }

            InitializeOptionalUI(await CreateOptionalUI(await myAPI.GetCompanyInfo()), await CreateOptionalUI(await myAPI.GetFactionInfo()));
            await UpdateUser(myAPI.UpdateUserData());
            UpdateTime();
            ItemEvents();

            timer1.Enabled = true;
            timer1.Start();
            numericUpDownRefresh.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            comboBoxItemSelect.Enabled = true;
            buttonGo.Enabled = true;
            buttonCompany.Enabled = true;
            buttonTravel.Enabled = true;
            buttonMuseum.Enabled = true;
        }

        //Gets last API update time and displays to form
        private void UpdateTime()
        {
            toolStripStatusLabel1.Text = String.Format("Last Updated: {0}", myAPI.LastUpdated().LocalDateTime.ToString());
        }

        //Updates GUI with data from API class
        private async Task UpdateUser(User user)
        {
            decimal totalStats = user.Defense + user.Dexterity + user.Speed + user.Strength;
            groupBoxName.Text = String.Format("{0} ({1})", user.name, user.gender);
            labelAge.Text = String.Format("Age: {0} days", user.age);
            labelLevel.Text = String.Format("Level: {0}", user.level);
            labelMoney.Text = String.Format("Money: {0:C0}", user.money);
            labelNetworth.Text = String.Format("Networth: {0:C0}", user.networth);
            labelPoints.Text = String.Format("Points: {0}", user.points);

            labelEnergy.Text = String.Format("Energy: {0} / {1}", user.energy, user.energyMax);
            labelNerve.Text = String.Format("Nerve: {0} / {1}", user.nerve, user.nerveMax);
            labelHappy.Text = String.Format("Happy: {0} / {1}", user.happy, user.happyMax);
            labelLife.Text = String.Format("Life: {0} / {1}", user.life, user.lifeMax);

            labelStr.Text = String.Format("Strength: {0:N2} ({1:P2})", user.Strength, user.Strength / totalStats);
            labelDef.Text = String.Format("Defense: {0:N2} ({1:P2})", user.Defense, user.Defense / totalStats);
            labelSpd.Text = String.Format("Speed: {0:N2} ({1:P2})", user.Speed, user.Speed / totalStats);
            labelDex.Text = String.Format("Dexterity: {0:N2} ({1:P2})", user.Dexterity, user.Dexterity / totalStats);

            labelLabor.Text = String.Format("Manual Labor: {0:N0}", user.ManualLabor);
            labelInt.Text = String.Format("Intelligence: {0:N0}", user.Intelligence);
            labelEnd.Text = String.Format("Endurance: {0:N0}", user.Endurance);

            return;
        }

        private async void TimerEvents()
        {
            try
            {
                await UpdateUser(myAPI.UpdateUserData());
                UpdateTime();
                ItemEvents();
                await UpdateOptionalUI(myCompany, await CreateOptionalUI(await myAPI.GetCompanyInfo()));
                await UpdateOptionalUI(myFaction, await CreateOptionalUI(await myAPI.GetFactionInfo()));
            }
            catch { }
        }

        private async void ItemEvents()
        {
            List<ItemDetails> totalItems = new List<ItemDetails>();

            if (radioButton1.Checked)
            {
                totalItems = await myAPI.GetItemsList(true);
                await UpdateItemView(totalItems);
            }
            else if (radioButton3.Checked) //scanning items
            {
                if (UpdateItemView().IsCompleted == true)
                {
                    totalItems = await myAPI.GetItemsList(true);
                }
                else { totalItems = await myAPI.GetItemsList(true); }
            }
            else if (radioButton4.Checked) //attacks
            {
                List<Attacks> sortedList = new List<Attacks>();
                sortedList = await myAPI.GetAttacksList();

                if (sortedList != null)
                {
                    BindingList<Attacks> sortedBAttacks = new BindingList<Attacks>(sortedList.OrderByDescending(o => o.respect_gain).ToList());
                    sortedList.Clear();

                    await UpdateAttacksView(sortedBAttacks);
                }

            }
            else
            {
                totalItems = await myAPI.GetItemsList(false);
                await UpdateItemView(totalItems);
            }

            //update dropdown box of items
            BindingList<ItemDetails> itemInfo = new BindingList<ItemDetails>(totalItems.OrderBy(o => o.name).ToList());
            comboBoxItemSelect.DataSource = itemInfo;
            comboBoxItemSelect.DisplayMember = "name";

            //Free up memory
            totalItems.Clear();
        }

        private async void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            await myAPI.UpdateFromAPI("user");
            await myAPI.UpdateFromAPI("torn");
            await myAPI.UpdateFromAPI("itemmarket");
            await myAPI.UpdateFromAPI("company");
            await myAPI.UpdateFromAPI("faction");
            await myAPI.UpdateFromAPI("property");
            TimerEvents();
            timer1.Start();
        }

        private void NumericUpDownRefresh_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownRefresh.Value == 0) { timer1.Enabled = false; myAPI.ClearMemory(); }
            else
            {
                if (timer1.Enabled == false) { timer1.Enabled = true; }
                timer1.Interval = Convert.ToInt32(numericUpDownRefresh.Value * 1000);
                timer1.Start();
            }
        }

        private async Task UpdateAttacksView(BindingList<Attacks> attacks)
        {
            dataGridViewItems.DataSource = attacks;
            dataGridViewItems.Columns["timestamp_ended"].Visible = false;
            dataGridViewItems.Columns["respect_gain"].DisplayIndex = 2;
            dataGridViewItems.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            return;
        }

        private async Task UpdateItemView()
        {
            if (radioButton3.Checked)
            {
                BindingList<IMarketDetails> viewIList;
                List<IMarketDetails> scanList = new List<IMarketDetails>();

                try
                {
                    foreach (IMarketDetails imDets in await myAPI.ScanBazaarItemMarket())
                    {
                        scanList.Add(imDets);
                    }

                    viewIList = new BindingList<IMarketDetails>(scanList.OrderByDescending(o => o.vendorProfit).ToList());
                    dataGridViewItems.DataSource = viewIList;
                    scanList.Clear();
                }
                catch { }
            }

            dataGridViewItems.Columns["vendorProfit"].Visible = true;
            dataGridViewItems.Columns["vendorProfit"].DefaultCellStyle.Format = "N0";
            dataGridViewItems.Columns["cost"].DefaultCellStyle.Format = "N0";
            dataGridViewItems.Columns["quantity"].DefaultCellStyle.Format = "N0";

            return;
        }

        private async Task UpdateItemView(List<ItemDetails> itemList)
        {
            BindingList<ItemDetails> viewList = new BindingList<ItemDetails>();

            if (radioButton1.Checked)
            {
                //Vendor Price - money made selling to vendor
                foreach (ItemDetails selection in itemList)
                {
                    if (selection.market_valuation > 0 && selection.sell_price > 0 && selection.vendorProfit > 0)
                    {
                        viewList.Add(selection);
                    }
                }

                dataGridViewItems.DataSource = viewList;
                dataGridViewItems.Columns["itemNumber"].Visible = false;
                dataGridViewItems.Columns["effect"].Visible = false;
                dataGridViewItems.Columns["requirement"].Visible = false;
                dataGridViewItems.Columns["image"].Visible = false;
                dataGridViewItems.Columns["marketProfit"].Visible = false;
                dataGridViewItems.Columns["marketProfit"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["vendorProfit"].DisplayIndex = 2;
                dataGridViewItems.Columns["vendorProfit"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["vendorProfit"].Visible = true;
                dataGridViewItems.Columns["buy_price"].DisplayIndex = 3;
                dataGridViewItems.Columns["buy_price"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["sell_price"].DisplayIndex = 4;
                dataGridViewItems.Columns["sell_price"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["market_valuation"].DisplayIndex = 5;
                dataGridViewItems.Columns["market_valuation"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["circulation"].DefaultCellStyle.Format = "N0";
            }
            else if (radioButton2.Checked)
            {
                //Market Price - money made selling to market
                foreach (ItemDetails selection in itemList)
                {
                    if (selection.market_valuation > 0 && selection.buy_price > 0 && selection.marketProfit > 0)
                    {
                        viewList.Add(selection);
                    }
                }

                dataGridViewItems.DataSource = viewList;
                dataGridViewItems.Columns["itemNumber"].Visible = false;
                dataGridViewItems.Columns["effect"].Visible = false;
                dataGridViewItems.Columns["requirement"].Visible = false;
                dataGridViewItems.Columns["image"].Visible = false;
                dataGridViewItems.Columns["vendorProfit"].Visible = false;
                dataGridViewItems.Columns["vendorProfit"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["marketProfit"].DisplayIndex = 2;
                dataGridViewItems.Columns["marketProfit"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["marketProfit"].Visible = true;
                dataGridViewItems.Columns["buy_price"].DisplayIndex = 3;
                dataGridViewItems.Columns["buy_price"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["sell_price"].DisplayIndex = 4;
                dataGridViewItems.Columns["sell_price"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["market_valuation"].DisplayIndex = 5;
                dataGridViewItems.Columns["market_valuation"].DefaultCellStyle.Format = "N0";
                dataGridViewItems.Columns["circulation"].DefaultCellStyle.Format = "N0";
            }

            return;
        }

        private async void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { ItemEvents(); }
        }

        private async void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { ItemEvents(); }
        }

        private async void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) { ItemEvents(); }
        }

        private async void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true) { ItemEvents(); }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            ItemDetailsForm detailsForm = new ItemDetailsForm();
            detailsForm.UpdateItem(comboBoxItemSelect.SelectedItem);
            detailsForm.Show();
        }

        private async void InitializeOptionalUI(List<string> companyUI, List<string> factionUI)
        {
            Padding labelPadding = new Padding(0, 0, 0, 2);
            Padding lastPadding = new Padding(0, 0, 0, 25);
            Padding noMargin = new Padding(0);
            AnchorStyles leftAnchor = AnchorStyles.Left;
            RowStyle rowStyle = new RowStyle { Height = 20 };

            tableLayoutPanelCompanyFactionProperties.Enabled = true;
            tableLayoutPanelCompanyFactionProperties.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tableLayoutPanelCompanyFactionProperties.RowStyles.Clear();
            tableLayoutPanelCompanyFactionProperties.RowStyles.Add(rowStyle);
            tableLayoutPanelCompanyFactionProperties.AutoSize = true;

            //company UI
            if (true)
            {
                for (int i = 0; i < companyUI.Count; i++)
                {
                    Label companyLabel = new Label
                    {
                        Text = string.Format("{0}", companyUI[i]),
                        Margin = noMargin,
                        Anchor = leftAnchor,
                        Height = 15,
                        AutoSize = true
                    };
                    if (i + 1 == companyUI.Count) { companyLabel.Padding = lastPadding; }
                    else { companyLabel.Padding = labelPadding; }

                    tableLayoutPanelCompanyFactionProperties.Controls.Add(companyLabel, 0, i);
                    myCompany.Add(companyLabel);
                }
            }

            //faction UI
            if (true)
            {
                for (int i = 0; i < factionUI.Count; i++)
                {
                    Label factionLabel = new Label
                    {
                        Text = string.Format("{0}", factionUI[i]),
                        Margin = noMargin,
                        Anchor = leftAnchor,
                        Height = 15,
                        AutoSize = true
                    };
                    if (i + 1 == factionUI.Count) { factionLabel.Padding = lastPadding; }
                    else { factionLabel.Padding = labelPadding; }

                    tableLayoutPanelCompanyFactionProperties.Controls.Add(factionLabel, 0, companyUI.Count + i);
                    myFaction.Add(factionLabel);
                }
            }

            //property UI
            //if (true) { }
        }

        private async Task<List<string>> CreateOptionalUI(Company company)
        {
            List<string> ui = new List<string>();

            if (company != null)
            {
                ui.Add(String.Format("Name: {0} ({1}*)", company.name, company.rating));
                ui.Add(String.Format("Age: {0} days Popularity: {1}%", company.days_old, company.popularity));
                ui.Add(String.Format("Efficiency: {0}% Environment: {1}%", company.efficiency, company.environment));
                ui.Add(String.Format("Profit: {0:C0} ({1:C0})", company.daily_profit, company.weekly_profit));
                ui.Add(String.Format("Customers: {0:N0} ({1:N0})", company.daily_customers, company.weekly_customers));
                ui.Add(String.Format("Advertising: {0:C0}", company.advertising_budget));
            }
            return ui;
        }

        private async Task<List<string>> CreateOptionalUI(Faction faction)
        {
            List<string> ui = new List<string>();

            if (faction != null)
            {
                ui.Add(String.Format("Name: {0}", faction.name));
                ui.Add(String.Format("Members: {0} Respect: {1:N0}", faction.members, faction.respect));
                ui.Add(String.Format("Money: {0:C0} (Points: {1:N0})", faction.money, faction.points));
                ui.Add(String.Format("Best Chain: {0} (Territories: {1})", faction.best_chain, faction.territories));
            }
            return ui;
        }

        private async Task UpdateOptionalUI(List<Label> labels, List<string> strings)
        {
            for (int i = 0; i < labels.Count || i < strings.Count; i++)
            {
                if (labels[i].Text != strings[i]) { labels[i].Text = strings[i]; }
            }
            return;
        }

        private void buttonCompany_MouseClick(object sender, EventArgs e)
        {
            CompanyAccountant company = new CompanyAccountant();
            if (company != null)
            {
                company.InitializeUI(myAPI.GetCompanyInfo().Result);
                company.Show();
            }
        }

        private void buttonTravel_Click(object sender, EventArgs e)
        {
            TravelAgent window = new TravelAgent();
            Travel travel = new Travel();
            window.InitializeUI(
                travel.CalculateProfitPerMinute(
                    myAPI.CreatePlushieFlowerLists(myAPI.GetItemsList(false).Result).Result, myAPI.CheckForBonusTravelCapacity()
                    )
                );
            window.Show();
        }

        private void buttonMuseum_Click(object sender, EventArgs e)
        {
            MuseumCollections museumCollection = new MuseumCollections
            {
                museum = new Museum
                {
                    totalItems = new Items
                    {
                        totalItemsList = myAPI.GetItemsList().Result,
                    },
                    pointsValue = new Points
                    {
                        pointsPrice = myAPI.GetPawnshopPointsValue()
                    }
                }
            };
            museumCollection.Show();
        }
    }
}