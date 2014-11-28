using CuttingEdge.Conditions;
using MgFx.History;

namespace MgFx.Indicators
{
    public class DmiPlus : Indicator
    {
        /// <summary>
        /// Default DmiPlus ctor
        /// </summary>
        public DmiPlus()
        {
            Name = "Directional Movement Index Plus";
            ShortName = "DMI+";
        }

        /// <summary>
        /// Calculates DMI+
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">DMI period</param>
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

            var mdm = new double[price.Length];
            mdm[0] = 0.0;

            for (int i = 1; i < price.Length; ++i)
            {
                var plusDm = timeSeries.High[i] - timeSeries.High[i - 1];
                var minusDm = timeSeries.Low[i - 1] - timeSeries.Low[i];

                if (plusDm < 0)
                    plusDm = 0;
                if (minusDm < 0)
                    minusDm = 0;

                if (plusDm.AlmostEqual(minusDm))
                {
                    minusDm = 0;
                }
                else if (plusDm >= minusDm)
                {
                    minusDm = 0;
                }

                var trueHigh = timeSeries.High[i] > price[i - 1] ? timeSeries.High[i] : price[i - 1];
                var trueLow = timeSeries.Low[i] < price[i - 1] ? timeSeries.Low[i] : price[i - 1];
                var tr = trueHigh - trueLow;
                if (tr.IsAlmostZero())
                {
                    mdm[i] = 0;
                }
                else
                {
                    mdm[i] = 100 * minusDm / tr;
                }
            }
            var dmi = Ema.Calculate(mdm, period);

            return dmi;
        }
    }
}
