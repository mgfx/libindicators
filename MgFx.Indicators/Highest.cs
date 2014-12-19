// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Highest.cs" company="Mariusz Gumowski">
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
    /// Highest Value Indicator.
    /// </summary>
    public class Highest : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Highest"/> class. 
        /// </summary>
        public Highest()
        {
            this.Name = "Highest Value";
            this.ShortName = "Highest";
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

            var highest = new double[price.Length];
            highest[0] = price[0];
            for (int i = 1; i < period; ++i)
            {
                if (price[i] > highest[i - 1])
                {
                    highest[i] = price[i];
                }
                else
                {
                    highest[i] = highest[i - 1];
                }
            }

            int highestIdx = 0;
            for (int i = period; i < price.Length; ++i)
            {
                double highestHigh = double.MinValue;
                var start = Math.Max(i - period + 1, highestIdx);
                for (int s = start; s <= i; ++s)
                {
                    if (price[s] > highestHigh)
                    {
                        highestHigh = price[s];
                        highestIdx = s;
                    }
                }

                highest[i] = highestHigh;
            }

            return highest;
        }
    }
}
