// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSeries.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   The time series.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.History
{
    using System;

    /// <summary>
    /// The time series.
    /// </summary>
    public class TimeSeries
    {
        /// <summary>
        /// Gets the open price series.
        /// </summary>
        public double[] Open { get; private set; }

        /// <summary>
        /// Gets the highest price series.
        /// </summary>
        public double[] High { get; private set; }

        /// <summary>
        /// Gets the lowest price series.
        /// </summary>
        public double[] Low { get; private set; }

        /// <summary>
        /// Gets the close price series.
        /// </summary>
        public double[] Close { get; private set; }

        /// <summary>
        /// Gets the volume series.
        /// </summary>
        public double[] Vol { get; private set; }

        /// <summary>
        /// Gets the median price series.
        /// </summary>
        public double[] Median { get; private set; }

        /// <summary>
        /// Gets the typical price series.
        /// </summary>
        public double[] Typical { get; private set; }

        /// <summary>
        /// Gets the weighted price series.
        /// </summary>
        public double[] Weighted { get; private set; }

        /// <summary>
        /// Gets the date and time series.
        /// </summary>
        public DateTime[] Time { get; private set; }
    }
}
