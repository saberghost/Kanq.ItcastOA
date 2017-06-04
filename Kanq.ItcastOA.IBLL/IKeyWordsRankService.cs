using Kanq.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.IBLL
{
    public partial interface IKeyWordsRankService : IBaseService<KeyWordsRank>
    {
        bool DeleteAllKeyWordsRank();
        bool InsertKeyWordsRank();
    }
}
