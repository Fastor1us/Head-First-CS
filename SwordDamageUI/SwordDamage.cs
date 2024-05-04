using System;

namespace SwordDamageUI
{
    internal class SwordDamage
    {
        public int BaseDamage { get; private set; }
        public int FlameDamage { get; private set; }
        public int Roll { get; private set; }
        public float MagicMultiplier { get; private set; }
        private static Random random = new Random();

        public SwordDamage(int baseDamage, int flameDamage, float magicMultiplier)
        {
            BaseDamage = baseDamage;
            FlameDamage = flameDamage;
            MagicMultiplier = magicMultiplier;
        }
        
        public int CalculateDamage(bool isMagic = false, bool isFlaming = false)
        {
            for (byte i = 0; i < 3; i++) Roll += random.Next(1, 7);
            float magicMultiplier = isMagic ? MagicMultiplier : 1;
            int flameDamage = isFlaming ? FlameDamage : 1;
            return (int)(Roll * magicMultiplier) + flameDamage + BaseDamage;
        }
    }
}
