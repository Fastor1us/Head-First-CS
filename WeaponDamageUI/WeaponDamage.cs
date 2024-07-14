using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamageUI
{
    internal class WeaponDamage
    {
        public int BaseDamage { get; private set; }
        public int FlameDamage { get; private set; }
        public int Dices { get; private set; }
        public int Roll { get; private set; }
        public float MagicMultiplier { get; private set; }
        private static readonly Random random = new Random();

        public WeaponDamage(int baseDamage, int flameDamage, float magicMultiplier, int dices)
        {
            BaseDamage = baseDamage;
            FlameDamage = flameDamage;
            MagicMultiplier = magicMultiplier;
            Dices = dices;
        }

        public int CalculateDamage(bool isMagic, bool isFlaming)
        {
            for (byte i = 0; i < Dices; i++) Roll += random.Next(1, 7);
            float magicMultiplier = isMagic ? MagicMultiplier : 1;
            int flameDamage = isFlaming ? FlameDamage : 1;
            return (int)(Roll * magicMultiplier) + flameDamage + BaseDamage;
        }
    }
}
