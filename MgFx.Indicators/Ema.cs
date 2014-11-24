using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    /// <summary>
    /// Simple Moving Average
    /// </summary>
    public class Ema : Indicator
    {
        /// <summary>
        /// SMA default ctor
        /// </summary>
        public Ema()
        {
            Name = "Exponential Moving Average";
            ShortName = "EMA";
        }

        /// <summary>
        /// Calculates Ema 
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">EMA period</param>
        /// <returns>Calculated indicator as TimeSeries</returns>
        public static double[] Calculate(double[] price, int period)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);

            var ema = new double[price.Length];
            double sum = price[0];
            double coeff = 2.0 / (1.0 + period);

            for (int i = 0; i < price.Length; i++)
            {
                sum += coeff*(price[i] - sum);
                ema[i] = sum;
            }

            return ema;
        }
    }
}
