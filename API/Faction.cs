namespace Torn_Assistant.API
{
    public class Faction
    {
        public string name { get; set; }
        public string leader { get; set; }
        public string co_leader { get; set; }
        public int members { get; set; }
        public uint max_members { get; set; }
        public uint respect { get; set; }
        public uint money { get; set; }
        public uint points { get; set; }
        public uint best_chain { get; set; }
        public int territories { get; set; }
    }
}
