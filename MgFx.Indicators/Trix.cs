using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    public class Trix : Indicator
    {
        /// <summary>
        /// Default Trix ctor
        /// </summary>
        public Trix()
        {
            Name = "TRIX - Triple-smoothed exponential moving average";
            ShortName = "TRIX";
        }

        /// <summary>
        /// Calculates Trix 
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">Trix period</param>
        /// <returns>Calculated indicator as TimeSeries</returns>
        public static double[] Calculate(double[] price, int period)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(1)
                .IsLessOrEqual(price.Length);

            var trix = new double[price.Length];
            var ema1 = Ema.Calculate(price, period);
            var ema2 = Ema.Calculate(ema1, period);
            var ema3 = Ema.Calculate(ema2, period);
            trix[0] = 0.0;
            for (int i = 1; i < price.Length; ++i)
            {
                if (ema3[i].IsAlmostZero())
                    trix[i] = 0.0;
                else
                    trix[i] = 100.0 * ((ema3[i] - ema3[i - 1]) / ema3[i]);
            }

            return trix;
        }       
    }
}
