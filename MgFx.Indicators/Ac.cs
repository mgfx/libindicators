// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ac.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Accelerator / Decelerator Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Accelerator / Decelerator Indicator.
    /// </summary>
    public class AC : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AC"/> class. 
        /// </summary>
        public AC()
        {
            this.Name = "Bill Williams' Accelerator/Decelerator oscillator";
            this.ShortName = "AC";
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

            var ao = AO.Calculate(price);
            var smaOfAo = SMA.Calculate(ao, 5);
            var ac = new double[price.Length];
            for (var i = 0; i < price.Length; ++i)
            {
                ac[i] = ao[i] - smaOfAo[i];
            }

            return ac;
        }
    }
}
