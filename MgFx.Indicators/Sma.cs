using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    /// <summary>
    /// Simple Moving Average
    /// </summary>
    public class Sma : Indicator
    {
        /// <summary>
        /// SMA default ctor
        /// </summary>
        public Sma()
        {
            Name = "Simple Moving Average";
            ShortName = "SMA";
        }

        /// <summary>
        /// Calculates Sma 
        /// </summary>
        /// <param name="price">Timeseries of price for calculation</param>
        /// <param name="period">SMA period</param>
        /// <returns>Calculated indicator as TimeSeries</returns>
        public static double[] Calculate(double[] price, int period)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);

            var sma = new double[price.Length];

            double sum = 0;

            for (var i = 0; i < period; i++)
            {
                sum += price[i];
                sma[i] = sum / (i + 1);
            }

            for (var i = period; i < price.Length; i++)
            {
                sum = 0;
                for (var j = i; j > i - period; j--)
                    sum += price[j];
                sma[i] = sum / period;
            }

            return sma;
        }       
    }
}
