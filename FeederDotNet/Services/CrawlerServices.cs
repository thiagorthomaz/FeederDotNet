using AutoMapper;
using FeederDotNet.DAL;
using FeederDotNet.Models;
using Hangfire.Server;
using HtmlAgilityPack;
using System.Text.Json;

namespace FeederDotNet.Services
{
    public class CrawlerServices : ICrawlerServices
    {

        private static readonly HttpClient client = new HttpClient();
        private readonly HashSet<string> visitedUrls = new HashSet<string>();
        private readonly List<Link> crawledLinks = new List<Link>();


        private async Task<bool> IsValidLinkAsync(string url)
        {

            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            url = url.ToLower();

            if (url.StartsWith("#"))
            {
                //Book marks are not wanted
                return false;
            }

            if (url.StartsWith("mailto:"))
            {
                //Email links are not wanted
                return false;
            }

            if (url.StartsWith("tel:"))
            {
                //Phone links are not wanted
                return false;
            }

            if (url.StartsWith("sms:"))
            {
                //sms links are not wanted
                return false;
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) {
                return false;
            }

            if (!url.StartsWith("https://")) {
                return false;
            }

            bool alreadyCrawled = await LinkAlreadyCrawled(url);
            if (alreadyCrawled) {
                return false;
            }

            return true;

        }


        public async Task CrawlAsync(string url, int depth)
        {

            if (depth <= 0 || visitedUrls.Contains(url)) return;

            bool isValidLink = await IsValidLinkAsync(url);
            if (!isValidLink) return;

            Console.WriteLine($"Crawling: {url}");
            visitedUrls.Add(url);
            crawledLinks.Add(new Link { Url = url, CrawledAt = DateTime.UtcNow });

            string html = await FetchHtmlAsync(url);
            if (html == null) return;

            List<string> links = ExtractLinks(html, url);
            foreach (string link in links)
            {
                await CrawlAsync(link, depth - 1);
            }

            await SaveCrawledLinks();

        }

        private async Task<bool> LinkAlreadyCrawled(string url)
        {


            return false;
        }

        private async Task SaveCrawledLinks()
        {

        }

        private async Task<string> FetchHtmlAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching {url}: {ex.Message}");
                return null;
            }
        }

        private List<string> ExtractLinks(string html, string baseUrl)
        {
            List<string> links = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out Uri baseUri))
            {
                Console.WriteLine($"Invalid base URL: {baseUrl}");
                return links;
            }

            foreach (var node in doc.DocumentNode.SelectNodes("//a[@href]") ?? new HtmlNodeCollection(null))
            {
                string href = node.GetAttributeValue("href", string.Empty);
                if (Uri.TryCreate(baseUri, href, out Uri result))
                {
                    links.Add(result.ToString());
                }
            }
            return links;
        }

        public async Task Test() {
            string startUrl = "https://ge.globo.com/"; // Change this URL as needed
            int maxDepth = 2;

            await CrawlAsync(startUrl, maxDepth);
        }

    }
}
