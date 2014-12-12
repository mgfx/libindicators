// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sma.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Simple Moving Average Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Simple Moving Average Indicator.
    /// </summary>
    public class SMA : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SMA"/> class. 
        /// </summary>
        public SMA()
        {
            this.Name = "Simple Moving Average";
            this.ShortName = "SMA";
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

            var sma = new double[price.Length];

            double sum = 0;

            for (var i = 0; i < period; i++)
            {
                sum += price[i];
                sma[i] = sum / (i + 1);
            }

            for (var i = period; i < price.Length; i++)
            {
                sum = 0;
                for (var j = i; j > i - period; j--)
                {
                    sum += price[j];
                }

                sma[i] = sum / period;
            }

            return sma;
        }       
    }
}
