using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Analysis.Tokenattributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PanGu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.Common
{
    public class WebCommon
    {
        public static string GetJsonList<T>(int total,IEnumerable<T> rows)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            string data = JsonConvert.SerializeObject(new { total = total, rows = rows }, Formatting.Indented, timeFormat);
            return data;
        }

        public static string GetJson(object value)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            string data = JsonConvert.SerializeObject(value, Formatting.Indented, timeFormat);
            return data;
        }

        public static List<string> PanGuSplitWord(string kw)
        {
            List<string> list = new List<string>();
            Analyzer analyzer = new PanGuAnalyzer();
            using (TokenStream tokenStream = analyzer.TokenStream("", new StringReader(kw)))
            {
                ITermAttribute ita;
                while (tokenStream.IncrementToken())
                {
                    ita = tokenStream.GetAttribute<ITermAttribute>();
                    list.Add(ita.Term);
                }
            }
            return list;
        }

        // /创建HTMLFormatter,参数为高亮单词的前后缀
        public static string CreateHightLight(string keywords, string Content)
        {
            PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter =
             new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
            //创建Highlighter ，输入HTMLFormatter 和盘古分词对象Semgent
            PanGu.HighLight.Highlighter highlighter =
            new PanGu.HighLight.Highlighter(simpleHTMLFormatter,
            new Segment());
            //设置每个摘要段的字符数
            highlighter.FragmentSize = 150;
            //获取最匹配的摘要段
            return highlighter.GetBestFragment(keywords, Content);

        }
    }
}
