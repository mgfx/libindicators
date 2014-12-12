// --------------------------------------------------------------------------------------------------------------------
// <copyright file="COG.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Center Of Gravity Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Center Of Gravity Indicator.
    /// </summary>
    public class COG : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="COG"/> class. 
        /// </summary>
        public COG()
        {
            this.Name = "John Ehlers's Center of Gravity oscillator";
            this.ShortName = "COG";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="period">Indicator period.</param>
        /// <returns>Calculated indicator series.</returns>
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
                var weightedSum = 0.0;
                var sum = 0.0;
                for (int j = 0; j < period; ++j)
                {
                    weightedSum += price[i - period + j + 1] * (period - j);
                    sum += price[i - period + j + 1];
                }

                cog[i] = -weightedSum / sum;
            }

            return cog;
        }
    }
}
