using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Torn_Assistant.API;

namespace Torn_Assistant
{
    public partial class CompanyAccountant : Form
    {
        public CompanyAccountant()
        {
            InitializeComponent();
        }

        public void InitializeUI(Company company)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowStyles.Add(new RowStyle { Height = 20 });
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle { Width = 150 });
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.AutoSize = true;


            int avg = company.weekly_profit / 7;
            decimal wages = new decimal();
            foreach (Employee employee in company.employees) { wages += employee.wage; }
            decimal netIncomePercent = Convert.ToDecimal((avg - wages - company.advertising_budget)) / Convert.ToDecimal(avg);
            int count = 0;

            List<string> dailyIncome = new List<string>
            {
                String.Format("Avg. Daily Revenue: {0:C0}", avg),
                String.Format("Wages: -{0:C0}", wages),
                String.Format("Advertising: -{0:C0}", company.advertising_budget),
                String.Format("Net Income: {0:C0} ({1:P0})", avg - wages - company.advertising_budget, netIncomePercent)
            };

            List<string> weeklyIncome = new List<string>
            {
                String.Format("Weekly Revenue: {0:C0}", company.weekly_profit),
                String.Format("Wages:  -{0:C0}", wages * 7),
                String.Format("Advertising: -{0:C0}", company.advertising_budget * 7),
                String.Format("Net Income: {0:C0} ({1:P0})", company.weekly_profit - (wages * 7) - (company.advertising_budget * 7), netIncomePercent)
            };

            List<List<string>> listOfLists = new List<List<string>>
            {
                dailyIncome,
                weeklyIncome
            };

            tableLayoutPanel1.Controls.Add(CreateTableLayoutPanel(listOfLists).Result, 0, count);

            //reset counter
            count = 0;
            int managers = FindManagers(company.employees, company.positions).Result;
            listOfLists.Clear();

            foreach (Employee employee1 in company.employees)
            {
                List<string> employeeData = new List<string>
                {
                    String.Format("Name: {0} ({1})", employee1.name, employee1.position),
                    String.Format("Efficiency: {0:P0}", CalculateEfficiency(employee1, company.positions, managers).Result),
                    String.Format("Wage: {0:C0} ({1:p0})", employee1.wage, Convert.ToDecimal(employee1.wage) / Convert.ToDecimal(wages)),
                    String.Format("Days Worked: {0}", employee1.days_in_company),
                    String.Format("Last Action: {0}", employee1.last_action)
                };

                listOfLists.Add(employeeData);
            }

            tableLayoutPanel1.Controls.Add(CreateTableLayoutPanel(listOfLists).Result, 1, count);

            dailyIncome.Clear();
            weeklyIncome.Clear();
            listOfLists.Clear();
        }

        private async Task<TableLayoutPanel> CreateTableLayoutPanel(List<List<string>> data)
        {
            TableLayoutPanel table = new TableLayoutPanel();
            Label label;
            Padding normalPadding = new Padding(0, 0, 0, 2);
            Padding lastPadding = new Padding(0, 0, 0, 15);
            int count = 0;

            table.ColumnCount = 1;
            table.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            table.AutoSize = true;

            foreach (List<string> list in data)
            {
                foreach (string text in list)
                {
                    table.Controls.Add(label = new Label
                    {
                        Text = text,
                        Height = 15,
                        AutoSize = true

                    }, 0, count);
                    if (text == list.Last()) { label.Margin = lastPadding; }
                    else { label.Margin = normalPadding; }
                    if (text.Contains("Wages:") || text.Contains("Advertising:")) { label.ForeColor = Color.Red; }
                    count++;
                }
            }
            return table;
        }

        private async Task<decimal> CalculateEfficiency(Employee employee, List<Position> positions, int numManagers)
        {
            Position companyJob = positions.Find(x => x.name == employee.position);
            decimal empPrimary = 0;
            decimal empSeconday = 0;

            List<decimal> requiredStats = new List<decimal>
            {
                Convert.ToDecimal(companyJob.end_required),
                Convert.ToDecimal(companyJob.int_required),
                Convert.ToDecimal(companyJob.man_required)
            };

            List<decimal> sorted = requiredStats.OrderByDescending(x => x).ToList();
            requiredStats.Clear();
            sorted.Remove(0);

            foreach (decimal stat in sorted)
            {
                if (stat == sorted.First())
                {
                    if (stat == companyJob.end_required) { empPrimary = employee.endurance; }
                    else if (stat == companyJob.int_required) { empPrimary = employee.intelligence; }
                    else if (stat == companyJob.man_required) { empPrimary = employee.manual_labor; }
                }
                else if (stat == sorted.Last())
                {
                    if (stat == companyJob.end_required) { empSeconday = employee.endurance; }
                    else if (stat == companyJob.int_required) { empSeconday = employee.intelligence; }
                    else if (stat == companyJob.man_required) { empSeconday = employee.manual_labor; }
                }
            }

            decimal percent = ((empPrimary / sorted.First()) * .666m) + ((empSeconday / sorted.Last()) * .333m);

            if (percent > 1m)
            {
                //percent =
                decimal pecent = 
                    (((((empPrimary % sorted.First()) * .5m) + sorted.First()) / sorted.First()) * .666m)
                    +
                    (((((empSeconday % sorted.Last()) * .5m) + sorted.Last()) / sorted.Last()) * .333m);
            }
            else { }

            //manager improvements
            while (numManagers > 0 && percent < 1m)
            {
                percent += (1 - percent) * .25m;
                numManagers--;
            }

            //max effeciency 150%
            if (percent > 1.5m) { percent = 1.5m; }

            return percent;
        }

        private async Task<int> FindManagers(List<Employee> employees, List<Position> positions)
        {
            int numManagers = 0;
            Position manager = positions.Find(x => x.special_ability == "Manager");

            foreach (Employee employee in employees)
            {
                if (employee.position == manager.name) { numManagers += 1; }
            }
            return numManagers;
        }

        private void CompanyAccountant_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
