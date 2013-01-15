using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solita.Sitemap.Model;

namespace Solita.Sitemap.Schema
{
    public class SitemapModelConverter
    {
        public string Serialize(IEnumerable<SitemapUrlData> data)
        {
            var root = new urlset {url = data.Select(ToProductType).ToList()};
            return root.Serialize();
        }

        private tUrl ToProductType(SitemapUrlData model)
        {
            var type = new tUrl { loc = model.Url };

            if (model.LastModified.HasValue)
            {
                type.lastmodSpecified = true;
                type.lastmod = model.LastModified.Value;
            }

            if (model.ChangeFrequency.HasValue)
            {
                type.changefreqSpecified = true;
                type.changefreq = ToChangeFreqType(model.ChangeFrequency.Value);
            }

            if (model.Priority.HasValue)
            {
                type.prioritySpecified = true;
                type.priority = model.Priority.Value;
            }

            return type;
        }

        private tChangeFreq ToChangeFreqType(ChangeFrequency model)
        {
            switch (model) 
            {
                case ChangeFrequency.Always:
                    return tChangeFreq.always;
                case ChangeFrequency.Hourly:
                    return tChangeFreq.hourly;
                case ChangeFrequency.Daily:
                    return tChangeFreq.daily;
                case ChangeFrequency.Weekly:
                    return tChangeFreq.weekly;
                case ChangeFrequency.Monthly:
                    return tChangeFreq.monthly;
                case ChangeFrequency.Yearly:
                    return tChangeFreq.yearly;
                case ChangeFrequency.Never:
                    return tChangeFreq.never;   
                default:
                    return tChangeFreq.always;
            }
        }
    }
}