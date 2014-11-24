namespace MgFx.History
{
    /// <summary>
    /// Enumerates different prices
    /// </summary>
    public enum Price
    {
        /// <summary>
        /// Open price
        /// </summary>
        Open,

        /// <summary>
        /// Highest price
        /// </summary>
        High,

        /// <summary>
        /// Lowest price
        /// </summary>
        Low,

        /// <summary>
        /// Closing price
        /// </summary>
        Close,

        /// <summary>
        /// Median price, (High + Low) / 2
        /// </summary>
        Median,

        /// <summary>
        /// Typical price, (High + Low + Close) / 3
        /// </summary>
        Typical,

        /// <summary>
        /// Weighted price, (Open + High + Low + Close) / 4
        /// </summary>
        Weighted
    }
}
