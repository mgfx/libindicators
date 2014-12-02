using CuttingEdge.Conditions;
using MgFx.History;

namespace MgFx.Indicators
{
    public class BullsPower : Indicator
    {
        /// <summary>
        /// Defaults BearsPower ctor
        /// </summary>
        public BullsPower()
        {
            Name = "Dr. Alexander Elder's Bulls/Bears Power (Elder-Rays)";
            ShortName = "BullsPower";
        }

        /// <summary>
        /// Calculates BullsPower
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">BullsPower period</param>
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

            var bulls = new double[price.Length];

            var ema = EMA.Calculate(price, period);
            for (var i = 0; i < price.Length; i++)
                bulls[i] = timeSeries.High[i] - ema[i];

            return bulls;
        }
    }
}
