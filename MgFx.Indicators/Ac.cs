using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    public class AC : Indicator
    {
        /// <summary>
        /// default ctor
        /// </summary>
        public AC()
        {
            Name = "Bill Williams' Accelerator/Decelerator oscillator";
            ShortName = "AC";
        }

        /// <summary>
        /// Calcultes indicator
        /// </summary>
        /// <param name="price">price</param>
        /// <param name="period">period</param>
        /// <returns></returns>
        public static double[] Calculate(double[] price, int period)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);

            var ao = AO.Calculate(price);
            var aoSma = SMA.Calculate(ao, 5);
            return ao.CreateSubstract(aoSma);
/*            var ac = new double[price.Length];
            for (var i = 0; i < price.Length; ++i)
                ac[i] = ao[i] - aoSma[i];
            return ac;*/
        }
    }
}
