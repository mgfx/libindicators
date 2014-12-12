// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ema.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Exponential Moving Average Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Exponential Moving Average Indicator.
    /// </summary>
    public class EMA : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMA"/> class. 
        /// </summary>
        public EMA()
        {
            this.Name = "Exponential Moving Average";
            this.ShortName = "EMA";
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
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);

            var ema = new double[price.Length];
            double sum = price[0];
            double coeff = 2.0 / (1.0 + period);

            for (int i = 0; i < price.Length; i++)
            {
                sum += coeff * (price[i] - sum);
                ema[i] = sum;
            }

            return ema;
        }
    }
}
