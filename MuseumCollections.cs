using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Torn_Assistant.API;

namespace Torn_Assistant
{
    public partial class MuseumCollections : Form
    {
        public Museum museum { get; set; }
        private AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
        private List<string> setNames = new List<string>
        {
            "Plushies",
            "Exotic Flowers",
            "Medieval Coins",
            "Vairocana Buddha",
            "Ganesha Sculpture",
            "Shabti Sculpture",
            "Scripts from the Quran",
            "Senet Game",
            "Egyptian Amulet"
        };

        public MuseumCollections()
        {
            InitializeComponent();
            ComboBox.ObjectCollection objectCollection = new ComboBox.ObjectCollection(comboBox1);
            objectCollection.Add("Click to Select");
            objectCollection.AddRange(setNames.ToArray());
            myCollection.AddRange(setNames.ToArray());
            comboBox1.AutoCompleteCustomSource = myCollection; 
            comboBox1.DataSource = objectCollection;
            comboBox1.DisplayMember = "Click to Select";
        }

        private void MuseumCollections_Load(object sender, EventArgs e)
        {
            tableLayoutPanelLeft.AutoSize = true;
            tableLayoutPanelLeft.Controls.Add(
                CreateNewTableLayoutPanel(InitializeLeftSideProfits()));
            tableLayoutPanelRight.AutoSize = true;
            AutoSize = true;
        }

        private List<string> InitializeLeftSideProfits()
        {
            List<string> setsProfit = new List<string>();

            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(0), museum.CalculateSetProfit("plushies")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(1), museum.CalculateSetProfit("flowers")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(2), museum.CalculateSetProfit("medievalcoins")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(3), museum.CalculateSetProfit("vairocanabuddha")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(4), museum.CalculateSetProfit("ganeshasculpture")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(5), museum.CalculateSetProfit("shabtisculpture")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(6), museum.CalculateSetProfit("scriptsfromthequran")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(7), museum.CalculateSetProfit("senetgame")));
            setsProfit.Add(String.Format("{0}: {1:C0}", setNames.ElementAt(8), museum.CalculateSetProfit("egyptianamulet")));

            return setsProfit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="set">Valid Options: plushies, flowers, medievalcoins, vairocanabuddha,
        /// ganeshasculpture, shabtisculpture, scriptsfromthequran, senetgame, egyptianamulet</param>
        /// <returns></returns>
        private List<string> CreateRightSideDetails(string set)
        {
            List<string> detailsStrings = new List<string>();
            double capitalNeeded = 0;

            switch (set)
            {
                case "plushies":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "flowers":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "medievalcoins":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "vairocanabuddha":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "ganeshasculpture":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "shabtisculpture":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "scriptsfromthequran":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "senetgame":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                case "egyptianamulet":
                    foreach (ItemDetails items in museum.CreateSetItemList(set))
                    {
                        detailsStrings.Add(String.Format("{0} Market Value: {1:C0}", items.name, items.market_valuation));
                        capitalNeeded += items.market_valuation;
                    }
                    break;
                default:
                    break;  
            }
            if (detailsStrings != null) { detailsStrings.Add(String.Format("Capital Needed: {0:C0}", capitalNeeded)); }
            return detailsStrings;
        }

        public TableLayoutPanel CreateNewTableLayoutPanel(List<string> strings)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            Label label;
            Padding normalPadding = new Padding(0, 0, 0, 2);
            Padding lastPadding = new Padding(0, 0, 0, 15);
            int count = 0;

            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tableLayoutPanel.Margin = new Padding(3);

            foreach (string data in strings)
            {
                label = new Label
                {
                    Text = data,
                    Height = 15,
                    AutoSize = true

                };

                if (data == strings.Last().ToString()) { label.Padding = lastPadding; }
                else { label.Padding = normalPadding; }
                tableLayoutPanel.Controls.Add(label, 0, count);
                count++;
            }
            return tableLayoutPanel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRightHandSideOnEvent();
        }

        private void UpdateRightHandSideOnEvent()
        {
            tableLayoutPanelRight.Controls.Clear();

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Plushies":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("plushies")));
                    break;
                case "Exotic Flowers":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("flowers")));
                    break;
                case "Medieval Coins":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("medievalcoins")));
                    break;
                case "Vairocana Buddha":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("vairocanabuddha")));
                    break;
                case "Ganesha Sculpture":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("ganeshasculpture")));
                    break;
                case "Shabti Sculpture":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("shabtisculpture")));
                    break;
                case "Scripts from the Quran":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("scriptsfromthequran")));
                    break;
                case "Senet Game":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("senetgame")));
                    break;
                case "Egyptian Amulet":
                    tableLayoutPanelRight.Controls.Add(
                        CreateNewTableLayoutPanel(CreateRightSideDetails("egyptianamulet")));
                    break;
                default:
                    break;
            }
        }


        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.AcceptButton = null;
            if (e.KeyChar == (char)Keys.Enter)
            {
                UpdateRightHandSideOnEvent();
            }
            else { }
        }
        private void MuseumCollections_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
