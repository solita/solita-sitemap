using System;
using System.Collections.Generic;
using System.Linq;
using Solita.Sitemap.Schema;

namespace Solita.Sitemap
{
    public class SitemapXmlSerializer
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
                type.lastmod = (model.LastModified.Value.Kind == DateTimeKind.Unspecified)
                                  ? DateTime.SpecifyKind(model.LastModified.Value, DateTimeKind.Local)
                                  : model.LastModified.Value;
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


        public List<SitemapUrlData> Deserialize(string xml)
        {
            var root = urlset.Deserialize(xml);
            return root.url.Select(ToProductModel).ToList();
        }

        private SitemapUrlData ToProductModel(tUrl type)
        {
            var model = new SitemapUrlData();
            model.Url = type.loc;
            model.LastModified = type.lastmodSpecified ? type.lastmod : (DateTime?) null;
            model.ChangeFrequency = type.changefreqSpecified ? ToChangeFreqModel(type.changefreq) : (ChangeFrequency?) null;
            model.Priority = type.prioritySpecified ? type.priority : (decimal?) null;
            return model;
        }

        private ChangeFrequency ToChangeFreqModel(tChangeFreq type)
        {
            switch (type)
            {
                case tChangeFreq.always:
                    return ChangeFrequency.Always;
                case tChangeFreq.hourly:
                    return ChangeFrequency.Hourly;
                case tChangeFreq.daily:
                    return ChangeFrequency.Daily;
                case tChangeFreq.weekly:
                    return ChangeFrequency.Weekly;
                case tChangeFreq.monthly:
                    return ChangeFrequency.Monthly;
                case tChangeFreq.yearly:
                    return ChangeFrequency.Yearly;
                case tChangeFreq.never:
                    return ChangeFrequency.Never;
                default:
                    return ChangeFrequency.Always;
            }
        }
    }
}