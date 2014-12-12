// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIR.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Infinite Impulse Response Moving Average Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    /// <summary>
    /// Infinite Impulse Response Moving Average Indicator.
    /// </summary>
    public class IIR : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IIR"/> class.
        /// </summary>
        public IIR()
        {
            this.Name = "John F. Ehlers' Infinite Impulse Response Moving Average";
            this.ShortName = "IIR";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();

            return FIR.Calculate(price, new double[] { 2, 4, 0, 0, -1 });
        }
    }
}
