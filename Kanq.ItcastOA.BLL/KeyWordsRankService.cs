using Kanq.ItcastOA.IBLL;
using Kanq.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.BLL
{
    public partial class KeyWordsRankService : BaseService<KeyWordsRank>, IKeyWordsRankService
    {
        /// <summary>
        /// 删除汇总表中的数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteAllKeyWordsRank()
        {
            return CurrentDBSession.KeyWordsRankDal.DeleteAllKeyWordsRank();
        }

        /// <summary>
        /// 将明细表中的数据插入汇总表
        /// </summary>
        /// <returns></returns>
        public bool InsertKeyWordsRank()
        {
            return CurrentDBSession.KeyWordsRankDal.InsertKeyWordsRank();
        }
    }
}
