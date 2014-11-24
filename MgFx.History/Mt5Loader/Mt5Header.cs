using System;
using System.Text;
using CuttingEdge.Conditions;

namespace MgFx.History.Mt5Loader
{
    /// <summary>
    /// Metatrader 5 History header format
    /// </summary>
    public class MT5Header
    {
        public int Version { get; private set; }
        public string Copyright { get; private set; }
        public string Symbol { get; private set; }
        public int Period { get; private set; }
        public int Digits { get; private set; }
        public const int Size = 148;

        /// <summary>
        /// Created MT5header from metatrader history file
        /// </summary>
        /// <param name="bytes"></param>
        public MT5Header(byte[] bytes)
        {
            Condition.Requires(bytes, "bytes")
                .IsNotNull()
                .HasLength(Size);

            Version = BitConverter.ToInt32(bytes, 0);
            Copyright = Encoding.ASCII.GetString(bytes, 4, 64);
            Symbol = Encoding.ASCII.GetString(bytes, 68, 12);
            Period = BitConverter.ToInt32(bytes, 80);
            Digits = BitConverter.ToInt32(bytes, 84);
        }
    }
}
