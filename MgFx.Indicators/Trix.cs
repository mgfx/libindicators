// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trix.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Triple-smoothed Exponential Moving Average Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Triple-smoothed Exponential Moving Average Indicator.
    /// </summary>
    public class TRIX : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TRIX"/> class. 
        /// </summary>
        public TRIX()
        {
            this.Name = "TRIX - Triple-smoothed Exponential Moving Average";
            this.ShortName = "TRIX";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="period">Indicator period.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price, int period)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(1)
                .IsLessOrEqual(price.Length);

            var trix = new double[price.Length];
            var ema1 = EMA.Calculate(price, period);
            var ema2 = EMA.Calculate(ema1, period);
            var ema3 = EMA.Calculate(ema2, period);
            trix[0] = 0.0;
            for (int i = 1; i < price.Length; ++i)
            {
                if (ema3[i].IsAlmostZero())
                {
                    trix[i] = 0.0;
                }
                else
                {
                    trix[i] = 100.0 * ((ema3[i] - ema3[i - 1]) / ema3[i]);
                }
            }

            return trix;
        }       
    }
}
