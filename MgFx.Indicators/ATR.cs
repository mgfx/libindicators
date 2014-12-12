// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ATR.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Average True Range Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using System;

    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Average True Range Indicator.
    /// </summary>
    public class ATR : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ATR"/> class. 
        /// </summary>
        public ATR()
        {
            this.Name = "Welles Wilder's Average True Range";
            this.ShortName = "ATR";
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

            var temp = new double[timeSeries.Close.Length];
            temp[0] = 0;

            for (var i = 1; i < timeSeries.Close.Length; i++)
            {
                var diff1 = Math.Abs(timeSeries.Close[i - 1] - timeSeries.High[i]);
                var diff2 = Math.Abs(timeSeries.Close[i - 1] - timeSeries.Low[i]);
                var diff3 = timeSeries.High[i] - timeSeries.Low[i];

                var max = diff1 > diff2 ? diff1 : diff2;
                temp[i] = max > diff3 ? max : diff3;
            }

            var atr = SMA.Calculate(temp, period);

            return atr;
        }
    }
}
