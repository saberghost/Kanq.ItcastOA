using Kanq.ItcastOA.BLL;
using Kanq.ItcastOA.IBLL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.QuartzNet
{
    public class IndexJob : IJob
    {
        public IKeyWordsRankService KeyWordsRankService = new KeyWordsRankService();
        public void Execute(IJobExecutionContext context)
        {
            KeyWordsRankService.DeleteAllKeyWordsRank();
            KeyWordsRankService.InsertKeyWordsRank();
        }
    }
}
