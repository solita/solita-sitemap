using System;

namespace Solita.Sitemap
{
    public class SitemapUrlData
    {
        public string Url { get; set; }
        public DateTime? LastModified { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }
        public decimal? Priority { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SitemapUrlData) obj);
        }

        protected bool Equals(SitemapUrlData other)
        {
            return string.Equals(Url, other.Url) 
                && LastModified.Equals(other.LastModified) 
                && ChangeFrequency.Equals(other.ChangeFrequency) 
                && Priority.Equals(other.Priority);
        }

        public override int GetHashCode()
        {
            return Url.GetHashCode();
        }
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
