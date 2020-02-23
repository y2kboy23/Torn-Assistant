using System.Collections.Generic;

namespace Torn_Assistant.API
{
    public class Company
    {
        public string name { get; set; }
        public string rating { get; set; }
        public int daily_profit { get; set; }
        public int daily_customers { get; set; }
        public int weekly_profit { get; set; }
        public int weekly_customers { get; set; }
        public int days_old { get; set; }
        public int popularity { get; set; }
        public int efficiency { get; set; }
        public int environment { get; set; }
        public int trains_available { get; set; }
        public int advertising_budget { get; set; }
        public List<Employee> employees { get; set; }
        public List<Position> positions { get; set; }

    }

    public class Employee
    {
        public string name { get; set; }
        public string position { get; set; }
        public string days_in_company { get; set; }
        public int wage { get; set; }
        public int effectiveness { get; set; }
        public int manual_labor { get; set; }
        public int intelligence { get; set; }
        public int endurance { get; set; }
        public string last_action { get; set; }

    }

    public class Position
    {
        public string name { get; set; }
        public int man_required { get; set; }
        public int end_required { get; set; }
        public int int_required { get; set; }
        public int man_gain { get; set; }
        public int int_gain { get; set; }
        public int end_gain { get; set; }
        public string special_ability { get; set; }
        public string description { get; set; }

    }
}
