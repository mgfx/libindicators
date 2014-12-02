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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static void Substract(this double[] src, double[] dst)
        {
            for (int i = 0; i < src.Length; i++)
                src[i] -= dst[i];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static double[] CreateSubstract(this double[] src, double[] dst)
        {
            var t = new double[src.Length];
            for (int i = 0; i < src.Length; i++)
                t[i] = src[i] - dst[i];

            return t;
        }
    }
}
