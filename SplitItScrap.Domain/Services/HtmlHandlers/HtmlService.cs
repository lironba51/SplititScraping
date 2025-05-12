using SplitItScrap.Domain.LibAdapters.HtmlParser;

namespace SplitItScrap.Domain.Services.HtmlHandlers
{
    public class HtmlService: IHtmlService
    {
        private readonly IHtmlParser _htmlParser;

        public HtmlService(IHtmlParser htmlParser)
        {
            _htmlParser = htmlParser;
        }

        public void ProcessHtml(string html)
        {
            //_htmlParser.LoadHtml(html);
            //string title = _htmlParser.GetInnerText("//title");
            //var links = _htmlParser.GetLinks("//a");

            //foreach (var link in links)
            //{
                
            //}
        }
    }
}
