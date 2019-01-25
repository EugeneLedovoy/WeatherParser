using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parsing
{
    class InfoGetter
    {
        public IHtmlDocument Document { get; private set; }
        public string Source { get; }

        public InfoGetter(string source)
        {
            Source = source;
        }

        public async Task<IHtmlDocument> GetDocumentAsync()
        {
            var domParser = new HtmlParser();
            Document = await domParser.ParseAsync(Source);
            return Document;
        }


        public List<string> Parse(string tag, string atributeName)
        {
            var list = new List<string>();

            var items = Document.QuerySelectorAll(tag);

            foreach (var item in items)
            {
                list.Add(item.GetAttribute(atributeName).ToString());
            }

            return list;
        }


        public List<string> ParseLink(string tag, string title, string atributeName = null)
        {
            List<string> list = new List<string>();

            var items = Document.QuerySelectorAll(tag).Where(item => item.ClassName != null && item.ClassName.Contains(title));

            foreach (var item in items)
            {
                if (!string.IsNullOrEmpty(atributeName))
                    list.Add(item.GetAttribute(atributeName).ToString());

                else
                    list.Add(item.TextContent.ToString());
            }
            return list;
        }

    }
}
