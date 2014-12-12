// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ATRP.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Average True Range Percentage Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Average True Range Percentage Indicator.
    /// </summary>
    public class ATRP : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ATRP"/> class. 
        /// </summary>
        public ATRP()
        {
            this.Name = "Average True Range Percentage";
            this.ShortName = "ATRP";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="period">Indicator period.</param>
        /// <param name="timeSeries">Instrument <c>ohlc</c> time series.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(int period, TimeSeries timeSeries)
        {
            Condition.Requires(timeSeries, "timeSeries")
                .IsNotNull();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(timeSeries.Close.Length);

            var atr = ATR.Calculate(period, timeSeries);
            var atrp = new double[atr.Length];
            for (var i = period; i < timeSeries.Close.Length; i++)
            {
                atrp[i] = atr[i] * 100.0 / timeSeries.Close[i];
            }

            return atrp;
        }
    }
}
