using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamageUI
{
    internal class SwordDamage : WeaponDamage
    {
        public SwordDamage(): base(15, 3, 1.25F, 3) {
        }
    }
}
