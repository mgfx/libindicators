using System;

namespace MgFx.History
{
    public class Metadata
    {
        public string Symbol { get; set; }
        public int Period { get; set; }
        public string Filename { get; set; }      
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
