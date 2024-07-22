using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagerUI
{
    internal static class HoneyVault
    {
        private static float honey = 25F;
        private static float nectar = 100F;

        public static float Honey { get { return honey; } }

        const float NECTAR_CONVERSION_RATIO = .19F;
        const float LOW_LEVEL_WARNING = 10F;

        public static string StatusReport
        {
            get
            {
                string statusReport = String.Empty;
                statusReport += "Vault report:\n";
                statusReport += $"Units of honey: {honey:0.0}\n";
                statusReport += $"Units of nectar: {nectar:0.0}\n";
                if (honey < LOW_LEVEL_WARNING)
                    statusReport += "LOW HONEY — ADD A HONEY MANUFACTURER";
                statusReport += "\n";
                if (nectar < LOW_LEVEL_WARNING)
                    statusReport += "LOW NECTAR — ADD A NECTAR MANUFACTURER";
                statusReport += "\n";
                return statusReport;
            }
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0) nectar += amount;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount > nectar ? nectar : amount;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
            nectar -= nectarToConvert;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount) honey -= amount;
            return honey >= amount;
        }
    }
}

