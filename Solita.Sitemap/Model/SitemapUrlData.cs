using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solita.Sitemap.Model
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
