namespace Torn_Assistant.API
{
    public class User
    {
        public string name { get; set; }
        public string age { get; set; }
        public decimal money { get; set; }
        public decimal networth { get; set; }
        public string level { get; set; }
        public string gender { get; set; }
        public string points { get; set; }

        public decimal energy { get; set; }
        public decimal energyMax { get; set; }
        public decimal nerve { get; set; }
        public decimal nerveMax { get; set; }
        public decimal happy { get; set; }
        public decimal happyMax { get; set; }
        public decimal life { get; set; }
        public decimal lifeMax { get; set; }

        public decimal Strength { get; set; }
        public decimal Defense { get; set; }
        public decimal Speed { get; set; }
        public decimal Dexterity { get; set; }

        public int ManualLabor { get; set; }
        public int Intelligence { get; set; }
        public int Endurance { get; set; }

    }
}
