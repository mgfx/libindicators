// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Metadata.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Metadata of trading instrument.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.History
{
    using System;

    /// <summary>
    /// Metadata of trading instrument.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the start date and time.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end date and time.
        /// </summary>
        public DateTime End { get; set; }
    }
}
