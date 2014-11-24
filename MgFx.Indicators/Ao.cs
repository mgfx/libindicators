using CuttingEdge.Conditions;

namespace MgFx.Indicators
{
    public class Ao : Indicator
    {
        /// <summary>
        /// Ao default ctor
        /// </summary>
        public Ao()
        {
            Name = "Bill Williams' Awesome Oscillator";
            ShortName = "AO";
        }

        /// <summary>
        /// Calculates Ao
        /// </summary>
        /// <param name="price">Price series used to calculate</param>
        /// <returns></returns>
        public static double[] Calculate(double[] price)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();

            var aoFast = Sma.Calculate(price, 5);
            var aoSlow = Sma.Calculate(price, 34);
            var ao = new double[price.Length];

            for (int i = 0; i < price.Length; i++)
                ao[i] = aoFast[i] - aoSlow[i];

            return ao;
        }
    }
}
