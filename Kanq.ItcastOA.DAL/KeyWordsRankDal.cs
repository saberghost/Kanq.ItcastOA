using Kanq.ItcastOA.IDAL;
using Kanq.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.DAL
{
    public partial class KeyWordsRankDal : BaseDal<KeyWordsRank>, IKeyWordsRankDal
    {
        /// <summary>
        /// 删除汇总表中的数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteAllKeyWordsRank()
        {
            string sql = "truncate table KeyWordsRank";
            return db.Database.ExecuteSqlCommand(sql)>0;
        }

        /// <summary>
        /// 将明细表中的数据插入汇总表
        /// </summary>
        /// <returns></returns>
        public bool InsertKeyWordsRank()
        {
            string sql = "insert into KeyWordsRank(Id,KeyWords,SearchCount) select newid(),KeyWords,count(*)  from SearchDetails where DateDiff(day,SearchDetails.SearchDateTime,getdate())<=7 group by SearchDetails.KeyWords";
            return db.Database.ExecuteSqlCommand(sql) > 0;
        }
    }
}
