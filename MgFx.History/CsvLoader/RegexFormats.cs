// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegexFormats.cs" company="Mariusz Gumowski">
//   Copyright (c) 2003-2015 Mariusz Gumowski. All rights reserved.
// </copyright>
// <summary>
//   The regex formats.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MgFx.History.CsvLoader
{
    /// <summary>
    /// The regex formats.
    /// </summary>
    public static class RegexFormats
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="fileFormat">
        /// The file format.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Get(FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.Generic:
                    // 20140101 000200;1.30111;1.309610;1.306350;1.306455;10
                    return @"^(?<date>\d{8}) (?<time>\d{6});(?<open>[0-9]*\.?[0-9]+);(?<high>[0-9]*\.?[0-9]+);(?<low>[0-9]*\.?[0-9]+);(?<close>[0-9]*\.?[0-9]+);(?<vol>[0-9]*\.?[0-9]+)";
            }

            return string.Empty;
        }
    }
}

/*
 * 
 * Data Files: Detailed Specification
Here you can find all the details regarding any file we allow you to download.
Please, don’t hesitate to send us a message in case you find any trouble with the forex data files available in this website.

Regarding your question, we output the historical data in 6 diferent file formats.
Here the details:

1. Generic ASCII in M1 Bars (1 Minute Bars):

As example, in DAT_ASCII_EURUSD_M1_201202.csv:

20120201 000000;1.306600;1.306600;1.306560;1.306560;0
20120201 000100;1.306570;1.306570;1.306470;1.306560;0
20120201 000200;1.306520;1.306560;1.306520;1.306560;0
20120201 000300;1.306610;1.306610;1.306450;1.306450;0
20120201 000400;1.306470;1.306540;1.306470;1.306520;0
20120201 000500;1.306510;1.306650;1.306510;1.306600;0
20120201 000600;1.306610;1.306760;1.306610;1.306650;0

Row Fields:
DateTime Stamp;Bar OPEN Bid Quote;Bar HIGH Bid Quote;Bar LOW Bid Quote;Bar CLOSE Bid Quote;Volume

DateTime Stamp Format:
YYYYMMDD HHMMSS

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute
SS – Second, in this case it will be allways 00

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments

2. Generic ASCII in Ticks:

As example, in DAT_ASCII_EURUSD_T_201202.csv:

20120201 000003660,1.306600,1.306770,0
20120201 000003973,1.306580,1.306750,0
20120201 000005003,1.306590,1.306760,0
20120201 000005707,1.306600,1.306770,0
20120201 000006397,1.306590,1.306760,0
20120201 000007083,1.306600,1.306770,0
20120201 000014660,1.306560,1.306730,0
20120201 000014990,1.306570,1.306740,0

Row Fields:
DateTime Stamp,Bid Quote,Ask Quote,Volume

DateTime Stamp Format:
YYYYMMDD HHMMSSNNN

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute
SS – Second
NNN – Millisecond

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments

3. MetaTrader in M1 Bars (1 Minute Bars):

As example, in DAT_MT_EURUSD_M1_201202.csv:

2012.02.01,00:00,1.306600,1.306600,1.306560,1.306560,0
2012.02.01,00:01,1.306570,1.306570,1.306470,1.306560,0
2012.02.01,00:02,1.306520,1.306560,1.306520,1.306560,0
2012.02.01,00:03,1.306610,1.306610,1.306450,1.306450,0
2012.02.01,00:04,1.306470,1.306540,1.306470,1.306520,0
2012.02.01,00:05,1.306510,1.306650,1.306510,1.306600,0
2012.02.01,00:06,1.306610,1.306760,1.306610,1.306650,0
2012.02.01,00:07,1.306660,1.306660,1.306640,1.306650,0

Row Fields:
Date Stamp,Time Stamp,Bar OPEN Bid Quote,Bar HIGH Bid Quote,Bar LOW Bid Quote,Bar CLOSE Bid Quote,Volume

Date Stamp Format:
YYYY.MM.DD

Time Stamp Format:
HH:MM

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments

4. MetaStock in M1 Bars (1 Minute Bars):

As example, in DAT_MS_EURUSD_M1_201202.csv:

EURUSD,201202010000,1.306600,1.306600,1.306560,1.306560,0
EURUSD,201202010001,1.306570,1.306570,1.306470,1.306560,0
EURUSD,201202010002,1.306520,1.306560,1.306520,1.306560,0
EURUSD,201202010003,1.306610,1.306610,1.306450,1.306450,0
EURUSD,201202010004,1.306470,1.306540,1.306470,1.306520,0
EURUSD,201202010005,1.306510,1.306650,1.306510,1.306600,0
EURUSD,201202010006,1.306610,1.306760,1.306610,1.306650,0
EURUSD,201202010007,1.306660,1.306660,1.306640,1.306650,0

Row Fields:
Forex Pair,DateTime Stamp,Bar OPEN Bid Quote,Bar HIGH Bid Quote,Bar LOW Bid Quote,Bar CLOSE Bid Quote,Volume

DateTime Stamp Format:
YYYYMMDDHHMM

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments

5. Ninja Trader in M1 Bars (1 Minute Bars):

As example, in DAT_NT_EURUSD_M1_201202.csv:

20120201 000000;1.306600;1.306600;1.306560;1.306560;0
20120201 000100;1.306570;1.306570;1.306470;1.306560;0
20120201 000200;1.306520;1.306560;1.306520;1.306560;0
20120201 000300;1.306610;1.306610;1.306450;1.306450;0
20120201 000400;1.306470;1.306540;1.306470;1.306520;0
20120201 000500;1.306510;1.306650;1.306510;1.306600;0
20120201 000600;1.306610;1.306760;1.306610;1.306650;0

Row Fields:
DateTime Stamp;Bar OPEN Bid Quote;Bar HIGH Bid Quote;Bar LOW Bid Quote;Bar CLOSE Bid Quote;Volume

DateTime Stamp Format:
YYYYMMDD HHMMSS

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute
SS – Second, in this case it will be allways 00

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments

6. Ninja Trader in Tick Bars (1 Second Bars) with Last Quotes:

As example, in DAT_NT_AUDCAD_T_LAST_201212.csv:

20121202 170010;1.035400;0
20121202 170013;1.035600;0
20121202 170017;1.035550;0
20121202 170023;1.035550;0
20121202 170024;1.035600;0
20121202 170030;1.035550;0
20121202 170040;1.035610;0

Row Fields:
DateTime Stamp;LAST Quote;Volume

DateTime Stamp Format:
YYYYMMDD HHMMSS

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute
SS – Second

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments

7. Ninja Trader in Tick Bars (1 Second Bars) with Bid Quotes:

As example, in DAT_NT_AUDCAD_T_BID_201212.csv:

20121202 170010;1.035400;0
20121202 170013;1.035450;0
20121202 170017;1.035550;0
20121202 170023;1.035550;0
20121202 170024;1.035600;0
20121202 170030;1.035550;0
20121202 170040;1.035610;0

Row Fields:
DateTime Stamp;BID Quote;Volume

DateTime Stamp Format:
YYYYMMDD HHMMSS

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute
SS – Second

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments

8. Ninja Trader in Tick Bars (1 Second Bars) with Ask Quotes:

As example, in DAT_NT_AUDCAD_T_ASK_201212.csv:

20121202 170010;1.035990;0
20121202 170013;1.036050;0
20121202 170017;1.036100;0
20121202 170023;1.036050;0
20121202 170024;1.036100;0
20121202 170030;1.036100;0
20121202 170040;1.036210;0

Row Fields:
DateTime Stamp;ASK Quote;Volume

DateTime Stamp Format:
YYYYMMDD HHMMSS

Legend:
YYYY – Year
MM – Month (01 to 12)
DD – Day of the Month
HH – Hour of the day (in 24h format)
MM – Minute
SS – Second

TimeZone: Eastern Standard Time (EST) time-zone WITHOUT Day Light Savings adjustments
*/