// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LWMA.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Linearly Weighted Moving Average Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Linearly Weighted Moving Average Indicator.
    /// </summary>
    public class LWMA : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LWMA"/> class. 
        /// </summary>
        public LWMA()
        {
            this.Name = "Linearly Weighted Moving Average";
            this.ShortName = "LWMA";
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

            var lwma = new double[price.Length];
            double avgsum = 0.0;
            double sum = 0.0;
            for (int i = 0; i < period - 1; i++)
            {
                avgsum += price[i] * (i + 1);
                sum += price[i];
            }

            var divider = period * (period + 1) / 2;
            for (int i = period - 1; i < price.Length; i++)
            {
                avgsum += price[i] * period;
                sum += price[i];
                lwma[i] = avgsum / divider;
                avgsum -= sum;
                sum -= price[i - period + 1];
            }

            return lwma;
        }
    }
}
