using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    public class AO : Indicator
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public AO()
        {
            Name = "Bill Williams' Awesome Oscillator";
            ShortName = "AO";
        }

        /// <summary>
        /// Calculates indicator
        /// </summary>
        /// <param name="price">Price series used to calculate</param>
        /// <returns></returns>
        public static double[] Calculate(double[] price)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();

            var aoFast = SMA.Calculate(price, 5);
            var aoSlow = SMA.Calculate(price, 34);
            var ao = new double[price.Length];

            for (int i = 0; i < price.Length; i++)
                ao[i] = aoFast[i] - aoSlow[i];

            return ao;
        }
    }
}
