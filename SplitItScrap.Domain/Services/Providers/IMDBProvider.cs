using SplitItScrap.Domain.Helpers;
using SplitItScrap.Domain.LibAdapters.HtmlParser;
using SplitItScrap.Domain.Services.Actors.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SplitItScrap.Domain.Services.Providers
{
    public class IMDBProvider : IProvider
    {
        private readonly IHtmlParser _htmlParser;
        private const string URL = "https://www.imdb.com/list/ls054840033/";

        public IMDBProvider(IHtmlParser htmlParser)
        {
            _htmlParser = htmlParser;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(URL);

            _htmlParser.LoadHtml(html);

            var actors = GetActors();

            return actors;
        }

        private IEnumerable<Actor> GetActors()
        {
            var actors = _htmlParser.ParseElements("//li[contains(@class, 'ipc-metadata-list-summary-item')]", (parser, node) =>
            {
                var nameRank = parser.GetInnerText(node, ".//h3");
                var (rank, name) = StringSplitHelper.SplitText(nameRank, ".");
                var details = parser.GetInnerText(node, ".//div[@data-testid='dli-item-description']");
                var type = parser.GetInnerText(node, ".//a[@data-testid='nlib-known-for-title']");

                return new Actor
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Details = details,
                    Rank = Convert.ToInt32(rank),
                    Type = type,
                    Provider = ProviderTypeCode.IMDB
                };
            });

            return actors;
        }
    }
}
