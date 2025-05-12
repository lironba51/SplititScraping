using HtmlAgilityPack;
using SplitItScrap.Domain.Services.Actors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitItScrap.Domain.LibAdapters.HtmlParser.HTMLAgilityPack
{
    public class HTMLAgilityPackAdapter : IHtmlParser
    {
        private HtmlDocument _document;

        public HTMLAgilityPackAdapter()
        {
            _document = new HtmlDocument();
        }

        public void LoadHtml(string html)
        {
            _document.LoadHtml(html);
        }

        public string GetInnerText(object node, string xpath)
        {
            var htmlNode = node as HtmlNode;
            return htmlNode?.SelectSingleNode(xpath)?.InnerText.Trim() ?? string.Empty;
        }

        public IEnumerable<string> GetLinks(string xpath)
        {
            return _document.DocumentNode
                .SelectNodes(xpath)?
                .Select(n => n.GetAttributeValue("href", string.Empty))
                .Where(href => !string.IsNullOrEmpty(href)) ?? Enumerable.Empty<string>();
        }

        public IEnumerable<string> GetInnerTexts(string xpath)
        {
            return _document.DocumentNode
                .SelectNodes(xpath)?
                .Select(n => n.InnerText.Trim()) ?? Enumerable.Empty<string>();
        }

        public IEnumerable<T> ParseElements<T>(string itemXPath, Func<HtmlNode, T> mapFunc)
        {
            var items = _document.DocumentNode.SelectNodes(itemXPath);
            if (items == null)
                return Enumerable.Empty<T>();

            return items.Select(mapFunc);
        }

        public IEnumerable<T> ParseElements<T>(string itemXPath, Func<IHtmlParser, HtmlNode, T> mapFunc)
        {
            var items = _document.DocumentNode.SelectNodes(itemXPath);
            if (items == null)
                return Enumerable.Empty<T>();

            return items.Select(item => mapFunc(this, item));
        }
    }
}
