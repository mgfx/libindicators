using System;

namespace MgFx.Indicators
{
    /// <summary>
    /// Contains various helpers functions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Checks if the number is almost zero
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if is almost zero</returns>
        public static bool IsAlmostZero(this double value)
        {
            return (Math.Abs(value) < double.Epsilon);
        }

        /// <summary>
        /// Compares the numbers
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compareTo"></param>
        /// <returns>true if almost equal</returns>
        public static bool AlmostEqual(this double value, double compareTo)
        {
            return Math.Abs(value - compareTo) < double.Epsilon;
        }
    }
}
