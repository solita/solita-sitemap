#Solita.Sitemap

Simple and minimal sitemap serializer.

## Usage

```c#
var urls = new List<SitemapUrlData>();

// add stuff
urls.Add(new SitemapUrlData
{
    Url = "http://google.com",
    ChangeFrequency = ChangeFrequency.Always,
    LastModified = DateTime.Now,
    Priority = 1.0m
});

// serialize!
var xml = new SitemapModelConverter().Serialize(urls);
```
