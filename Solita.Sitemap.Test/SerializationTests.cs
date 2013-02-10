using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solita.Sitemap.Test
{
    [TestClass]
    public class SerializationTests
    {
        private const string Filename = "xml/Sitemap.xml";

        [TestMethod]
        public void Serialize()
        {
            var urls = GetReferenceData();
            var xml = new SitemapXmlSerializer().Serialize(urls);

            Assert.AreEqual(xml, GetReferenceXml());
            Debug.Write(xml);
        }

        [TestMethod]
        public void Deserialize()
        {
            var xml = GetReferenceXml();
            var urls = new SitemapXmlSerializer().Deserialize(xml);

            foreach (var refUrl in GetReferenceData())
            {
                Assert.IsTrue(urls.Contains(refUrl));
            }
        }


        private string GetReferenceXml()
        {
            return File.ReadAllText(Filename).Trim();
        }

        private List<SitemapUrlData> GetReferenceData()
        {
            return new List<SitemapUrlData>
            {
                new SitemapUrlData
                {
                    Url = "http://github.com",
                    ChangeFrequency = ChangeFrequency.Hourly,
                    LastModified = new DateTime(2012, 12, 24),
                    Priority = 0.75m
                },
                new SitemapUrlData
                {
                    Url = "http://google.com",
                    ChangeFrequency = ChangeFrequency.Daily,
                    LastModified = new DateTime(2011, 6, 21),
                    Priority = 0.5m
                },
                new SitemapUrlData
                {
                    Url = "http://www.facebook.com/",
                    ChangeFrequency = ChangeFrequency.Never,
                    LastModified = new DateTime(2010, 1, 13),
                    Priority = 0.0m
                }
            };
        } 
    }
}
