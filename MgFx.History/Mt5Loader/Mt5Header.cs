// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mt5Header.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   <c>Metatrader</c> 5 History header format
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.History.Mt5Loader
{
    using System;
    using System.Text;

    using CuttingEdge.Conditions;

    /// <summary>
    /// <c>Metatrader</c> 5 History header format
    /// </summary>
    public class MT5Header
    {
        /// <summary>
        /// The size of quote in bytes.
        /// </summary>
        public const int Size = 148;

        /// <summary>
        /// Initializes a new instance of the <see cref="MT5Header"/> class. 
        /// </summary>
        /// <param name="bytes"> Bytes buffer from file.</param>
        public MT5Header(byte[] bytes)
        {
            Condition.Requires(bytes, "bytes")
                .IsNotNull()
                .HasLength(Size);

            this.Version = BitConverter.ToInt32(bytes, 0);
            this.Copyright = Encoding.ASCII.GetString(bytes, 4, 64);
            this.Symbol = Encoding.ASCII.GetString(bytes, 68, 12);
            this.Period = BitConverter.ToInt32(bytes, 80);
            this.Digits = BitConverter.ToInt32(bytes, 84);
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        public string Copyright { get; private set; }

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Gets the period.
        /// </summary>
        public int Period { get; private set; }

        /// <summary>
        /// Gets the digits.
        /// </summary>
        public int Digits { get; private set; }
    }
}
