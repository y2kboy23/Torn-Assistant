using System;

namespace Torn_Assistant.API
{
    public class Attacks
    {
        public DateTime timestamp_started { get; set; }
        public DateTime timestamp_ended { get; set; }
        public string attacker_id { get; set; }
        public string attacker_faction { get; set; }
        public string defender_id { get; set; }
        public string defender_faction { get; set; }
        public string result { get; set; }
        public bool stealthed { get; set; }
        public double respect_gain { get; set; }

        //default constructor
        /*public Attacks(string _timestampStarted, string _timestampEnded, string _attackerId, string _attackerFaction, string _defenderID, string _defenderFaction,
            string _result, string _stealthed, string _respectGained)
        {
            timestamp_started = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(_timestampStarted)).LocalDateTime;
            timestamp_ended = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(_timestampEnded)).LocalDateTime;
            attacker_id = _attackerId;
            attacker_faction = _attackerFaction;
            defender_id = _defenderID;
            defender_faction = defender_faction;
            result = _result;

            if (_stealthed == "1") { stealthed = true; }
            else { stealthed = false; }

            respect_gain = Convert.ToDouble(_respectGained);

        }*/
    }
}
