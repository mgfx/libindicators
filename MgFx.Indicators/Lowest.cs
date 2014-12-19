// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Lowest.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Lowest Value Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using System;

    using CuttingEdge.Conditions;

    /// <summary>
    /// Lowest Value Indicator.
    /// </summary>
    public class Lowest : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lowest"/> class. 
        /// </summary>
        public Lowest()
        {
            this.Name = "Lowest Value";
            this.ShortName = "Lowest";
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

            var lowest = new double[price.Length];
            lowest[0] = price[0];

            for (int i = 1; i < period; ++i)
            {
                if (price[i] < lowest[i - 1])
                {
                    lowest[i] = price[i];
                }
                else
                {
                    lowest[i] = lowest[i - 1];
                }
            }

            int lowestIdx = 0;
            for (int i = period; i < price.Length; ++i)
            {
                double lowestLow = double.MaxValue;
                var start = Math.Max(i - period + 1, lowestIdx);
                for (int s = start; s <= i; ++s)
                {
                    if (price[s] < lowestLow)
                    {
                        lowestLow = price[s];
                        lowestIdx = s;
                    }
                }

                lowest[i] = lowestLow;
            }

            return lowest;
        }
    }
}
