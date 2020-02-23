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
    public partial class TravelAgent : Form
    {
        public TravelAgent()
        {
            InitializeComponent();
        }

        public void InitializeUI(List<itemProfit> data)
        {
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.Controls.Add(new Label { Text = "Item", Height = 15, Font = new Font(DefaultFont, FontStyle.Underline) }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Country", Height = 15, Font = new Font(DefaultFont, FontStyle.Underline) }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Profit / Min", Height = 15, Font = new Font(DefaultFont, FontStyle.Underline) }, 2, 0);

            int count = 1;

            foreach (itemProfit item in data)
            {
                if (item.profitMin > 0)
                {
                    tableLayoutPanel1.Controls.Add(new Label { Text = item.name, Height = 15 }, 0, count);
                    tableLayoutPanel1.Controls.Add(new Label { Text = item.county, Height = 15 }, 1, count);
                    tableLayoutPanel1.Controls.Add(new Label { Text = String.Format("{0:C1}", item.profitMin), Height = 15 }, 2, count);
                    count++;
                }
            }
        }

        private void TravelAgent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
