using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    public class COG : Indicator
    {
        /// <summary>
        /// Defaults ctor
        /// </summary>
        public COG()
        {
            Name = "John Ehlers's Center of Gravity oscillator";
            ShortName = "COG";
        }

        /// <summary>
        /// Calculates indicator
        /// </summary>
        /// <param name="price"></param>
        /// <param name="period">period</param>
        /// <returns>Calculated indicator as TimeSeries</returns>
        public static double[] Calculate(double[] price, int period)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);

            var cog = new double[price.Length];
            for (int i = period - 1; i < price.Length; ++i)
            {
                var wSum = 0.0;
                var sum = 0.0;
                for (int j = 0; j < period; ++j)
                {
                    wSum += price[i - period + j + 1] * (period - j);
                    sum += price[i - period + j + 1];
                }
                cog[i] = -wSum / sum;
            }
            return cog;
        }
    }
}
