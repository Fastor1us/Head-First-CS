using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreTester
{
    internal class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double DivideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;
        public void CalculateAbilityScore()
        {
            // Результат броска делится на значение поля DivideBy
            double divided = RollResult / DivideBy;
            // AddAmount прибавляется к результату деления
            int added = AddAmount + (int)divided;

            // Если результат слишком мал, использовать значение Minimum
            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }

    }
}
