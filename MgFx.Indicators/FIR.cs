// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FIR.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Finite Impulse Response Moving Average Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;
    
    /// <summary>
    /// Finite Impulse Response Moving Average Indicator.
    /// Weights examples:
    /// <c>Kalman</c> velocity component applied for lag reduction:
    ///   new double[] { 2, 3, 2, 0, -1 }
    ///   new double[] { 2, 3, 4, 3, 1, 0, -1 }
    ///   new double[] { 2, 3, 4, 5, 4, 2, 1, 0, -1 }
    ///   new double[] { 2, 3, 4, 5, 6, 5, 3, 2, 1, 0, -1 }
    ///   new double[] { 2, 3, 4, 5, 6, 7, 6, 4, 3, 2, 1, 0, -1 }
    /// FIR Smoother:
    ///   new double[] { 2, 7, 9, 6, 1, -1, -3 }
    /// IIR Smoother:
    ///   new double[] { 2, 4, 0, 0, -1 }
    /// Other filters:
    ///   new double[] { 1, 2, 1 }
    ///   new double[] { 1, 2, 2, 1 }
    ///   new double[] { 1, 2, 3, 2, 1 }
    ///   new double[] { 1, 2, 3, 3, 2, 1 }
    ///   new double[] { 1, 2, 3, 4, 3, 2, 1 }
    ///   new double[] { 1, 2, 3, 4, 4, 3, 2, 1 }
    ///   new double[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 }
    ///   new double[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }
    ///   new double[] { 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1 }
    ///   new double[] { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1 }
    /// </summary>
    public class FIR : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIR"/> class.
        /// </summary>
        public FIR()
        {
            this.Name = "John F. Ehlers' Finite Impulse Response Moving Average";
            this.ShortName = "FIR";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="weights">Indicator weights.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price, double[] weights)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(weights, "weights")
                .IsNotNull()
                .IsNotEmpty();

            var fir = new double[price.Length];
            var divider = 0.0;

            for (int i = 0; i < weights.Length; ++i)
            {
                fir[i] = 0;
                divider += weights[i];
            }

            for (int i = weights.Length; i < price.Length; ++i)
            {
                var sum = 0.0;
                for (int w = 0; w < weights.Length; w++)
                {
                    sum += weights[w] * price[i - w];
                }

                fir[i] = sum / divider;
            }

            return fir;
        }
    }
}
