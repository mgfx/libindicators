// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Momentum.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Momentum Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Momentum Indicator.
    /// </summary>
    public class Momentum : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Momentum"/> class. 
        /// </summary>
        public Momentum()
        {
            this.Name = "Momentum";
            this.ShortName = "Momentum";
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

            var momentum = new double[price.Length];
            for (int i = 0; i < period; i++)
            {
                momentum[i] = 0;
            }

            for (int i = period; i < price.Length; i++)
            {
                momentum[i] = price[i] * 100 / price[i - period];
            }

            return momentum;
        }
    }
}
