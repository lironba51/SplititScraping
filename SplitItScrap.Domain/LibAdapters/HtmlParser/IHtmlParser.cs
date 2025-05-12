using HtmlAgilityPack;
using SplitItScrap.Domain.Services.Actors.Entities;
using System;
using System.Collections.Generic;

namespace SplitItScrap.Domain.LibAdapters.HtmlParser
{
    public interface IHtmlParser
    {
        void LoadHtml(string html);
        public string GetInnerText(object node, string xpath);
        IEnumerable<string> GetLinks(string xpath);
        IEnumerable<string> GetInnerTexts(string xpath);
        IEnumerable<T> ParseElements<T>(string itemXPath, Func<IHtmlParser, HtmlNode, T> mapFunc);
    }
}
