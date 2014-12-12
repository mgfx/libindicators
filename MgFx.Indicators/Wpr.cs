// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wpr.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Williams Percent Range Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Williams Percent Range Indicator.
    /// </summary>
    public class WPR : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WPR"/> class. 
        /// </summary>
        public WPR()
        {
            this.Name = "Williams Percent Range";
            this.ShortName = "WPR";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="period">Indicator period.</param>
        /// <param name="timeSeries">Instrument <c>ohlc</c> time series.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price, int period, TimeSeries timeSeries)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);
            Condition.Requires(timeSeries, "timeSeries")
                .IsNotNull();

            var wpr = new double[price.Length];

            for (var i = period; i < price.Length; i++)
            {
                var highest = double.MinValue;
                var lowest = double.MaxValue;

                for (int j = i - period + 1; j <= i; j++)
                {
                    if (timeSeries.High[j] > highest)
                    {
                        highest = timeSeries.High[j];
                    }

                    if (timeSeries.Low[j] < lowest)
                    {
                        lowest = timeSeries.Low[j];
                    }
                }

                wpr[i] = -100 * (highest - timeSeries.Close[i]) / (highest - lowest);
            }

            return wpr;
        }
    }
}
