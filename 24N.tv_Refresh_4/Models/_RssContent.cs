using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Xml;
using System.Xml.Linq;

namespace _24N.tv_Refresh.Models
{
    public class _RssContent
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }
        public string Encoded { get; set; }
    }

    public class _RssReader
    {
        private const string CACHEKEYPREFIX = "Cache@GetRssFeed:";
        private static readonly TimeSpan CACHEDURATION = new TimeSpan(0, 0, 5, 0, 0); // 5MIN

        public static IEnumerable<_RssContent> GetFeed(string feedUrl, bool noCache = false)
        {
            var cacheKey = string.Format("{0}Rss:Url{1}", CACHEKEYPREFIX, feedUrl);
            ObjectCache cache = MemoryCache.Default;

            if (!noCache && cache.Contains(cacheKey))
                return (IEnumerable<_RssContent>)cache.Get(cacheKey);
            else
            {
                // Get data from source
                var results = _RssReader.GetFeedNoCache(feedUrl);

                // Store data in the cache
                if (!noCache && results != null)
                {
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.Add(CACHEDURATION);
                    cache.Add(cacheKey, results, cacheItemPolicy);
                }

                return results;
            }
        }

        private static IEnumerable<_RssContent> GetFeedNoCache(string feedUrl)
        {
            IEnumerable<_RssContent> blogMainFeed = new List<_RssContent>();

            WebRequest request = WebRequest.Create(feedUrl);
            request.Timeout = 5000; //5 Second Timeout

            using (WebResponse response = request.GetResponse())
            {
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    XNamespace content = "http://purl.org/rss/1.0/modules/content/";
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        var xdoc = XDocument.Load(reader);
                        blogMainFeed = (from story in xdoc.Descendants("item")
                            select new _RssContent
                            {
                                Title = ((string) story.Element("title")),
                                Link = ((string) story.Element("link")),
                                Description = ((string) story.Element("description")),
                                PubDate = ((string) story.Element("pubDate")),
                                Encoded = ((string) story.Element(content + "encoded"))
                            }).Take(10);
                    }
                }
            }

            return blogMainFeed;
        }
    }
}