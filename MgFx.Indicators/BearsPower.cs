// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BearsPower.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Bears Power Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Bears Power Indicator.
    /// </summary>
    public class BearsPower : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BearsPower"/> class. 
        /// </summary>
        public BearsPower()
        {
            this.Name = "Dr. Alexander Elder's Bulls/Bears Power (Elder-Rays)";
            this.ShortName = "BearsPower";
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

            var bears = new double[price.Length];

            var ema = EMA.Calculate(price, period);
            for (var i = 0; i < price.Length; i++)
            {
                bears[i] = timeSeries.Low[i] - ema[i];
            }

            return bears;
        }
    }
}
