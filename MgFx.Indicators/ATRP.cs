using CuttingEdge.Conditions;
using MgFx.History;

namespace MgFx.Indicators
{
    public class ATRP : Indicator
    {
        /// <summary>
        /// Defaults ctor
        /// </summary>
        public ATRP()
        {
            Name = "Average True Range Percentage";
            ShortName = "ATRP";
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
