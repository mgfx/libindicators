// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BOP.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Balance Of Power Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Balance Of Power Indicator.
    /// </summary>
    public class BOP : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BOP"/> class. 
        /// </summary>
        public BOP()
        {
            this.Name = "Balance Of Power";
            this.ShortName = "BOP";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="timeSeries">Instrument <c>ohlc</c> time series.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(TimeSeries timeSeries)
        {
            Condition.Requires(timeSeries, "timeSeries")
                .IsNotNull();

            var bop = new double[timeSeries.Open.Length];
            for (var i = 0; i < timeSeries.Open.Length; i++)
            {
                if (timeSeries.High[i].AlmostEqual(timeSeries.Low[i]))
                {
                    bop[i] = 0;
                }
                else
                {
                    bop[i] = (timeSeries.Close[i] - timeSeries.Open[i]) / (timeSeries.High[i] - timeSeries.Low[i]);
                }
            }

            return bop;
        }
    }
}
