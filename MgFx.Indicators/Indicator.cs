// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Indicator.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   The base class for all indicators.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.Indicators
{
    /// <summary>
    /// The base class for all indicators.
    /// </summary>
    public abstract class Indicator
    {
        /// <summary>
        /// Gets or sets the indicator name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the indicator short name.
        /// </summary>
        public string ShortName { get; protected set; }
    }
}
