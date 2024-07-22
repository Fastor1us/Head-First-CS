using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagerUI
{
    internal class EggCare : Bee
    {
        public override float CostPerShift { get; } = 1.35F;
        const float CARE_PROGRESS_PER_SHIFT = 0.15F;
        private Queen queen;

        public EggCare(Queen queen) : base("EggCare") {
            this.queen = queen;
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
