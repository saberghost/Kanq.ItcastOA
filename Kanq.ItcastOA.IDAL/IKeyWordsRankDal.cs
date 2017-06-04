using Kanq.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.IDAL
{
    public partial interface IKeyWordsRankDal : IBaseDal<KeyWordsRank>
    {
        bool DeleteAllKeyWordsRank();
        bool InsertKeyWordsRank();
    }
}
