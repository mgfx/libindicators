// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileFormat.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Various file formats supported by <see cref="CsvLoader" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.History.CsvLoader
{
    /// <summary>
    /// Various file formats supported by <see cref="CsvLoader"/>.
    /// </summary>
    public enum FileFormat
    {
        /// <summary>
        /// The generic date time format.
        /// Example: 20120201 183205
        /// </summary>
        Generic,

        /// <summary>
        /// <c>Metatrader</c> date time format.
        /// Example: 2012.02.01,18:32
        /// </summary>
        Metatrader,

        /// <summary>
        /// <c>Metastock</c> date time format.
        /// Example: 201202011832
        /// </summary>
        Metastock,

        /// <summary>
        /// <c>Ninjatrader</c> date time format.
        /// Example: 20120201 183205
        /// </summary>
        NinjaTrader
    }
}
