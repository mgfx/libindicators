using System;

namespace MgFx.History
{
    public class TimeSeries
    {
        public double[] Open { get; private set; }
        public double[] High { get; private set; }
        public double[] Low { get; private set; }
        public double[] Close { get; private set; }
        public double[] Vol { get; private set; }
        public double[] Median { get; private set; }
        public double[] Typical { get; private set; }
        public double[] Weighted { get; private set; }
        public DateTime[] Time { get; private set; }
    }
}
