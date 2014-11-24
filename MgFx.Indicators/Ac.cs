using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    public class Ac : Indicator
    {
        /// <summary>
        /// Ac default ctor
        /// </summary>
        public Ac()
        {
            Name = "Bill Williams' Accelerator/Decelerator oscillator";
            ShortName = "AC";
        }

        /// <summary>
        /// Calcultes Ac
        /// </summary>
        /// <param name="price"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static double[] Calculate(double[] price, int period)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);

            var ao = Ao.Calculate(price);
            var aoSma = Sma.Calculate(ao, 5);
            var ac = new double[price.Length];
            for (var i = 0; i < price.Length; ++i)
                ac[i] = ao[i] - aoSma[i];
            return ac;
        }
    }
}
