using CuttingEdge.Conditions;
using MgFx.History;

namespace MgFx.Indicators
{
    public class BOP : Indicator
    {
        /// <summary>
        /// Defaults ctor
        /// </summary>
        public BOP()
        {
            Name = "Balance of power";
            ShortName = "BOP";
        }

        /// <summary>
        /// Calculates indicator
        /// </summary>
        /// <param name="timeSeries">TimeSeries history</param>
        /// <returns>Calculated indicator as TimeSeries</returns>
        public static double[] Calculate(TimeSeries timeSeries)
        {
            Condition.Requires(timeSeries, "timeSeries")
                .IsNotNull();

            var bop = new double[timeSeries.Open.Length];
            for (var i = 0; i < timeSeries.Open.Length; i++)
            {
                if (timeSeries.High[i].AlmostEqual(timeSeries.Low[i]))
                    bop[i] = 0;
                else
                    bop[i] = (timeSeries.Close[i] - timeSeries.Open[i]) / (timeSeries.High[i] - timeSeries.Low[i]);
            }
            return bop;
        }
    }
}
