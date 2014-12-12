// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateFormat.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   Date format selector class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.History.CsvLoader
{
    /// <summary>
    /// Date format selector class.
    /// </summary>
    public static class DateFormat
    {
        /// <summary>
        /// Gets file format.
        /// </summary>
        /// <param name="fileFormat">Select <see cref="FileFormat"/>.</param>
        /// <returns>Proper file format as <see cref="string"/>.</returns>
        public static string Get(FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.Generic:
                    return "YYYYMMHH";
            }

            return string.Empty;
        }
    }
}
