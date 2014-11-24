using System;
using CuttingEdge.Conditions;

namespace MgFx.History.Mt5Loader
{
    /// <summary>
    /// Metatrader 5 Single Price Quoute Format
    /// </summary>
    public class MT5PriceQuote
    {
        public DateTime Time { get; private set; }
        public double Open { get; private set; }
        public double High { get; private set; }
        public double Low { get; private set; }
        public double Close { get; private set; }
        public long TickCount { get; private set; }
        public int Spread { get; private set; }
        public long Vol { get; private set; }
        public const int Size = 60;

        private static DateTime UnixTimeStampToDateTime(UInt64 unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// Converts byte array to MT5 Price Quoute
        /// </summary>
        /// <param name="bytes"></param>
        public MT5PriceQuote(byte[] bytes)
        {
            Condition.Requires(bytes, "bytes")
                .IsNotEmpty()
                .HasLength(Size);

            Time = UnixTimeStampToDateTime(BitConverter.ToUInt64(bytes, 0));
            Open = BitConverter.ToDouble(bytes, 8);
            High = BitConverter.ToDouble(bytes, 16);
            Low = BitConverter.ToDouble(bytes, 24);
            Close = BitConverter.ToDouble(bytes, 32);
            TickCount = BitConverter.ToInt64(bytes, 40);
            Spread = BitConverter.ToInt32(bytes, 48);
            Vol = BitConverter.ToInt64(bytes, 52);
        }
    }
}
