using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Torn_Assistant.API;

namespace Torn_Assistant
{
    public partial class ItemDetailsForm : Form
    {
        public ItemDetailsForm()
        {
            InitializeComponent();
        }

        public async Task UpdateItem(object items)
        {
            await UpdateUI(
                (ItemDetails)Convert.ChangeType(items, typeof(ItemDetails))
                );

            return;
        }

        private async Task UpdateUI(ItemDetails itDetails)
        {
            Text = itDetails.name;
            tableLayoutPanelLeft.Controls.Add(new Label
            {
                Text = itDetails.name,
                Font = new Font(new FontFamily("Microsoft Sans Serif"), 14.25F, FontStyle.Bold | FontStyle.Underline),
                AutoSize = true
            });
            tableLayoutPanelLeft.Controls.Add(new PictureBox
            {
                ImageLocation = itDetails.image
            });
            Label item;

            List<string> items = new List<string>
            {
                String.Format("Description: {0}", itDetails.description),
                String.Format("Buy Price: {0:C0}", itDetails.buy_price),
                String.Format("Sell Price: {0:C0}", itDetails.sell_price),
                String.Format("Market Value: {0:C0}", itDetails.market_valuation),
                String.Format("Circulation: {0:N0}", itDetails.circulation)

            };

            foreach (string data in items)
            {
                tableLayoutPanel1.Controls.Add(item = new Label
                {
                    Text = data,
                    Margin = new Padding(3),
                    Padding = new Padding(0,0,0,3),
                    AutoSize = true
                });
            };

            return;
        }

        private void ItemDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
