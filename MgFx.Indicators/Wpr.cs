using CuttingEdge.Conditions;
using MgFx.History;

namespace MgFx.Indicators
{
    public class WPR : Indicator
    {
        /// <summary>
        /// Defaults Wpr ctor
        /// </summary>
        public WPR()
        {
            Name = "Williams Percent Range";
            ShortName = "WPR";
        }

        /// <summary>
        /// Calculates WPR
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">WPR period</param>
        /// <param name="timeSeries">TimeSeries history</param>
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

            var wpr = new double[price.Length];

            for (var i = period; i < price.Length; i++)
            {
                var highest = double.MinValue;
                var lowest = double.MaxValue;

                for (int j = i - period + 1; j <= i; j++)
                {
                    if (timeSeries.High[j] > highest)
                        highest = timeSeries.High[j];
                    if (timeSeries.Low[j] < lowest)
                        lowest = timeSeries.Low[j];
                }
                wpr[i] = -100 * (highest - timeSeries.Close[i]) / (highest - lowest);
            }

            return wpr;
        }
    }
}
