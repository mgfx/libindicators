// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rsi.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Relative Strength Index Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Relative Strength Index Indicator.
    /// </summary>
    public class RSI : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RSI"/> class. 
        /// </summary>
        public RSI()
        {
            this.Name = "Relative Strength Index developed by J. Welles Wilder and published in a 1978 book, New Concepts in Technical Trading Systems";
            this.ShortName = "RSI";
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

            var rsi = new double[price.Length];

            double gain = 0.0;
            double loss = 0.0;

            // first RSI value
            rsi[0] = 0.0;
            for (int i = 1; i <= period; ++i)
            {
                var diff = price[i] - price[i - 1];
                if (diff >= 0)
                {
                    gain += diff;
                }
                else
                {
                    loss -= diff;
                }
            }

            double avrg = gain / period;
            double avrl = loss / period;
            double rs = gain / loss;
            rsi[period] = 100 - (100 / (1 + rs));

            for (int i = period + 1; i < price.Length; ++i)
            {
                var diff = price[i] - price[i - 1];

                if (diff >= 0)
                {
                    avrg = ((avrg * (period - 1)) + diff) / period;
                    avrl = (avrl * (period - 1)) / period;
                }
                else
                {
                    avrl = ((avrl * (period - 1)) - diff) / period;
                    avrg = (avrg * (period - 1)) / period;
                }

                rs = avrg / avrl;

                rsi[i] = 100 - (100 / (1 + rs));
            }

            return rsi;
        }
    }
}
