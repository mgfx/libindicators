// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BullsPower.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Bulls Power Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Bulls Power Indicator.
    /// </summary>
    public class BullsPower : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BullsPower"/> class. 
        /// </summary>
        public BullsPower()
        {
            this.Name = "Dr. Alexander Elder's Bulls/Bears Power (Elder-Rays)";
            this.ShortName = "BullsPower";
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

            var bulls = new double[price.Length];

            var ema = EMA.Calculate(price, period);
            for (var i = 0; i < price.Length; i++)
            {
                bulls[i] = timeSeries.High[i] - ema[i];
            }

            return bulls;
        }
    }
}
