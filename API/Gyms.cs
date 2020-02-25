using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Torn_Assistant.API
{
    class Gyms
    {
        List<JToken> totalGyms;
        List<GymDetails> totalGymDetails = new List<GymDetails>();

        public Gyms(List<JToken> gyms) => (this.totalGyms) = (gyms);

        /// <summary>
        /// Returns a List of the best gym for training each attirbute. 
        /// </summary>
        /// <param name="maxGym">Prunes the list of Gyms the user is not able to use</param>
        /// <returns>A List of the best gyms in the order: Dex, Str, Def, Spd</returns>
        public async Task<List<GymDetails>> getMinMaxGyms(int maxGym)
        {
            totalGyms.RemoveRange(maxGym, totalGyms.Count - maxGym);
            int count = 0;

            foreach (JToken data in totalGyms)
            {
                string gymName;
                double gymEnergy;
                double gymDexterity;
                double gymStrength;
                double gymSpeed;
                double gymDefense;
                double dexPerEnergy;
                double strPerEnergy;
                double spdPerEnergy;
                double defPerEnergy;
                string countString = count.ToString();

                gymName = data.Value<string>("name");
                gymEnergy = data.Value<double>("energy");
                gymDexterity = data.Value<double>("dexterity");
                gymStrength = data.Value<double>("strength");
                gymSpeed = data.Value<double>("speed");
                gymDefense = data.Value<double>("defense");
                dexPerEnergy = gymDexterity / gymEnergy;
                strPerEnergy = gymStrength / gymEnergy;
                spdPerEnergy = gymSpeed / gymEnergy;
                defPerEnergy = gymDefense / gymEnergy;

                GymDetails gymDetails = new GymDetails(count, gymName, dexPerEnergy, strPerEnergy, spdPerEnergy, defPerEnergy);
                totalGymDetails.Add(gymDetails);

                count++;
            }

            List<GymDetails> bestGyms = new List<GymDetails>();

            bestGyms.Add(totalGymDetails.OrderByDescending(o => o.dexEnergy).ToList().First());
            bestGyms.Add(totalGymDetails.OrderByDescending(o => o.strEnergy).ToList().First());
            bestGyms.Add(totalGymDetails.OrderByDescending(o => o.defEnergy).ToList().First());
            bestGyms.Add(totalGymDetails.OrderByDescending(o => o.spdEnergy).ToList().First());

            return bestGyms;
        }

    }

    class GymDetails
    {
        public int id { get; }
        public string name { get; }
        public double dexEnergy { get; }
        public double strEnergy { get; }
        public double spdEnergy { get; }
        public double defEnergy { get; }

        public GymDetails(int num, string inName, double dex, double str, double spd, double def)
        {
            id = num;
            name = inName;
            dexEnergy = dex;
            strEnergy = str;
            spdEnergy = spd;
            defEnergy = def;
        }

    }
}
