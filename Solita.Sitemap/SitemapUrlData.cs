using System;

namespace Solita.Sitemap
{
    public class SitemapUrlData
    {
        public string Url { get; set; }
        public DateTime? LastModified { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }
        public decimal? Priority { get; set; }
    }

    public enum ChangeFrequency
    {
        Always,
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Never
    }
}
