using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagerUI
{
    internal class HoneyManufacturer : Bee
    {
        public override float CostPerShift { get; } = 1.7F;
        const float NECTAR_PROCESSED_PER_SHIFT = 33.15F;

        public HoneyManufacturer() : base("HoneyManufacturer") { }

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
