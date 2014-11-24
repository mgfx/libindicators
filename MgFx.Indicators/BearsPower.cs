using MgFx.History;

namespace MgFx.Indicators
{
    public class BearsPower : Indicator
    {
        /// <summary>
        /// Defaults BearsPower ctor
        /// </summary>
        public BearsPower()
        {
            Name = "Dr. Alexander Elder's Bulls/Bears Power (Elder-Rays)";
            ShortName = "BearsPower";
        }

        /// <summary>
        /// Calculates BearsPower
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">BearsPower period</param>
        /// <param name="timeSeries">TimeSeries history</param>
        /// <returns>Calculated indicator as TimeSeries</returns>
        private static double[] Calculate(double[] price, int period, TimeSeries timeSeries)
        {
            var bears = new double[price.Length];

            var ema = Ema.Calculate(price, period);
            for (var i = 0; i < price.Length; i++)
                bears[i] = timeSeries.Low[i] - ema[i];

            return bears;
        }
    }
}
