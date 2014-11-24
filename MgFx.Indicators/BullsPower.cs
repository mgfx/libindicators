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
        private static double[] Calculate(double[] price, int period, TimeSeries timeSeries)
        {
            var bulls = new double[price.Length];

            var ema = Ema.Calculate(price, period);
            for (var i = 0; i < price.Length; i++)
                bulls[i] = timeSeries.High[i] - ema[i];

            return bulls;
        }
    }
}
