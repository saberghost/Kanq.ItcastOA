using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanq.ItcastOA.WebApp.Models.EnumType
{
    /// <summary>
    /// 删除类型
    /// </summary>
    public enum DeleteEnumType
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal=0,

        /// <summary>
        /// 逻辑删除
        /// </summary>
        LogicDelete=1
    }
}