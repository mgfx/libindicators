using System;
using CuttingEdge.Conditions;
using MgFx.History;

namespace MgFx.Indicators
{
    /// <summary>
    /// Average Directional Movement Index
    /// </summary>
    public class ADX : Indicator
    {
        /// <summary>
        /// default ctor
        /// </summary>
        public ADX()
        {
            Name = "Welles Wilder' Average Directional Movement Index";
            ShortName = "EMA";
        }

        /// <summary>
        /// Calculates indicator
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">Indicator period</param>
        /// <returns>Calculated indicator as TimeSeries</returns>
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
                    dx[i] = 0;
                else dx[i] = 100 * (Math.Abs(pDi[i] - mDi[i]) / (pDi[i] + mDi[i]));
            }
            var adx = EMA.Calculate(dx, period);

            return adx;
        }
    }
}
