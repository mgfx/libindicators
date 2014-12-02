using System;
using CuttingEdge.Conditions;
using MgFx.History;

namespace MgFx.Indicators
{
    public class ATR : Indicator
    {
        /// <summary>
        /// Defaults ctor
        /// </summary>
        public ATR()
        {
            Name = "Welles Wilder's Average True Range";
            ShortName = "ATR";
        }

        /// <summary>
        /// Calculates indicator
        /// </summary>
        /// <param name="period">Indicator period</param>
        /// <param name="timeSeries">TimeSeries history</param>
        /// <returns>Calculated indicator</returns>
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
