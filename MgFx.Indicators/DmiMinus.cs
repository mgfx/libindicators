// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DmiMinus.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Directional Movement Index Minus Indicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    using CuttingEdge.Conditions;

    using MgFx.History;

    /// <summary>
    /// Directional Movement Index Minus Indicator.
    /// </summary>
    public class DmiMinus : Indicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DmiMinus"/> class. 
        /// </summary>
        public DmiMinus()
        {
            this.Name = "Directional Movement Index Minus";
            this.ShortName = "DMI-";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="period">Indicator period.</param>
        /// <param name="timeSeries">Instrument <c>ohlc</c> time series.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price, int period, TimeSeries timeSeries)
        {
            Condition.Requires(price, "price")
                .IsNotEmpty();
            Condition.Requires(period, "period")
                .IsGreaterThan(0)
                .IsLessOrEqual(price.Length);
            Condition.Requires(timeSeries, "timeSeries")
                .IsNotNull();

            var pdm = new double[price.Length];
            pdm[0] = 0.0;

            for (int i = 1; i < price.Length; ++i)
            {
                var plusDm = timeSeries.High[i] - timeSeries.High[i - 1];
                var minusDm = timeSeries.Low[i - 1] - timeSeries.Low[i];

                if (plusDm < 0)
                {
                    plusDm = 0;
                }

                if (minusDm < 0)
                {
                    minusDm = 0;
                }

                if (plusDm.AlmostEqual(minusDm))
                {
                    plusDm = 0;
                }
                else if (plusDm < minusDm)
                {
                    plusDm = 0;
                }

                var trueHigh = timeSeries.High[i] > price[i - 1] ? timeSeries.High[i] : price[i - 1];
                var trueLow = timeSeries.Low[i] < price[i - 1] ? timeSeries.Low[i] : price[i - 1];
                var tr = trueHigh - trueLow;
                if (tr.IsAlmostZero())
                {
                    pdm[i] = 0;
                }
                else
                {
                    pdm[i] = 100 * plusDm / tr;
                }
            }

            var dmi = EMA.Calculate(pdm, period);

            return dmi;
        }
    }
}
