// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mt5PriceQuote.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   <c>Metatrader</c> 5 Single Price Quote Format
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.History.Mt5Loader
{
    using System;

    using CuttingEdge.Conditions;

    /// <summary>
    /// <c>Metatrader</c> 5 Single Price Quote Format
    /// </summary>
    public class MT5PriceQuote
    {
        /// <summary>
        /// The size of header in bytes.
        /// </summary>
        public const int Size = 60;

        /// <summary>
        /// Initializes a new instance of the <see cref="MT5PriceQuote"/> class.
        /// </summary>
        /// <param name="bytes">Bytes buffer from file.</param>
        public MT5PriceQuote(byte[] bytes)
        {
            Condition.Requires(bytes, "bytes")
                .IsNotEmpty()
                .HasLength(Size);

            this.Time = UnixTimeStampToDateTime(BitConverter.ToUInt64(bytes, 0));
            this.Open = BitConverter.ToDouble(bytes, 8);
            this.High = BitConverter.ToDouble(bytes, 16);
            this.Low = BitConverter.ToDouble(bytes, 24);
            this.Close = BitConverter.ToDouble(bytes, 32);
            this.TickCount = BitConverter.ToInt64(bytes, 40);
            this.Spread = BitConverter.ToInt32(bytes, 48);
            this.Vol = BitConverter.ToInt64(bytes, 52);
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        public DateTime Time { get; private set; }

        /// <summary>
        /// Gets the opening price.
        /// </summary>
        public double Open { get; private set; }

        /// <summary>
        /// Gets the highest price.
        /// </summary>
        public double High { get; private set; }

        /// <summary>
        /// Gets the lowest price.
        /// </summary>
        public double Low { get; private set; }

        /// <summary>
        /// Gets the close price.
        /// </summary>
        public double Close { get; private set; }

        /// <summary>
        /// Gets the tick count.
        /// </summary>
        public long TickCount { get; private set; }

        /// <summary>
        /// Gets the spread.
        /// </summary>
        public int Spread { get; private set; }

        /// <summary>
        /// Gets the volume.
        /// </summary>
        public long Vol { get; private set; }

        /// <summary>
        /// Converts unix time stamp to date time.
        /// </summary>
        /// <param name="unixTimeStamp">The unix time stamp.</param>
        /// <returns>The <see cref="DateTime"/>.</returns>
        private static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
