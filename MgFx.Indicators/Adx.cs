// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Adx.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Average Directional Movement Index Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using System;

    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Average Directional Movement Index Indicator.
    /// </summary>
    public class ADX : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ADX"/> class. 
        /// </summary>
        public ADX()
        {
            this.Name = "Welles Wilder' Average Directional Movement Index";
            this.ShortName = "EMA";
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

            var dx = new double[price.Length];
            var pDi = DmiPlus.Calculate(price, period, timeSeries);
            var mDi = DmiMinus.Calculate(price, period, timeSeries);
            for (var i = 0; i < price.Length; ++i)
            {
                var diff = pDi[i] + mDi[i];
                if (diff.IsAlmostZero())
                {
                    dx[i] = 0;
                }
                else
                {
                    dx[i] = 100 * (Math.Abs(pDi[i] - mDi[i]) / (pDi[i] + mDi[i]));
                }
            }

            var adx = EMA.Calculate(dx, period);

            return adx;
        }
    }
}
